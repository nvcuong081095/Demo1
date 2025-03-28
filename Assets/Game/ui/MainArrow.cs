using UnityEngine;
using UnityEngine.EventSystems;

public class MainArrow :MonoBehaviour,IPointerClickHandler
{
    
    public delegate void PressAction();

    public  static event PressAction? OnPressed;

    public  void OnPointerClick(PointerEventData eventData)
    {
        OnPressed?.Invoke();
    }

}
