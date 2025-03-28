using System.Collections.Generic;
using System.Linq;
using Game.Skills;
using UnityEngine;

[CreateAssetMenu(fileName = "GameInitSO", menuName = "ScriptableObjects/GameInitSO", order = 1)]
public class GameInitSO : ScriptableObject
{
    #region skill init

    public bool AddSkillFromSO(List<BasicSkillSO> skillSOs, List<Skill> skillLists, Dictionary<ScriptableObject, object> createdInstance, BasicSkillSO.SkillType skillType)
    {

        skillLists = new List<Skill>();
        if (skillSOs.Any() == false)
        {
            Debug.LogError("No skills found in the list");
            return false;
        }
        List<BasicSkillSO> sos = getSkillSOs(skillType, skillSOs);
        foreach (BasicSkillSO skillSO in sos)
        {
            Skill skill = skillSO.CreateOrGetSkill(createdInstance);
            skillLists.Add(skill);
            GameObject[] neededPrefabs = skillSO.getNeededPrefabs();
            if (!neededPrefabs.IsNullOrEmpty())
            {
                foreach (GameObject prefab in neededPrefabs)
                {
                    for (int i = 0; i < skillSO.poolSize; i++)
                    {
                        GameObject go = Instantiate(prefab);
                        BaseSkillObjectPrefab baseSkillObjectPrefab = go.GetComponent<BaseSkillObjectPrefab>();
                        baseSkillObjectPrefab.PrefabPool = skill.PrefabPool;
                        go.SetActive(false);
                        skill.PrefabPool.Enqueue(go);
                    }
                }
            }


        }
        return true;

    }

    public List<BasicSkillSO> getSkillSOs(BasicSkillSO.SkillType skillType, List<BasicSkillSO> playerSkillsListSO)
    {
        return playerSkillsListSO.Where(skill => skill.skillType == skillType).ToList();
    }

    #endregion
}
