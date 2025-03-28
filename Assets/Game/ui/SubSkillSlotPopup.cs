using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SubSkillSlotPopup : MonoBehaviour, IPointerClickHandler
{
    private static int currentSkillSlotId = default;

    private string skillSOIndex = default;
    public string BasicSkillSOIndex { get => skillSOIndex; set => skillSOIndex = value; }
    public static int CurrentSkillSlotId { get => currentSkillSlotId; set => currentSkillSlotId = value; }

    public delegate void PressAction(string soIndex, int slotId);
    public static event PressAction? OnPressed;

    private Image img;



    private void Awake()
    {
        img = GetComponent<Image>();
    }



    public void OnPointerClick(PointerEventData eventData)
    {
        OnPressed?.Invoke(BasicSkillSOIndex, CurrentSkillSlotId);
    }



    public void setCurrentSkillSlotId(int id)
    {
        currentSkillSlotId = id;
    }
    public int getCurrentSkillSlotId()
    {
        return currentSkillSlotId;
    }

    public void setImage(Sprite _sprite)
    {
        img.sprite = _sprite;
    }
}
