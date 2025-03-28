using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Skill Event", menuName = "Scriptable Objects/EventSO/SkillEventMediatorSO")]

public class OSkillEventChannel : ScriptableObject
{
    public event EventHandler OnSkillStarted;
    public event EventHandler OnSkillEnded;
    public event EventHandler OnVFXStarted;
    public event EventHandler OnVFXEnded;

    private delegate void EventDelegate(object sender, EventArgs e);

    public void RaiseSkillStartedEvent()
    {
        OnSkillStarted?.Invoke(this, EventArgs.Empty);
    }
    public void RaiseSkillEndedEvent()
    {
        OnSkillEnded?.Invoke(this, EventArgs.Empty);
    }
    
    public void RaiseVFXStartedEvent()
    {
        OnVFXStarted?.Invoke(this, EventArgs.Empty);
    }
    public void RaiseVFXEndedEvent()
    {
        OnVFXEnded?.Invoke(this, EventArgs.Empty);
    }

   
}
