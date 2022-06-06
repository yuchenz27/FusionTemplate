using UnityEngine;
using UnityEngine.EventSystems;

public class ScreenButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public bool IsPressed => _isPressed;

    private bool _isPressed = false;

    public void OnPointerDown(PointerEventData eventData)
    {
        _isPressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _isPressed = false;
    }
}
