using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Boxophobic.Constants;
using Game.Skills;
using UnityEngine;

public class PlayerStatus
{
    const int GAIN = 1;
    const int UNGAIN = 0;

    public PlayerStatusSO originSO { get; private set; }
    public float currentSpeedMultiplier { get; private set; }
    private float currentDamage;
    private float currentHealth;

    public float CurrentHealth
    {
        get => currentHealth;
        private set
        {
            if (currentHealth < 0) currentHealth = 0;
            else
            {
                currentHealth = value;
            }
        }
    }

    public float CurrentDamage
    {
        get => currentDamage;
        private set
        {
            if (currentDamage < 0) currentDamage = 0;
            else
            {
                currentDamage = value;
            }
        }
    }

    public PlayerStatus(PlayerStatusSO playerStatusSO)
    {
        originSO = playerStatusSO;
        currentHealth = playerStatusSO.baseHealth;
        currentDamage = playerStatusSO.baseDamege;

    }


    public void updateStatus(Weapon weapon, int updateType)
    {
        if (updateType == GAIN)
        {
            CurrentDamage += weapon.currentDamage;
            currentSpeedMultiplier = weapon.currentAttackRate;
        }
        if (updateType == UNGAIN)
        {
            CurrentDamage -= weapon.currentDamage;
            currentSpeedMultiplier -= weapon.currentAttackRate;
        }

    }
    public void updateStatus(Weapon[] weapons, int updateType)
    {
    }
    public void updateStatus(Queue<Skill> skills, int updateType)
    {
        if(!skills.Any()){
            return;
        }
        if(updateType == GAIN){
            foreach(Skill s in skills ){

            }
        }
    }
    public void updateStatus(Skill skill, int updateType)
    {
    }
    public void updateStatus(Buff buff, int updateType)
    {
    }


    private void GainBuff(float addedHealth, float addedDamage, float addedSpeed){
        currentHealth += addedHealth;
        currentDamage += addedDamage;
        currentSpeedMultiplier += addedSpeed;
    }
    private void UnGainBuff(float addedHealth, float addedDamage, float addedSpeed){
        currentHealth -= addedHealth;
        currentDamage -= addedDamage;
        currentSpeedMultiplier -= addedSpeed;
    }



}


