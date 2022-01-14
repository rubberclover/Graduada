using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel : MonoBehaviour
{
    public GameObject slotPrefab;

    public void UpdateInventory(){

        foreach(Transform t in transform){
            Destroy(t.gameObject);
        }

        DrawInventory();
    }

    public void DrawInventory(){
        foreach(InventoryItem item in InventorySystem.current.inventory){
            AddInventorySlot(item);
        }
    }

    public void AddInventorySlot(InventoryItem item){
        GameObject obj = Instantiate(slotPrefab);
        obj.transform.SetParent(transform, false);

        Slot slot = obj.GetComponent<Slot>();
        slot.Set(item);
    }
}
