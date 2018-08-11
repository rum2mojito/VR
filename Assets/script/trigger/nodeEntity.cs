using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class nodeEntity {

    private string objId;
    private string objName;
    private string note;
    private bool isChecked;


    public static nodeEntity FillData(node item) {
        nodeEntity itemEntity = new nodeEntity();
        itemEntity.ObjId = item.objId;
        itemEntity.ObjName = item.objName;
        itemEntity.Note = item.note;
        itemEntity.IsChecked = item.isChecked;
        return itemEntity;
    }

    public string ObjId {
        get {
            return objId;
        }

        set {
            objId = value;
        }
    }

    public string ObjName {
        get {
            return objName;
        }

        set {
            objName = value;
        }
    }

    public string Note {
        get {
            return note;
        }

        set {
            note = value;
        }
    }

    public bool IsChecked {
        get {
            return isChecked;
        }

        set {
            isChecked = value;
        }
    }
}