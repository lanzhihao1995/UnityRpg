using Assets.Topdown_Kit.Script.MVC;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseView : IView {

    protected UIManager _uiManager;
    protected GameObject _ui;
    protected bool isHide = false;

    public void Show( string res_path ) {
        _uiManager = AppFacade.Instance.GetManager<UIManager>( "UIManager" );
        _uiManager.LoadUIGameObject( res_path, delegate(GameObject go) {
            _ui = go;
            isHide = true;
        } );
    }

    protected GameObject UI {
        get { return _ui; }
        set { _ui = value; }
    }

    public void Hide() {
        if ( !isHide ) {
            
        }
    }

    public void ShowOrHide() {
        if ( !isHide ) {
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
