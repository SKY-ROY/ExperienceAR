using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace RUIS.UI
{
    public class UI_Menus : MonoBehaviour
    {
        [MenuItem("RUIS/UI Tools/Create UI Group")]
        public static void CreateUIGroup()
        {
            //Debug.Log("Creating UI Group");
            GameObject uiGroup = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/RUIS/Prefabs/UI/UI_Group[Prefab].prefab");
            if(uiGroup)
            {
                GameObject createdGroup = (GameObject)Instantiate(uiGroup);
                createdGroup.name = "UI_Group";
            }
            else
            {
                EditorUtility.DisplayDialog("UI Tools Warning", "Cannot find UI Group Prefab!", "OK");
            }
        }
    }
}