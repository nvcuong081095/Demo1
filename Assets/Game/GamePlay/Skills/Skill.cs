using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

namespace Game.Skills
{
    public class Skill 
    {
        public BasicSkillSO OriginSkillSO { get; private set; }
        public string SkillName { get; private set; }
        public float CurrentCooldown { get; private set; }
        public float CurrentManaCost { get; private set; }
        public Sprite Icon { get; private set; }
        public BasicSkillSO.SkillType SkillType { get; private set; }

        private Queue<GameObject> prefabPool ;
        private uint _currentLevel;
        private bool active = false;

        public Queue<GameObject> PrefabPool
        {
            get
            {
                if (prefabPool == null)
                {
                    prefabPool = new Queue<GameObject>();
                }
                return prefabPool;
            }
            set => prefabPool = value;
        }
        
        public uint CurrentLevel
        {
            get => _currentLevel;
            private set
            {
                if (value > BasicSkillSO.MAXLEVEL)
                {
                    _currentLevel = BasicSkillSO.MAXLEVEL;
                }
                else
                {
                    _currentLevel = value;
                }
            }
        }



        public Skill() { }


        public Skill(BasicSkillSO originSkillSO)
        {
            OriginSkillSO = originSkillSO;
            SkillName = originSkillSO.skillName;
            CurrentCooldown = originSkillSO.defaultCooldown;
            CurrentManaCost = originSkillSO.defaultManaCost;
            Icon = originSkillSO.icon;
            SkillType = originSkillSO.skillType;
            CurrentLevel = originSkillSO.defaultLevel;
        }
    
   

        public void setActive(bool value)
        {
            active = value;
        }

        public bool isActive()
        {
            return active;
        }
       
    }

    
}
