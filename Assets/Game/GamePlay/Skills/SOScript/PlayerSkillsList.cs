using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Game.Skills;
[CreateAssetMenu(fileName = "PlayerSkillsList", menuName = "Scriptable Objects/PlayerSkillsList")]
public class PlayerSkillsListSO : ScriptableObject
{
    public List<BasicSkillSO> skillList;

    //get skill SO by index
    public BasicSkillSO GetBasicSkillSO(string skillSOIndex){

       return skillList.SingleOrDefault(x => x.index == skillSOIndex);
    }
}
