using System.Collections.Generic;
using System.Linq;
using Game.Skills;
using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    [SerializeField] private GameObject skillSlotPopUpPanel;
    [SerializeField] private GameObject skillSlotPanel;

    [SerializeField] private PlayerSkillsListSO playerSkillListSO;

    [SerializeField] private List<Skill> playerMainSkills;
    [SerializeField] private List<Skill> playerSubSkills;

    private Skill currentActiveMainSkill;
    private List<Skill> currentActiveSubSkills;

    private Dictionary<ScriptableObject, object> createdInstance = new Dictionary<ScriptableObject, object>();
    void Awake()
    {
        Initialization();
    }

    private void OnEnable()
    {
        
    }

    private void Initialization()
    {
        // List<BasicSkillSO> mainList = new List<BasicSkillSO>();
        // List<BasicSkillSO> subList = new List<BasicSkillSO>();
        // if (playerSkillListSO.skillList.Any())
        // {
        //     mainList = playerSkillListSO.skillList.Where(x => x.skillType == BasicSkillSO.SkillType.Main).ToList();
        //     subList = playerSkillListSO.skillList.Where(x => x.skillType == BasicSkillSO.SkillType.Sub).ToList();
        // }
        // if (mainList.Any())
        // {
        //     foreach (BasicSkillSO so in mainList)
        //     {
        //         Skill skill = so.CreateOrGetSkill(createdInstance);
        //     }
        // }
        // if (subList.Any())
        // {
        //     foreach (BasicSkillSO so in subList)
        //     {
        //         Skill skill = so.CreateOrGetSkill(createdInstance);
        //     }
        // }

    }

    
    


}
