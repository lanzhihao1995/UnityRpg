using Assets.Topdown_Kit.Script.MVC;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseView : MonoBase, IView {

    protected UIManager _uiManager;
    public GameObject UI { get; set; }
    protected bool isHide = true;
    protected int layer;
    protected GameObject _parent;

    public virtual void Show( string res_path = null ) {
        _uiManager = AppFacade.Instance.GetManager<UIManager>( "UIManager" );
        _uiManager.LoadUIGameObject( res_path, layer, delegate ( GameObject go ) {
            UI = go;
            isHide = false;
            LoadCallBack();
            if(_parent != null ) {
                base.AddChild( this._parent, this.UI );
            }
        } );
    }

    public void Hide() {
        if ( !isHide ) {
            this.Dispose();
        }
    }

    public GameObject Parent {
        set {
            this._parent = value;
        }
    }

    protected virtual void LoadCallBack() {

    }

    public void ShowOrHide() {
        if ( isHide ) {
            //OnShow();
            this.Show();
        }
    }

    public void Dispose() {
        ObjectPool.Push( this.UI );
        _uiManager = null;
        this.UI = null;
        this.isHide = true;
    }

    public bool IsShow() {
        return false;
    }
}
