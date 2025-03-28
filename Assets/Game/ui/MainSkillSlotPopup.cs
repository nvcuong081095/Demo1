using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MainSkillSlotPopup : MonoBehaviour, IPointerClickHandler
{

    private string skillSOIndex = default;
    public string BasicSkillSOIndex { get => skillSOIndex; set => skillSOIndex = value; }

    public delegate void PressAction(string soIndex);
    public static event PressAction? OnPressed;

    private Image img;



    private void Awake()
    {
        img = GetComponent<Image>();
    }



    public void OnPointerClick(PointerEventData eventData)
    {
        OnPressed?.Invoke(BasicSkillSOIndex);
    }


    public void setImage(Sprite _sprite)
    {
        img.sprite = _sprite;
    }
}
