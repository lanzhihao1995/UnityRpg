using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : Manager {

    private Transform _uiRoot;

    private void Start() {
        _uiRoot = GameObject.Find( "GUI_ROOT" ).transform;
    }

    /// <summary>
    /// 动态加载UI资源
    /// </summary>
    /// <param name="res_path">在Resources文件夹下的路径，不需要带上后缀</param>
    /// <param name="callBack"></param>
    public void LoadUIGameObject(string res_path, Action<GameObject> callBack ) {
#if UNITY_EDITOR
        GameObject go = Resources.Load( res_path ) as GameObject;
        if(go == null ) {
            Debug.LogError( "资源加载错误：" + res_path );
            return;
        }
        else {
            GameObject temp = GameObject.Instantiate( go );
            temp.transform.parent = _uiRoot;
        }
        if ( callBack != null ) {
            callBack( go );
        }
#else
        Debug.LogError( "暂时不支持此平台" );
#endif
        
    }
}
