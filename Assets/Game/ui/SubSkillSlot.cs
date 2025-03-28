using System;
using Game.Skills;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SubSkillSlot : MonoBehaviour, IPointerClickHandler
{

    [Header("id")]
    [SerializeField] private int selectedId;
    [SerializeField] private PlayerSkillsListSO listSO;
    public delegate void PressAction(int id, Vector3 localTransform);
    public static event PressAction? OnPressed;

    private Image img;

    void Awake()
    {
        img = GetComponent<Image>();
    }

    void OnEnable()
    {
        SubSkillSlotPopup.OnPressed += OnSkillPopupPressed;
    }

    private void OnSkillPopupPressed(string soIndex, int slotId)
    {
        if(slotId == selectedId){
            img.sprite = listSO.GetBasicSkillSO(soIndex).icon;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        OnPressed?.Invoke(selectedId, transform.localPosition);
    }


}
