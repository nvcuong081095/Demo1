using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Prefab Event", menuName = "Scriptable Objects/EventSO/PreFabEventSO")]
public class OPrefabEventChannel : ScriptableObject
{
    public event EventHandler OnPrefabSpawned;
    public event EventHandler OnPrefabDespawned;

    public void RaisePrefabSpawnedEvent()
    {
        OnPrefabSpawned?.Invoke(this, EventArgs.Empty);
    }
    public void RaisePrefabDespawnedEvent()
    {
        OnPrefabDespawned?.Invoke(this, EventArgs.Empty);
    }
}
