using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class pack : MonoBehaviour {
    public List<ItemEntity> items = null;
    
    public int maxItem = 32;

    // Use this for initialization
    void Start () {
        items = new List<ItemEntity>();
    }

    public ObjItem getItem(ObjItem item) {
        ItemEntity itemEntity = ItemEntity.FillData(item);

        if (!itemEntity.IsCanAdd) {
            if(items.Count < maxItem) {
                items.Add(itemEntity);
                item.count = 0;
            } else {   
                Debug.Log("GET FAIL");
            }
        } 
        else {
            if (items.Count < 1) {
                items.Add(itemEntity);
                item.count = 0;
            }
            else {
                foreach (ItemEntity currItem in items) {
                    if (currItem.ObjId.Equals(itemEntity.ObjId) && currItem.Count < currItem.MaxAdd) {
                        currItem.Count = currItem.Count + itemEntity.Count;
                        if (currItem.Count - currItem.MaxAdd > 0) {
                            item.count = currItem.Count - currItem.MaxAdd;
                            itemEntity.Count = item.count;
                            currItem.Count = currItem.MaxAdd;
                        }
                        else {
                            item.count = 0;
                        }
                    }
                    else {
                        continue;
                    }
                }
                if(item.count > 0 && items.Count < maxItem) {
                    items.Add(itemEntity);
                    item.count = 0;
                }
            } 
        }
        return item;      
    }

    public void showPack()
    {
        string show = "Item：\n";
        int i = 0;
        foreach (ItemEntity currItem in items)
        {  
            show += ++i + " [" + currItem.ObjName + "], Amount: " + currItem.Count + "\n";
        }
        Debug.Log(show);
    }
}