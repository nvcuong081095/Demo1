using System;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using Game.Skills;
using UnityEngine;
using UnityEngine.UIElements;

public class SkillPanelManger : MonoBehaviour
{
    const uint DEFAULT_INDEX = 0;

    [Header("UI Object")]

    [SerializeField] private GameObject subSkillSlotPanel;
    [SerializeField] private GameObject subSkillPopupPanel;
    [SerializeField] private GameObject mainSkillPanel;
    [SerializeField] private GameObject mainSkillPopupPanel;
    [SerializeField] private GameObject contentMainSkillPopup;
    [SerializeField] private GameObject contentSubSkillPopup;

    [Header("Prefab")]
    [SerializeField] private GameObject subContentPrefab;
    [SerializeField] private GameObject mainContentPrefab;


    [SerializeField] private PlayerSkillsListSO playerSkillListSO;
    [SerializeField]  private GameInitSO gameInitSO;
    [SerializeField] private List<GameObject> skillSlots;
    private Transform subSkillSlotPanelTransform;
    private Transform subSkillSlotPopUpPanelTransform;
    private Transform mainSkillSlotPanelTransform;
    private Transform mainSkillSlotPopUpPanelTransform;



    private bool isMainSkillPanelOpen = false;
    private bool isMainSkillPopupPanelOpen = false;



    private bool isSubSkillPanelOpen = false;
    private bool isSubSkillPopupPanelOpen = false;
    void Awake()
    {
        subSkillSlotPanelTransform = subSkillSlotPanel.GetComponent<Transform>();
        subSkillSlotPopUpPanelTransform = subSkillPopupPanel.GetComponent<Transform>();
        mainSkillSlotPanelTransform = mainSkillPanel.GetComponent<Transform>();
        mainSkillSlotPopUpPanelTransform = mainSkillPopupPanel.GetComponent<Transform>();


    }

    private void OnEnable()
    {
        Initialization();
        SubArrow.OnPressed += OnSubArrowPressed;
        SubSkillSlotPopup.OnPressed += OnSubSkillSlotPopUpPressed;
        SubSkillSlot.OnPressed += OnSubSkillSlotPressed;
        MainArrow.OnPressed += OnMainArrowPressed;
        MainSkillSlot.OnPressed += OnMainSkillSlotPressed;
        MainSkillSlotPopup.OnPressed += OnMainSkillSlotPopupPressed;


    }



    private void OnDisable()
    {

    }


    private void Initialization()
    {
        subInit();
        mainInit();
        initPopupPanel();
    }

    #region event listener func
    private void OnMainArrowPressed()
    {
        if (!isMainSkillPanelOpen)
        {
            isMainSkillPanelOpen = true;
            closeSubSlot();
            closeSubPopup();
            openMainSlot();
        }
        else
        {
            isMainSkillPanelOpen = false;
            closeMainPopup();
            closeMainSlot();
        }
    }


    private void OnMainSkillSlotPressed()
    {
        isMainSkillPopupPanelOpen = true;
        openMainPopup();
    }

    private void OnMainSkillSlotPopupPressed(string soIndex)
    {
        isMainSkillPopupPanelOpen = false;
        closeMainPopup();
    }

    private void OnSubArrowPressed()
    {
        if (!isSubSkillPanelOpen)
        {
            isSubSkillPanelOpen = true;
            closeMainSlot();
            closeMainPopup();
            openSubSlot();
        }
        else
        {
            isSubSkillPanelOpen = false;
            isSubSkillPopupPanelOpen = false;
            closeSubPopup();
            closeSubSlot();
        }
    }


    private void OnSubSkillSlotPressed(int id, Vector3 localpo)
    {
        if (!isSubSkillPopupPanelOpen)
        {
            isSubSkillPopupPanelOpen = true;
            SubSkillSlotPopup.CurrentSkillSlotId = id;
            openSubPopup();
        }
        else
        {
            SubSkillSlotPopup.CurrentSkillSlotId = id;
            subSkillSlotPopUpPanelTransform.DOScale(0f, 0.2f).SetEase(Ease.Linear);
            subSkillSlotPopUpPanelTransform.DOScale(1f, 0.2f).SetEase(Ease.Linear);
            subSkillSlotPopUpPanelTransform.DOLocalMoveY(localpo.y, 0.2f).SetEase(Ease.Linear);


        }
    }


    private void OnSubSkillSlotPopUpPressed(string sid, int id)
    {
        closeSubPopup();
        isSubSkillPopupPanelOpen = false;

    }

    #endregion
    #region  do tween
    private void openMainSlot()
    {
        mainSkillSlotPanelTransform.DOScale(1f, 0.2f).SetEase(Ease.Linear);

    }
    private void closeMainSlot()
    {

        mainSkillSlotPanelTransform.DOScale(0.2f, 0.2f).SetEase(Ease.Linear);
    }
    private void openMainPopup()
    {
        mainSkillPopupPanel.SetActive(true);
        mainSkillSlotPopUpPanelTransform.DOScale(1f, 0.2f).SetEase(Ease.Linear);
    }

    private void closeMainPopup()
    {
        mainSkillSlotPopUpPanelTransform.DOScale(0f, 0.2f).SetEase(Ease.Linear);
        mainSkillPopupPanel.SetActive(false);
    }

    private void openSubSlot()
    {
        subSkillSlotPanelTransform.DOScale(1f, 0.2f).SetEase(Ease.Linear);

    }
    private void closeSubSlot()
    {

        subSkillSlotPanelTransform.DOScale(0.2f, 0.2f).SetEase(Ease.Linear);
    }

    private void openSubPopup()
    {
        subSkillPopupPanel.SetActive(true);
        subSkillSlotPopUpPanelTransform.DOScale(1f, 0.2f).SetEase(Ease.Linear);
    }
    private void closeSubPopup()
    {
        subSkillSlotPopUpPanelTransform.DOScale(0f, 0.2f).SetEase(Ease.Linear);
        subSkillPopupPanel.SetActive(false);
    }

    #endregion






    #region init
    private void subInit()
    {
        List<BasicSkillSO> skillSO = gameInitSO.getSkillSOs(BasicSkillSO.SkillType.Sub, playerSkillListSO.skillList);
        if (skillSO.Any())
        {

            for (int i = 0; i < skillSO.Count; i++)
            {
                GameObject gameObject = Instantiate(subContentPrefab, contentSubSkillPopup.transform);
                SubSkillSlotPopup p = gameObject.GetComponent<SubSkillSlotPopup>();
                p.setImage(skillSO[i].icon);
                p.BasicSkillSOIndex = skillSO[i].index;
                skillSlots.Add(gameObject);

            }
        }
    }
    private void mainInit()
    {
        List<BasicSkillSO> skillSO = gameInitSO.getSkillSOs(BasicSkillSO.SkillType.Main, playerSkillListSO.skillList);
        if (skillSO.Any())
        {

            for (int i = 0; i < skillSO.Count; i++)
            {
                GameObject gameObject = Instantiate(mainContentPrefab, contentMainSkillPopup.transform);
                MainSkillSlotPopup p = gameObject.GetComponent<MainSkillSlotPopup>();
                p.setImage(skillSO[i].icon);
                p.BasicSkillSOIndex = skillSO[i].index;
                skillSlots.Add(gameObject);

            }
        }
    }

    private void initPopupPanel()

    {
        subSkillPopupPanel.SetActive(false);
        mainSkillPopupPanel.SetActive(false);
        subSkillSlotPopUpPanelTransform.localScale = Vector3.zero;
        subSkillSlotPanelTransform.localScale = new Vector3(0.1f, 0.1f);
        mainSkillSlotPopUpPanelTransform.localScale = Vector3.zero;
        mainSkillSlotPanelTransform.localScale = new Vector3(0.1f, 0.1f);
    }
    #endregion
}
