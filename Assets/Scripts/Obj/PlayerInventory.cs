using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private List<int> keys = new List<int>(); 

    public void AddKey(int keyID)
    {
        if (!keys.Contains(keyID))
        {
            keys.Add(keyID);
            Debug.Log("เก็บกุญแจดอกที่ " + keyID);
        }
    }

    public bool HasKey(int keyID)
    {
        return keys.Contains(keyID);
    }

    public bool HasAnyKey()
    {
        return keys.Count > 0; 
    }
}
