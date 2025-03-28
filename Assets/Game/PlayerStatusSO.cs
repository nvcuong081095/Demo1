using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="player status", menuName ="ScriptableObject/PlayerStatusSO")]
public class PlayerStatusSO : ScriptableObject
{
    public float baseHealth;
    public float baseDamege;


    public PlayerStatus GetOrCreatedPlayerStatus(Dictionary<ScriptableObject, object> createdInstance){
           if (createdInstance.TryGetValue(this, out var playerStatus))
            {
                return (PlayerStatus)playerStatus;
            }
            PlayerStatus nPlayerStatus = new PlayerStatus(this);
            createdInstance.Add(this, nPlayerStatus);
            return nPlayerStatus;
    }





}
