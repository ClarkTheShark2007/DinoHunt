using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenSizeMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(256,240, Screen.fullScreen);
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
        Debug.Log("WorksResolution");
    }
}
