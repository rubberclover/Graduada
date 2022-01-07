using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventarioPiso : MonoBehaviour
{
    [SerializeField]
    public static InventorySystem current;
    [SerializeField]
    private Dictionary<InventoryItemData, InventoryItem> m_itemDictionary;
    [SerializeField]
    public List<InventoryItem> inventory;


    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
