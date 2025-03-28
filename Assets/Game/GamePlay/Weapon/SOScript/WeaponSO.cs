using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponTypeSO", menuName = "Scriptable Objects/WeaponTypeSO")]

public class WeaponSO : ScriptableObject
{
    [Header("Basic Stats")]
    public string weaponName;
    public float baseDamage;
    public float baseAttackRate;
    public float attackRange;
    public float detectedEnemyRadius; 
    public Sprite weaponIcon;
    public WeaponRange rangeType;

    [Header("Bonus")]
    public WeaponBonusStats bonus;

    
    public enum WeaponRange{
        Melee,
        Ranged
    }

    public enum WeaponType{
        OneHanded,
        TwoHanded
    }

    [Serializable]
    public class WeaponBonusStats{
    }


    public Weapon CreateOrGetWeapon(Dictionary<ScriptableObject, object> createdInstance)
    {
        if (createdInstance.TryGetValue(this, out var weapon))
        {
            return (Weapon)weapon;
        }
        Weapon newWeapon = new Weapon(this);
        createdInstance.Add(this, newWeapon);
        return newWeapon;
    }
}
