using UnityEngine;
using UnityEditor;
using UnityEditor.Callbacks;
using System.Collections;
using System.IO;
using System.Globalization;

namespace AssetBundles
{
    public class PrefabCreator : MonoBehaviour
    {
        [MenuItem("Assets/Build Prefab")]
        public static void BuildPrefab()
        {
            string pathname = AssetDatabase.GetAssetPath(Selection.activeObject);
            GameObject asset = (GameObject)AssetDatabase.LoadAssetAtPath(pathname, typeof(GameObject));
            GameObject gObject = Instantiate(asset, new Vector3(0, 0, 0), Quaternion.identity);
            gObject.name = asset.name;
            gObject.transform.position = new Vector3(0, 0, 0);
            gObject.transform.rotation = Quaternion.identity;
            gObject.transform.localScale = new Vector3(1, 1, 1);
            gObject.AddComponent<MeshCollider>();

            string[] nameList = gObject.name.Split((new char[] { '-', '_' }));
            string name = "";
            foreach (string n in nameList)
            {
                if (!n.Contains("3D"))
                {
                    name += CultureInfo.CurrentCulture.TextInfo.ToTitleCase(n);
                }
            }

            // add container
            GameObject container = new GameObject(name);
            container.AddComponent<TapToPlaceParent>();
            gObject.transform.parent = container.transform;

            // create prefab
            Object prefab = PrefabUtility.CreateEmptyPrefab(System.IO.Path.GetDirectoryName(pathname) + '/' + name + ".prefab");
            PrefabUtility.ReplacePrefab(container, prefab, ReplacePrefabOptions.ConnectToPrefab);

            GameObject.DestroyImmediate(container);
        }
    }
}
