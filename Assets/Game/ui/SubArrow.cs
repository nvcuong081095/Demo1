using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class SubArrow : MonoBehaviour,IPointerClickHandler
{

    public delegate void PressAction();

    public  static event PressAction? OnPressed;

    public  void OnPointerClick(PointerEventData eventData)
    {
        OnPressed?.Invoke();
    }

}
