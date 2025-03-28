using UnityEngine;

public class Weapon
{
    public WeaponSO weaponSO { get; private set; }
    public string weaponName { get; private set; }
    public float currentDamage { get; private set; }
    public float currentAttackRate { get; private set; }
    public float currentAttackRange { get; private set; }
    public float currentDetectedRadius { get; private set; }
    public Sprite weaponIcon { get; private set; }
    public WeaponSO.WeaponRange rangeType { get; private set; }
    public WeaponSO.WeaponBonusStats bonus { get; private set; }

    public Weapon() { }
    public Weapon(WeaponSO weaponSO)
    {
        this.weaponSO = weaponSO;
        weaponName = weaponSO.weaponName;
        currentDamage = weaponSO.baseDamage;
        currentAttackRate = weaponSO.baseAttackRate;
        currentAttackRange = weaponSO.attackRange;
        currentDetectedRadius = weaponSO.detectedEnemyRadius;
        weaponIcon = weaponSO.weaponIcon;
        rangeType = weaponSO.rangeType;
        bonus = weaponSO.bonus;
    }
    
}
