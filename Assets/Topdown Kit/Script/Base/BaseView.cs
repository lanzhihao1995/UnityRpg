using Assets.Topdown_Kit.Script.MVC;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseView : IView {

    protected UIManager _uiManager;
    protected GameObject UI { get; set; }
    protected bool isHide;
    protected int layer;

    public void Show( string res_path = null ) {
        _uiManager = AppFacade.Instance.GetManager<UIManager>( "UIManager" );
        _uiManager.LoadUIGameObject( res_path, delegate(GameObject go) {
            UI = go;
            isHide = true;
        }, layer );
    }

    public abstract void OnShow();

    public void Hide() {
        if ( !isHide ) {
            
        }
    }

    public void ShowOrHide() {
        if ( !isHide ) {
            OnShow();
            //this.Show();
        }
    }

    public void Dispose() {
        _uiManager = null;
        this.UI = null;
        this.isHide = false;
    }

    public bool IsShow() {
        return false;
    }
}
