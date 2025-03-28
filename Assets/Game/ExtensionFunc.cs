using System;
using UnityEngine;

public static class ExtensionFunc
{
    public static bool IsNullOrEmpty(this Array array)
    {
        return (array == null || array.Length == 0);
    }
}
