using System;
using UnityEngine;

[CreateAssetMenu(fileName ="a", menuName ="aaa")]
public class GameData : ScriptableObject
{
[SerializeField] private int size;
[SerializeField] private DataElement[] dataElements;



[Serializable] private struct DataElement{
    public float var1;
    public float var2;
    public float var3;
    public float var4;
    public float var5;
    

}

}

