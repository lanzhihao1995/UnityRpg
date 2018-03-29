using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Manager {

    //初始化游戏
    void Awake() {
        InitUIRoot();
        DontDestroyOnLoad( this );// 防止销毁自己
        
    }

    /// <summary>
    /// 实例化UIRoot
    /// </summary>
    void InitUIRoot() {
        string res_path = "UI/GUI_ROOT";
        GameObject uiRoot = null;
        UIManager.LoadUIGameObject( res_path, delegate ( GameObject go ) {
            uiRoot = go;
        } );
        if( uiRoot!= null ) {
            uiRoot = Instantiate( uiRoot ) as GameObject;
            uiRoot.name = "GUI_ROOT";
            DontDestroyOnLoad( uiRoot );
        }
    }
}
