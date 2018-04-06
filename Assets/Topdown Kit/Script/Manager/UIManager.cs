using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : Manager {

    private Transform _uiRoot;

    public void InitUIRoot() {
        _uiRoot = GameObject.Find( "GUI_ROOT" ).transform;
    }

    /// <summary>
    /// 动态加载UI资源
    /// </summary>
    /// <param name="res_path">在Resources文件夹下的路径，不需要带上后缀</param>
    /// <param name="callBack"></param>
    public void LoadUIGameObject(string res_path, int layer, Action<GameObject> callBack = null ) {
#if UNITY_EDITOR
        GameObject go = Resources.Load( res_path ) as GameObject;
        if(go == null ) {
            Debug.LogError( "资源加载错误：" + res_path );
            return;
        }
        else {
            go = Instantiate( go );
            string layerStr;
            LayerManager.layerDict.TryGetValue( layer, out layerStr );
            if (layer != LayerManager.None ) {
                go.transform.parent = _uiRoot.Find( layerStr );
            }
            if ( !go.activeSelf ) {
                go.SetActive( true );
            }
            go.transform.localScale = Vector3.one;
        }
        if ( callBack != null ) {
            callBack( go );
        }
#else
        Debug.LogError( "暂时不支持此平台" );
#endif
        
    }

    /// <summary>
    /// 添加UI节点到父节点   --TODO 为刷新深度
    /// </summary>
    /// <param name="parentGo"></param>
    /// <param name="childGo"></param>
    public void AddChild(GameObject parentGo, GameObject childGo ) {
        if ( childGo.activeSelf ) {
            childGo.SetActive( false );
        }
        NGUITools.AddChild2( parentGo, childGo );
        NGUITools.SetLayer( childGo, parentGo.layer );
        childGo.SetActive( true );
    }
}
