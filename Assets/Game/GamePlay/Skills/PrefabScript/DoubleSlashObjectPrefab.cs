using System;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.VFX;

public class DoubleSlashObjectPrefab : BaseSkillObjectPrefab
{

    void Awake()
    {
        visualEffect = GetComponent<VisualEffect>();
        thisTransform = GetComponent<Transform>();
    }
    void OnEnable()
    {
        skillSO.OnVFXStarted += OnVFXStarted;
        skillSO.OnSkillEnded += OnSkillEnded;
        skillSO.OnSkillstarted += OnSkillStarted;
    }


    private void OnVFXStarted(object[] args)
    {
        thisTransform.rotation = Quaternion.Euler(thisTransform.eulerAngles + new Vector3(0, 0, (float)args[0]));
        visualEffect.SendEvent("OnPlay");

    }

    void OnDisable()
    {
        skillSO.OnVFXStarted -= OnVFXStarted;
        skillSO.OnSkillEnded -= OnSkillEnded;
    }

    private void OnSkillEnded(object[] args)
    {
        OnObjectInActive();
    }

    protected override void OnObjectInActive()
    {
        this.PrefabPool.Enqueue(gameObject);
        gameObject.SetActive(false);
    }
    private void OnSkillStarted(object[] args)
    {
        thisTransform.position = (Vector3)args[0];
        thisTransform.forward = (Vector3)args[1];
    }

}
