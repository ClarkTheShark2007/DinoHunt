using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CrossHair : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    bool pointerDown = false;
    public GameObject Idle;
    public GameObject Shoot;
    

    void Start() 
    {
        Shoot = GameObject.Find("MouseVisual");
        Idle = GameObject.Find("MouseVisual2");
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        pointerDown = true;
        Shoot.SetActive(true);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        pointerDown = false;
    }

    void Update()
    {
        if (pointerDown)
        {
            Idle.SetActive(false);
            Shoot.SetActive(true);
        }
    }
}