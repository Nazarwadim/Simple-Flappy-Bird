using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ButtonActions : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public UnityEvent ButtonDown;
    public UnityEvent Pressed;
    public UnityEvent ButtonUp;

    private void OnEnable() {
        GetComponent<Button>().onClick.AddListener(InvokePressed);
    }

    private void OnDisable() {
        GetComponent<Button>().onClick.RemoveListener(InvokePressed);
    }

    private void InvokePressed() {
        Pressed?.Invoke();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        ButtonDown?.Invoke();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        ButtonUp?.Invoke();
    }
}
