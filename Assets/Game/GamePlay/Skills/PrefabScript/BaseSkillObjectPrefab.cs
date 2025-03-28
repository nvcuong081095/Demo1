using System;
using System.Collections.Generic;
using Game.Skills;
using UnityEngine;
using UnityEngine.VFX;

public abstract class BaseSkillObjectPrefab : MonoBehaviour
{
    [SerializeField]
    protected BasicSkillSO skillSO;
    public Queue<GameObject> PrefabPool { get; set; }
    protected VisualEffect visualEffect;
    protected Transform thisTransform;
    protected abstract void OnObjectInActive();








}
