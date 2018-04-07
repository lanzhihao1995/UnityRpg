using Assets.Topdown_Kit.Script.MVC;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum CommonBg {
    General = 0,        // 常规底板
}

/// <summary>
/// 窗口界面基类
/// </summary>
public class Windows : BaseView {

    private Dictionary<int, string> _commonBgDict = new Dictionary<int, string>();
    private float _width;
    private float _height;
    protected int _style;
    protected GameObject _commonBg;
    protected GameObject _closeBtn;

    public Windows() {
        _commonBgDict.Add( ( int ) CommonBg.General, "UI/Base/CommonBg_1" );
        base._isNotClickAnyArea = true;
    }

    protected override void PrefabLoaded() {
        base.PrefabLoaded();

        string path;
        _commonBgDict.TryGetValue( _style, out path );
        AppFacade.Instance.GetManager<UIManager>( "UIManager" ).LoadUIGameObject( path, base.layer, delegate ( GameObject go ) {
            _commonBg = go;
            if ( base.UI ) {
                base.AddChild( base.UI, _commonBg );
            }
        } );

        _closeBtn = GameObject.Find( "CloseBtn" );

        base.AddClick( _closeBtn, this.CloseView );
    }

    void CloseView(GameObject go ) {
        this.Hide();
    }
}
