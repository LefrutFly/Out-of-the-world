using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class DataInventory
{
    [SerializeField] public List<DataKey> keys = new List<DataKey>();
}
