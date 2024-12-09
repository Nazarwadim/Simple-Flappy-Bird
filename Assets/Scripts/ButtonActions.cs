using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ButtonActions : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public UnityEvent ButtonDown;
    public UnityEvent ButtonUp;

    public void OnPointerDown(PointerEventData eventData)
    {
        ButtonDown?.Invoke();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        ButtonUp?.Invoke();
    }
}
