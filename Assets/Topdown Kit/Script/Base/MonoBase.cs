using Assets.Topdown_Kit.Script.MVC;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoBase {

    private Dictionary<string, object> eventDict = new Dictionary<string, object>();
    private AudioManager _audioManager = AppFacade.Instance.GetManager<AudioManager>( "AudioManager" );
    public GameObject UI { get; set; }

    protected UISprite FindUISprite(string path) {
        return UI.transform.Find( path ).GetComponent<UISprite>();
    }

    protected UILabel FindUILabel(string path ) {
        return UI.transform.Find( path ).GetComponent<UILabel>();
    }

    protected void AddClick(GameObject go, Action<GameObject> callBack ) {
        GOUtil.AddClick( go, delegate ( GameObject o ) {
            _audioManager.Play( "Audio/ButtonClick" );
            if ( callBack != null) {
                callBack( go );
            }
        } );
        this.eventDict.Add( "Click", go );
    }

    protected void AddChild(GameObject parentGo, GameObject childGo) {
        GOUtil.AddChild( parentGo, childGo );
    }

    public virtual void Dispose() {
        eventDict.Clear();
    }
}
