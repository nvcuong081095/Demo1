using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

namespace Game.Skills
{
    public abstract class BasicSkillSO : BaseScriptableObject
    {
        public const uint MAXLEVEL = 20;
        public string skillName;
        public uint defaultLevel;
        public float defaultCooldown;
        public float defaultManaCost;
        public Sprite icon;
        public SkillType skillType;
        public WeaponSO[] weaponType;
        public uint poolSize = default;
        public BuffSO[] buff;

        public delegate void VFXEnventHandler(params object[] args);
        public event VFXEnventHandler? OnVFXStarted;
        public event VFXEnventHandler? OnSkillstarted;
        public event VFXEnventHandler? OnSkillEnded;


        public Skill CreateOrGetSkill(Dictionary<ScriptableObject, object> createdInstance)
        {
            if (createdInstance.TryGetValue(this, out var skill))
            {
                return (Skill)skill;
            }
            Skill newSkill = new Skill(this);
            createdInstance.Add(this, newSkill);
            return newSkill;
        }


        public enum SkillType
        {
            Sub,
            Main
        }

        public virtual void PerformAction(WeaponComponent weapon, float speedMultiplier = 1) { }

        public virtual GameObject[] getNeededPrefabs() { return null; }

        public void RaiseVFXStartedEvent(params object[] args)
        {
            if(args.IsNullOrEmpty())
            {
               OnVFXStarted?.Invoke();
               return;
            }
            OnVFXStarted?.Invoke(args);
        }

        public void RaiseSkillEndedEvent(params object[] args)
        {
            if(args.IsNullOrEmpty())
            {
                OnSkillEnded?.Invoke();
                return;
            }
            OnSkillEnded?.Invoke(args);
        }

        public void RaiseSkillStartedEvent(params object[] args)
        {
            if(args.IsNullOrEmpty())
            {
                OnSkillstarted?.Invoke();
                return;
            }
            OnSkillstarted?.Invoke(args);
        }
    }
}

