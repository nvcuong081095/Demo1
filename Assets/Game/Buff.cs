using UnityEngine;

public class Buff
{
    public BuffSO originalSO{ get; private set;}
    public float buffSpeed {get; private set;}
    public float buffDamage {get; private set;}

    public Buff(BuffSO buffSO){
        originalSO = buffSO;
        buffSpeed = buffSO.buffSpeed;
        buffDamage = buffSO.buffDamage;
    }
}
