using UnityEngine;
using System.Collections;

public class OnGUIScript : MonoBehaviour
{
    void OnGUI()
    {
        if (GUI.Button(new Rect(20, 40, 100, 20), "Button OnGUI"))
        {
            Debug.Log("Button OnGUI clicked.");
        }
    }
}
