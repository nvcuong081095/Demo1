using System.Collections.Generic;
using UnityEngine;

public class BuffSO : ScriptableObject
{
    public float buffSpeed;
    public float buffDamage;

    public Buff CreateOrGetBuff(Dictionary<ScriptableObject, object> createdInstance)
    {
        if (createdInstance.TryGetValue(this, out var buff))
        {
            return (Buff)buff;
        }
        Buff newBuff = new Buff(this);
        createdInstance.Add(this, newBuff);
        return newBuff;
    }

}
