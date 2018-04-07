using Assets.Topdown_Kit.Script.MVC;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseView : MonoBase, IView {

    protected UIManager _uiManager;
    protected bool isHide = true;
    protected int layer;
    protected GameObject _parent;
    private string _assetPath;
    private GameObject _maskGo;
    protected bool _isClickAnyClose = false;
    protected bool _isNotClickAnyArea = false;

    public virtual void Show() {
        _uiManager = AppFacade.Instance.GetManager<UIManager>( "UIManager" );
        _uiManager.LoadUIGameObject( AssetPath, layer, delegate ( GameObject go ) {
            UI = go;
            isHide = false;
            PrefabLoaded();
            if(_parent != null ) {
                base.AddChild( this._parent, this.UI );
            }
            
        } );
        if ( _isNotClickAnyArea ) {
            _uiManager.LoadUIGameObject( "UI/Public/Mask", LayerManager.None, delegate ( GameObject go ) {
                _maskGo = go;
                base.AddChild( UI, _maskGo );
            } );
        }
    }

    protected virtual string AssetPath {
        get {
            return _assetPath;
        }
        set {
            _assetPath = value;
        }
    }

    public void Hide() {
        if ( !isHide ) {
            Dispose();
        }
    }

    public GameObject Parent {
        set {
            this._parent = value;
        }
    }

    protected virtual void PrefabLoaded() {

    }

    public void ShowOrHide() {
        if ( isHide ) {
            //OnShow();
            this.Show();
        }
    }

    public override void Dispose() {
        base.Dispose();
        ObjectPool.Push( this.UI );
        if (this._maskGo != null )
            ObjectPool.Push( this._maskGo );
        _uiManager = null;
        this.UI = null;
        this._maskGo = null;
        this.isHide = true;
    }

    public bool IsShow() {
        return false;
    }
}
