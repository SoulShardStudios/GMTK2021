using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;

public class UIButton : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler
{
    public Action<PointerEventData> clickCallback;
    [SerializeField] Image _buttonImage;
    [SerializeField] Sprite _pressed, _unpressed;
    public void OnPointerClick(PointerEventData eventData) => clickCallback?.Invoke(eventData);
    public void OnPointerDown(PointerEventData eventData) => _buttonImage.sprite = _pressed;
    public void OnPointerUp(PointerEventData eventData) => _buttonImage.sprite = _unpressed;
}
