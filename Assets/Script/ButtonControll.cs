using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class ButtonControll : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    public bool holdPress;
    private bool pressed;

    public void OnPointerDown(PointerEventData eventData)
    {
        pressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        pressed = false;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        pressed = holdPress && true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        pressed = false;
    }

    public bool isPressed()
    {
        return pressed;
    }
}
