using Assets.Topdown_Kit.Script.MVC;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Manager {

    //public GameObject _uiRoot;

    //初始化游戏
    void Awake() {
        InitUIRoot();
        DontDestroyOnLoad( this );// 防止销毁自己
        //if (GameController.Login.View == null ) {
        //    Debug.LogError( "空的！！！！" );
        //    return;
        //}
        AppFacade.Instance.AddManager<UIManager>( "UIManager" );
        AppFacade.Instance.GetManager<UIManager>( "UIManager" ).InitUIRoot();
        GameController.Init();
    }

    private void Start() {
        GameController.Login.ShowOrHide();
    }

    /// <summary>
    /// 实例化UIRoot
    /// </summary>
    void InitUIRoot() {
        string res_path = "UI/GUI_ROOT";
        GameObject _uiRoot = null;
        UIManager.LoadUIGameObject( res_path, delegate ( GameObject go ) {
            _uiRoot = go;
        }, -1 );
        if( _uiRoot != null ) {
            //_uiRoot = Instantiate( _uiRoot ) as GameObject;
            _uiRoot.name = "GUI_ROOT";
            DontDestroyOnLoad( _uiRoot );
        }
    }
}
