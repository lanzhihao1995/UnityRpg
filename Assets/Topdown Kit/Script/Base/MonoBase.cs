using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoBase {

    private Dictionary<string, object> eventDict = new Dictionary<string, object>();

    protected GameObject findUISprite(string path) {
        //GameObject sprite = GameObject.
            return null;
    }

    protected void AddClick(GameObject go, Action<GameObject> callBack = null ) {
        GOUtil.AddClick( go, delegate ( GameObject o ) {
            if ( callBack != null) {
                callBack( go );
            }
        } );
        this.eventDict.Add( "Click", go );
    }

    protected void AddChild(GameObject parentGo, GameObject childGo) {
        GOUtil.AddChild( parentGo, childGo );
    }


}
