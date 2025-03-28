using Game.Skills;
using System;
using System.Collections.Generic;
using System.Linq;
using Unity.Collections;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class InMapManager : MonoBehaviour
{
    [Header("Configuration")]
    [SerializeField] private PlayerSkillsListSO playerSkillsListSO;
    [SerializeField] private GameInitSO gameInitSO;
    [SerializeField] private PlayerStatusSO playerStatusSO;

    [SerializeField] private GameObject weaponObject;
    #region ingame data
    private Dictionary<ScriptableObject, object> createdInstance = new Dictionary<ScriptableObject, object>();
    private List<Skill> mainSkills;
    private List<Skill> subSkills;
    private Skill currentMainSkill;
    private Queue<Skill> currentSubSkills = new Queue<Skill>();
    private WeaponComponent currentWeapon;
    #endregion



    private float timeToAttack = 0f;
    void OnEnable()
    {
        MainSkillSlotPopup.OnPressed += OnMainSkillSlotPopupPressed;
        SubSkillSlotPopup.OnPressed += OnSubSkillSlotPopupPressed;
    }

    void OnDisable()
    {
        MainSkillSlotPopup.OnPressed -= OnMainSkillSlotPopupPressed;
        SubSkillSlotPopup.OnPressed -= OnSubSkillSlotPopupPressed;
    }

    void Awake()
    {
        Initialization();
        currentWeapon = weaponObject.GetComponent<WeaponComponent>();
    }

  






    private void Initialization()
    {
        //PlayerStatus playerStatus = playerStatusSO.GetOrCreatedPlayerStatus(createdInstance);
        if (!gameInitSO.AddSkillFromSO(playerSkillsListSO.skillList, mainSkills, createdInstance, BasicSkillSO.SkillType.Main))
        {
            Debug.Log("main skill error");
        }
        if (!gameInitSO.AddSkillFromSO(playerSkillsListSO.skillList, subSkills, createdInstance, BasicSkillSO.SkillType.Sub))
        {
            Debug.Log("sub skill error");
        }

        
    }
    private void OnSubSkillSlotPopupPressed(string soIndex, int slotId)
    {
        BasicSkillSO basicSkillSO = playerSkillsListSO.GetBasicSkillSO(soIndex);
        Skill skill = basicSkillSO.CreateOrGetSkill(createdInstance);
        if(!currentSubSkills.Contains(skill) && currentSubSkills.Count() <= 4){
            currentSubSkills.Append(skill);
            //add effect
        }
        if(!currentSubSkills.Contains(skill) && currentSubSkills.Count() > 4){
            currentSubSkills.Dequeue();
            currentSubSkills.Append(skill);
            //remove effect and add effect
        }

    }

    private void OnMainSkillSlotPopupPressed(string soIndex)
    {
        BasicSkillSO basicSkillSO = playerSkillsListSO.GetBasicSkillSO(soIndex);
        currentMainSkill = basicSkillSO.CreateOrGetSkill(createdInstance);
        currentWeapon.setCurrentSkill(currentMainSkill);
    }
}
