using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ExitScript : MonoBehaviour
{
    
    public void Exit()
    {
        Application.Quit();
        EditorApplication.isPlaying = false;
    }

}
