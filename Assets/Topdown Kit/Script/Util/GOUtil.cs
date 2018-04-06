using Assets.Topdown_Kit.Script.MVC;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GOUtil {

    /// <summary>
    /// 获取组件
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="trans"></param>
    /// <param name="path">只支持完整路径，不支持名字查找</param>
    /// <returns></returns>
    public static T FindComp<T>( Transform trans, string path ) where T : Component {
        Transform t = trans.Find( path );

        if ( t == null )
            return null;

        return t.GetComponent<T>();
    }


    public static UIPanel FindUIPanel( Transform trans, string path ) {
        return FindComp<UIPanel>( trans, path );
    }
    public static UILabel FindUILabel( Transform trans, string path ) {
        return FindComp<UILabel>( trans, path );
    }
    public static UISprite FindUISprite( Transform trans, string path ) {
        return FindComp<UISprite>( trans, path );
    }
    public static UIButton FindUIButton( Transform trans, string path ) {
        return FindComp<UIButton>( trans, path );
    }
    public static UITexture FindUITexture( Transform trans, string path ) {
        return FindComp<UITexture>( trans, path );
    }
    public static UISlider FindUISlider( Transform trans, string path ) {
        return FindComp<UISlider>( trans, path );
    }

    /// <summary>
    /// 添加点击事件
    /// </summary>
    /// <param name="go"></param>
    /// <param name="callBack"></param>
    public static void AddClick(GameObject go, Action<GameObject> callBack , object sender = null) {
        if ( go == null && callBack == null ) return;
        UIEventListener.Get( go ).onClick += delegate ( GameObject o ) {
            if(sender != null ) {
                
            }
            callBack( o );
        };
    }

    /// <summary>
    /// 移除点击事件
    /// </summary>
    /// <param name="go"></param>
    public static void RemoveClick(GameObject go ) {
        if ( go == null ) return;
        UIEventListener listener = go.GetComponent<UIEventListener>();
        if(listener != null ) {
            listener.onClick = null;
        }
    }

    public static void AddChild(GameObject parentGo, GameObject childGo ) {
        AppFacade.Instance.GetManager<UIManager>( "UIManager" ).AddChild( parentGo, childGo );
    }
}
