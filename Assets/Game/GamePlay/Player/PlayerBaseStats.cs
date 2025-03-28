using UnityEngine;

[CreateAssetMenu(menuName ="PlayerScriptableObject/PlayerBase")]
public class PlayerBaseStats :ScriptableObject  
{

    public PlayerBaseStats weakness;

    public bool isWinner(PlayerBaseStats i)
    {
        return i.weakness == this;
    }
    
}
