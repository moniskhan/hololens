using System;
using System.Collections.Generic;
using System.Text;

using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using UnityEngine.VR.WSA.Input;

namespace UnityEngine.EventSystems
{
    [AddComponentMenu("Event/HoloLens Input Module")]
    public class HoloLensInputModule : StandaloneInputModule
    {
        protected HoloLensInputModule()
        {
        }

        [Tooltip("Maximum number of pixels in screen space to move a widget during a navigation gesture")]
        public float m_NormalizedNavigationToScreenOffsetScalar = 500.0f;

        [Tooltip("Amount of time to show things that responds to clicks in their on-pressed state")]
        public float m_TimeToPressOnTap = 0.3f;

#if !UNITY_EDITOR
        public override bool IsPointerOverGameObject(int pointerId)
        {
            return PointerInputModule.kMouseLeftId == pointerId
                && null != m_GazeEventData
                && null != m_GazeEventData.pointerEventData.pointerEnter;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder("<b>HoloLensInputModule</b>");
            stringBuilder.AppendLine();

            if (null != m_GazeEventData)
                stringBuilder.AppendLine(m_GazeEventData.pointerEventData.ToString());

            return stringBuilder.ToString();
        }

        public override void UpdateModule()
        {
        }

        public override bool IsModuleSupported()
        {
            return true;
        }

        public override bool ShouldActivateModule()
        {
            return !base.ShouldActivateModule() && IsModuleSupported();
        }

        public override void ActivateModule()
        {
            base.ActivateModule();

            eventSystem.SetSelectedGameObject(eventSystem.currentSelectedGameObject, GetBaseEventData());

            m_GestureRecognizer = new GestureRecognizer();
            m_GestureRecognizer.TappedEvent += GestureHandler_Tapped;
            m_GestureRecognizer.NavigationStartedEvent += GestureHandler_NavigationStarted;
            m_GestureRecognizer.NavigationUpdatedEvent += GestureHandler_NavigationUpdated;
            m_GestureRecognizer.NavigationCompletedEvent += GestureHandler_NavigationCompletedOrCanceled;
            m_GestureRecognizer.NavigationCanceledEvent += GestureHandler_NavigationCompletedOrCanceled;
            m_GestureRecognizer.SetRecognizableGestures(
                GestureSettings.Tap
                | GestureSettings.NavigationX
                | GestureSettings.NavigationY
                | GestureSettings.NavigationZ);
            m_GestureRecognizer.StartCapturingGestures();
        }

        public override void DeactivateModule()
        {
            m_GestureRecognizer.StopCapturingGestures();
            m_GestureRecognizer.Dispose();
            m_GestureRecognizer = null;

            base.DeactivateModule();
            ClearSelection();
        }

        public override void Process()
        {
            SendUpdateEventToSelectedObject();

            QueryGazeEventData();
            ProcessGestureClickPress();
            ProcessMove();
            ProcessDrag();

            if (!Mathf.Approximately(m_GazeEventData.pointerEventData.scrollDelta.sqrMagnitude, 0.0f))
            {
                GameObject scrollHandler = ExecuteEvents.GetEventHandler<IScrollHandler>(m_GazeEventData.pointerEventData.pointerCurrentRaycast.gameObject);
                ExecuteEvents.ExecuteHierarchy(scrollHandler, m_GazeEventData.pointerEventData, ExecuteEvents.scrollHandler);
            }
        }

        private void QueryGazeEventData()
        {
            bool existed = null != m_GazeEventData;
            if (!existed)
            {
                m_GazeEventData = new GazeEventData(eventSystem);
                m_GazeEventData.pointerEventData.button = PointerEventData.InputButton.Left;
            }

            m_GazeEventData.pointerEventData.Reset();

            Vector2 pos = GetGazeOrGestureScreenPosition();
            if (!existed)
                m_GazeEventData.pointerEventData.position = pos;

            m_GazeEventData.pointerEventData.delta = pos - m_GazeEventData.pointerEventData.position;
            m_GazeEventData.pointerEventData.position = pos;
            m_GazeEventData.pointerEventData.scrollDelta = GetGestureScrollDelta();

            eventSystem.RaycastAll(m_GazeEventData.pointerEventData, m_RaycastResultCache);
            RaycastResult raycast = FindFirstRaycast(m_RaycastResultCache);
            m_GazeEventData.pointerEventData.pointerCurrentRaycast = raycast;
            m_RaycastResultCache.Clear();

            m_GazeEventData.buttonState = GetFramePressState();
        }

        private void ProcessGestureClickPress()
        {
            PointerEventData pointerEvent = m_GazeEventData.pointerEventData;
            GameObject currentOverGo = pointerEvent.pointerCurrentRaycast.gameObject;

            // PointerDown notification
            if (m_GazeEventData.PressedThisFrame())
            {
                pointerEvent.eligibleForClick = true;
                pointerEvent.delta = Vector2.zero;
                pointerEvent.dragging = false;
                pointerEvent.useDragThreshold = true;
                pointerEvent.pressPosition = pointerEvent.position;
                pointerEvent.pointerPressRaycast = pointerEvent.pointerCurrentRaycast;

                DeselectIfSelectionChanged(currentOverGo, pointerEvent);

                // search for the control that will receive the press
                // if we can't find a press handler set the press
                // handler to be what would receive a click.
                var newPressed = ExecuteEvents.ExecuteHierarchy(currentOverGo, pointerEvent, ExecuteEvents.pointerDownHandler);

                // didn't find a press handler... search for a click handler
                if (null == newPressed)
                {
                    newPressed = ExecuteEvents.GetEventHandler<IPointerClickHandler>(currentOverGo);
                }

                // Debug.Log("Pressed: " + newPressed);

                float time = Time.unscaledTime;

                if (newPressed == pointerEvent.lastPress)
                {
                    var diffTime = time - pointerEvent.clickTime;
                    if (diffTime < 0.3f)
                        ++pointerEvent.clickCount;
                    else
                        pointerEvent.clickCount = 1;

                    pointerEvent.clickTime = time;
                }
                else
                {
                    pointerEvent.clickCount = 1;
                }

                pointerEvent.pointerPress = newPressed;
                pointerEvent.rawPointerPress = currentOverGo;

                pointerEvent.clickTime = time;

                // Save the drag handler as well
                pointerEvent.pointerDrag = ExecuteEvents.GetEventHandler<IDragHandler>(currentOverGo);

                if (pointerEvent.pointerDrag != null)
                    ExecuteEvents.Execute(pointerEvent.pointerDrag, pointerEvent, ExecuteEvents.initializePotentialDrag);
            }

            // PointerUp notification
            if (m_GazeEventData.ReleasedThisFrame())
            {
                // Debug.Log("Executing press-up on: " + pointer.pointerPress);
                ExecuteEvents.Execute(pointerEvent.pointerPress, pointerEvent, ExecuteEvents.pointerUpHandler);

                // Debug.Log("KeyCode: " + pointer.eventData.keyCode);

                // see if we mouse up on the same element that we clicked on...
                var pointerUpHandler = ExecuteEvents.GetEventHandler<IPointerClickHandler>(currentOverGo);

                // PointerClick and Drop events
                if (pointerEvent.pointerPress == pointerUpHandler && pointerEvent.eligibleForClick)
                {
                    ExecuteEvents.Execute(pointerEvent.pointerPress, pointerEvent, ExecuteEvents.pointerClickHandler);
                }
                else if (pointerEvent.pointerDrag != null && pointerEvent.dragging)
                {
                    ExecuteEvents.ExecuteHierarchy(currentOverGo, pointerEvent, ExecuteEvents.dropHandler);
                }

                pointerEvent.eligibleForClick = false;
                pointerEvent.pointerPress = null;
                pointerEvent.rawPointerPress = null;

                if (pointerEvent.pointerDrag != null && pointerEvent.dragging)
                    ExecuteEvents.Execute(pointerEvent.pointerDrag, pointerEvent, ExecuteEvents.endDragHandler);

                pointerEvent.dragging = false;
                pointerEvent.pointerDrag = null;

                // redo pointer enter / exit to refresh state
                // so that if we moused over something that ignored it before
                // due to having pressed on something else
                // it now gets it.
                if (currentOverGo != pointerEvent.pointerEnter)
                {
                    HandlePointerExitAndEnter(pointerEvent, null);
                    HandlePointerExitAndEnter(pointerEvent, currentOverGo);
                }
            }
        }

        private void ProcessMove()
        {
            if (null == m_GazeEventData)
                return;

            GameObject targetGameObject = m_GazeEventData.pointerEventData.pointerCurrentRaycast.gameObject;
            HandlePointerExitAndEnter(m_GazeEventData.pointerEventData, targetGameObject);
        }

        private void ProcessDrag()
        {
            bool moving = m_GazeEventData.pointerEventData.IsPointerMoving();

            if (moving && m_GazeEventData.pointerEventData.pointerDrag != null
                && !m_GazeEventData.pointerEventData.dragging
                && ShouldStartDrag(m_GazeEventData.pointerEventData.pressPosition, m_GazeEventData.pointerEventData.position, eventSystem.pixelDragThreshold, m_GazeEventData.pointerEventData.useDragThreshold))
            {
                ExecuteEvents.Execute(m_GazeEventData.pointerEventData.pointerDrag, m_GazeEventData.pointerEventData, ExecuteEvents.beginDragHandler);
                m_GazeEventData.pointerEventData.dragging = true;
            }

            // Drag notification
            if (m_GazeEventData.pointerEventData.dragging && moving && m_GazeEventData.pointerEventData.pointerDrag != null)
            {
                // Before doing drag we should cancel any pointer down state
                // And clear selection!
                if (m_GazeEventData.pointerEventData.pointerPress != m_GazeEventData.pointerEventData.pointerDrag)
                {
                    ExecuteEvents.Execute(m_GazeEventData.pointerEventData.pointerPress, m_GazeEventData.pointerEventData, ExecuteEvents.pointerUpHandler);

                    m_GazeEventData.pointerEventData.eligibleForClick = false;
                    m_GazeEventData.pointerEventData.pointerPress = null;
                    m_GazeEventData.pointerEventData.rawPointerPress = null;
                }
                ExecuteEvents.Execute(m_GazeEventData.pointerEventData.pointerDrag, m_GazeEventData.pointerEventData, ExecuteEvents.dragHandler);
            }
        }
        
        private PointerEventData.FramePressState GetFramePressState()
        {
            if (m_Tapped)
            {
                if (!m_TapProcessed)
                {
                    m_TapProcessed = true;
                    m_TapPressTime = Time.time;
                    return PointerEventData.FramePressState.Pressed;
                }

                if (Time.time - m_TapPressTime > m_TimeToPressOnTap)
                {
                    m_Tapped = false;
                    return PointerEventData.FramePressState.Released;
                }

                return PointerEventData.FramePressState.NotChanged;
            }

            if (m_Navigating == m_WasNavigating)
                return PointerEventData.FramePressState.NotChanged;

            m_WasNavigating = m_Navigating;

            return m_Navigating
                ? PointerEventData.FramePressState.Pressed
                : PointerEventData.FramePressState.Released;
        }

        private class GazeEventData
        {
            public GazeEventData(EventSystem eventSystem)
            {
                m_PointerEventData = new PointerEventData(eventSystem);
                m_FramePressState = PointerEventData.FramePressState.NotChanged;
            }

            private PointerEventData m_PointerEventData;
            public PointerEventData pointerEventData
            {
                get { return m_PointerEventData; }
            }

            private PointerEventData.FramePressState m_FramePressState;
            public PointerEventData.FramePressState buttonState
            {
                get { return m_FramePressState; }
                set { m_FramePressState = value; }
            }

            public bool PressedThisFrame()
            {
                return PointerEventData.FramePressState.Pressed == m_FramePressState || PointerEventData.FramePressState.PressedAndReleased == m_FramePressState;
            }

            public bool ReleasedThisFrame()
            {
                return PointerEventData.FramePressState.Released == m_FramePressState || PointerEventData.FramePressState.PressedAndReleased == m_FramePressState;
            }
        }

        private void GestureHandler_Tapped(InteractionSourceKind source, int tapCount, Ray headRay)
        {
            m_Tapped = true;
            m_TapProcessed = false;
        }

        private void GestureHandler_NavigationStarted(InteractionSourceKind source, Vector3 normalizedOffset, Ray headRay)
        {
            if (null == eventSystem.currentSelectedGameObject)
                return;

            RectTransform rectTransform = eventSystem.currentSelectedGameObject.GetComponent<RectTransform>();
            if (null == rectTransform)
                return;

            if (!RectTransformUtility.ScreenPointToWorldPointInRectangle(rectTransform, GetGazeScreenPosition(), Camera.main, out m_NavigationAnchorPointWorldSpace))
            {
                m_NavigationAnchorPointWorldSpace = Vector3.zero;
                return;
            }

            m_Navigating = true;
            m_NavigationNormalizedOffset = normalizedOffset;
        }

        private void GestureHandler_NavigationUpdated(InteractionSourceKind source, Vector3 normalizedOffset, Ray headRay)
        {
            if (!m_Navigating)
                return;

            m_NavigationNormalizedOffset = normalizedOffset;
        }

        private void GestureHandler_NavigationCompletedOrCanceled(InteractionSourceKind source, Vector3 normalizedOffset, Ray headRay)
        {
            m_NavigationNormalizedOffset = Vector3.zero;
            m_Navigating = false;
        }

        private Vector2 GetGazeScreenPosition()
        {
            return new Vector2(0.5f * Screen.width, 0.5f * Screen.height);
        }

        private Vector2 GetGazeOrGestureScreenPosition()
        {
            if (!m_Navigating)
                return GetGazeScreenPosition();

            Vector3 navigationAnchorScreenSpace = Camera.main.WorldToScreenPoint(m_NavigationAnchorPointWorldSpace);
            return new Vector2(
                navigationAnchorScreenSpace.x + m_NormalizedNavigationToScreenOffsetScalar * m_NavigationNormalizedOffset.x,
                navigationAnchorScreenSpace.y + m_NormalizedNavigationToScreenOffsetScalar * m_NavigationNormalizedOffset.y);
        }

        private Vector2 GetGestureScrollDelta()
        {
            return m_Navigating
                ? new Vector2(0.0f, m_NavigationNormalizedOffset.z)
                : Vector2.zero;
        }

        private static bool ShouldStartDrag(Vector2 pressPos, Vector2 currentPos, float threshold, bool useDragThreshold)
        {
            if (!useDragThreshold)
                return true;

            return (pressPos - currentPos).sqrMagnitude >= threshold * threshold;
        }

        new private void ClearSelection()
        {
            BaseEventData baseEventData = GetBaseEventData();
            HandlePointerExitAndEnter(m_GazeEventData.pointerEventData, null);
            m_GazeEventData = null;
            eventSystem.SetSelectedGameObject(null, baseEventData);
        }

        [NonSerialized]
        private GazeEventData m_GazeEventData;

        [NonSerialized]
        private GestureRecognizer m_GestureRecognizer;

        [NonSerialized]
        private Vector3 m_NavigationNormalizedOffset = Vector3.zero;

        [NonSerialized]
        private Vector3 m_NavigationAnchorPointWorldSpace;

        [NonSerialized]
        private bool m_WasNavigating = false;

        [NonSerialized]
        private bool m_Navigating = false;

        [NonSerialized]
        private bool m_Tapped = false;

        [NonSerialized]
        private bool m_TapProcessed = false;

        [NonSerialized]
        private float m_TapPressTime = 0.0f;
#endif // !UNITY_EDITOR
    }
}
