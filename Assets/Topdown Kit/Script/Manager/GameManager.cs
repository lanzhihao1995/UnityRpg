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
        AppFacade.Instance.AddManager<UIManager>( "UIManager" );
        AppFacade.Instance.AddManager<AudioManager>( "AudioManager" );
        AppFacade.Instance.GetManager<UIManager>( "UIManager" ).InitUIRoot();
        Init();
    }

    private void Start() {
        GameController.Login.ShowOrHide();
        Dispatcher.AddEventListener( EventName.SceneLoaded, this.SceneLoaded );
        Dispatcher.AddEventListener( EventName.EntityCreate, this.InitEntity );
    }

    void SceneLoaded(DataEvent evt ) {
        if( (string)evt._data == "Dreamdev Village" ) {
            GameController.MainUI.ShowOrHide();
        }
    }

    void InitEntity( DataEvent evt ) {
        Cache.Init();
    }

    /// <summary>
    /// 实例化UIRoot
    /// </summary>
    void InitUIRoot() {
        string res_path = "UI/GUI_ROOT";
        GameObject _uiRoot = null;
        UIManager.LoadUIGameObject( res_path, LayerManager.None, delegate ( GameObject go ) {
            _uiRoot = go;
        } );
        if ( _uiRoot != null ) {
            //_uiRoot = Instantiate( _uiRoot ) as GameObject;
            _uiRoot.name = "GUI_ROOT";
            DontDestroyOnLoad( _uiRoot );
        }
    }

    void Init() {
        GameController.Init();
        LayerManager.Init();
        ObjectPool.Init();
        ModuleTypes.Init();

        GameObject pool = GameObject.Find( "ObjectPool" );
        DontDestroyOnLoad( pool );
    }
}
