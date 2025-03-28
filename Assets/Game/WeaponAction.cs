using UnityEngine;

public class WeaponAction : MonoBehaviour
{
    [Header("Target Object")]
    [SerializeField] private GameObject targetWeapon;
    [SerializeField] private ScriptableObject weaponActions;

    private Weapon weapon;


    void OnEnable()
    {
        weapon = targetWeapon.GetComponent<Weapon>();
    }


    





    
}
