using UnityEngine;
using UnityEditor;
using UnityEditor.Callbacks;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Globalization;

public class PaintScript : MonoBehaviour {

    public class PrefabCreator : MonoBehaviour
    {
        [MenuItem("Assets/Paint")]
        public static void BuildPaint()
        {
            string[] colors = { "red", "orange", "yellow", "green", "blue", "violet", "grey", "brown" };

            Dictionary<string, List<Color>> colorList = new Dictionary<string, List<Color>>
            {
                {colors[0] , new List<Color>(){
                    new Color(156f/255f, 67f/255f, 103f/255f),
                    new Color(197f/255f, 92f/255f, 120f/255f),
                    new Color(172f/255f, 63f/255f, 82f/255f),
                    new Color(169f/255f, 56f/255f, 63f/255f),
                    new Color(193f/255f, 61f/255f, 59f/255f),
                    new Color(215f/255f, 139f/255f, 176f/255f)
                }},
                {colors[1] , new List<Color>() {
                    new Color(226f/255f, 109/255f, 89/255f),
                    new Color(219f/255f, 102/255f, 53/255f),
                    new Color(228f/255f, 119/255f, 55/255f),
                    new Color(237f/255f, 137/255f, 45/255f),
                    new Color(245f/255f, 157/255f, 67/255f),
                    new Color(244f/255f, 153/255f, 124/255f)
                }},
                {colors[2] , new List<Color>() {
                    new Color(255f/255f, 204/255f, 112f/255),
                    new Color(243f/255f, 192/255f, 100f/255),
                    new Color(233f/255f, 183/255f, 94f/255),
                    new Color(241f/255f, 199/255f, 104f/255),
                    new Color(219f/255f, 187/255f, 90f/255),
                    new Color(255f/255f, 218/255f, 151f/255)
                }},
                {colors[3] , new List<Color>() {
                    new Color(213f/255f, 199f/255f, 77f/255f),
                    new Color(204f/255f, 206f/255f, 122f/255f),
                    new Color(193f/255f, 214f/255f, 127f/255f),
                    new Color(150f/255f, 203f/255f, 129f/255f),
                    new Color(133f/255f, 196f/255f, 152f/255f),
                    new Color(231f/255f, 215f/255f, 115f/255f)
                }},
                {colors[4] , new List<Color>() {
                    new Color(31f/255f, 182f/255f, 158f/255f),
                    new Color(31f/255f, 168f/255f, 169f/255f),
                    new Color(0f, 150f/255f, 162f/255f),
                    new Color(0f, 145f/255f, 174f/255f),
                    new Color(0f, 139f/255f, 191f/255f),
                    new Color(94f/255f, 203f/255f, 184f/255f)
                }},
                {colors[5] , new List<Color>() {
                    new Color(92f/255f, 154f/255f, 201f/255f),
                    new Color(74f/255f, 132f/255f, 183f/255f),
                    new Color(115f/255f, 146f/255f, 193f/255f),
                    new Color(110f/255f, 117f/255f, 162f/255f),
                    new Color(107f/255f, 75f/255f, 117f/255f),
                    new Color(127f/255f, 179f/255f, 217f/255f)
                }},
                {colors[6] , new List<Color>() {
                    new Color(185f/255f, 183f/255f, 172f/255f),
                    new Color(192f/255f, 200f/255f, 188f/255f),
                    new Color(163f/255f, 176f/255f, 177f/255f),
                    new Color(164f/255f, 173f/255f, 177f/255f),
                    new Color(161f/255f, 156f/255f, 148f/255f),
                    new Color(211f/255f, 210f/255f, 200f/255f)
                }},
                {colors[7] , new List<Color>() {
                    new Color(190f/255f, 171f/255f, 157f/255f),
                    new Color(222f/255f, 193f/255f, 167f/255f),
                    new Color(187f/255f, 177f/255f, 160f/255f),
                    new Color(198f/255f, 181f/255f, 156f/255f),
                    new Color(196f/255f, 190f/255f, 170f/255f),
                    new Color(217f/255f, 200f/255f, 184f/255f)
                }},
            };


            // add container
            string pathname = AssetDatabase.GetAssetPath(Selection.activeObject);
            string savePath = System.IO.Path.GetDirectoryName(pathname) + '/';

            foreach (var color in colors)
            {
                int id = 0;
                List<Color> validColors = colorList[color];

                foreach (var c in validColors)
                {
                    GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    cube.transform.position = new Vector3(0, 0, 0);
                    cube.transform.localScale = new Vector3(10f, 10f, 0.01f);

                    // create material
                    Material material = new Material(Shader.Find("Standard"));
                    material.color = c;
                    AssetDatabase.CreateAsset(material, savePath + color + id + ".mat");

                    cube.GetComponent<Renderer>().material = material;

                    // create prefab
                    Object prefab = PrefabUtility.CreateEmptyPrefab(savePath + color + id + ".prefab");
                    PrefabUtility.ReplacePrefab(cube, prefab, ReplacePrefabOptions.ConnectToPrefab);

                    GameObject.DestroyImmediate(cube);
                    id++;
                }

            }

        }
    }
}
