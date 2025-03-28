using System;
using System.Collections.Generic;
using DG.Tweening;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.VFX;

[CreateAssetMenu(fileName = "new skill", menuName = "Skills/BasicBasicSkillSO/DoubleLightningSlashSO")]

public class DoubleLightningSlashSO : Game.Skills.BasicSkillSO
{
    [Header("Skill Settings")]
    [SerializeField] private float angle1;
    [SerializeField] private float angle2;
    [SerializeField] private float angleSlash;

    [Header("AngleSpeed")]

    [SerializeField] private float firstDefaultAngleSpeed;
    [SerializeField] private float secondDefaultAngleSpeed;
    [SerializeField] private float returnDefaultSpeed;

    [Header("Prefab VFX")]
    [SerializeField] private GameObject lightningSlashPrefab;


    override public void PerformAction(WeaponComponent weapon, float speedMultiplier)
    {
        RaiseSkillStartedEvent(weapon.thisTranform.position, weapon.thisTranform.forward);
        Sequence seq1 = SlashByAngleDegree(weapon.thisTranform, angle1, speedMultiplier);
        Sequence seq2 = SlashByAngleDegree(weapon.thisTranform, angle2, speedMultiplier);
        seq1.Append(seq2);
        seq2.OnComplete
            (() =>
        {
            RaiseSkillEndedEvent();
        });
    }


    private Sequence SlashByAngleDegree(Transform weapon, float angle, float speedMultiplier = 1)
    {
        Vector3 fowardVector = weapon.forward;
        Vector3 defaultEuler = weapon.eulerAngles;
        Sequence seq = DOTween.Sequence();

        Tween t1 = weapon.DORotate(fowardVector + new Vector3(0, 0, angle), firstDefaultAngleSpeed * speedMultiplier).OnComplete(() =>
        {
            RaiseVFXStartedEvent(angle);
        }).SetRelative();
        Tween t2 = weapon.DORotate(fowardVector + new Vector3(angleSlash, 0, 0), secondDefaultAngleSpeed * speedMultiplier, RotateMode.LocalAxisAdd).SetRelative();
        Tween t3 = weapon.DORotate(defaultEuler, returnDefaultSpeed * speedMultiplier, RotateMode.Fast);
        seq.Append(t1);
        seq.Append(t2);
        seq.Append(t3);
        return seq;
    }


    public override GameObject[] getNeededPrefabs()
    {
        return new GameObject[] { lightningSlashPrefab };
    }




}
