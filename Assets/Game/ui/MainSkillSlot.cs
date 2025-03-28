using System;
using System.Collections.Generic;
using Game.Skills;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MainSkillSlot : MonoBehaviour, IPointerClickHandler
{
    public delegate void PressAction();
    public static event PressAction? OnPressed;

    [SerializeField] private PlayerSkillsListSO listSO;

    private Image img;

    void Awake()
    {
        img = GetComponent<Image>();
    }
    void OnEnable()
    {
        MainSkillSlotPopup.OnPressed += OnMainSkillPopupPressed;
    }


    void OnDisable()
    {
        MainSkillSlotPopup.OnPressed -= OnMainSkillPopupPressed;
    }
    public void OnPointerClick(PointerEventData eventData)
    {
    
        OnPressed?.Invoke();
    }
    private void OnMainSkillPopupPressed(string soIndex)
    {
        img.sprite = listSO.GetBasicSkillSO(soIndex).icon;
    }
}
