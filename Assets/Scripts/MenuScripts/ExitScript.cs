using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ExitScript : MonoBehaviour
{
    
    public void Exit()
    {
        Application.Quit();

        #if UNITY_EDITOR
            EditorApplication.isPlaying = false;
        #endif

    }

}
