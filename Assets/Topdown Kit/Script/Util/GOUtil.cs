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
    public static T FindComp<T>(Transform trans, string path) where T: Component {
        Transform t = trans.Find( path );

        if ( t == null )
            return null;

        return t.GetComponent<T>();
    }


    public static UIPanel FindUIPanel(Transform trans, string path ) {
        return FindComp<UIPanel>( trans, path );
    }
    public static UILabel FindUILabel(Transform trans, string path ) {
        return FindComp<UILabel>( trans, path );
    }
    public static UISprite FindUISprite(Transform trans, string path ) {
        return FindComp<UISprite>( trans, path );
    }
    public static UIButton FindUIButton(Transform trans, string path ) {
        return FindComp<UIButton>( trans, path );
    }
    public static UITexture FindUITexture(Transform trans, string path ) {
        return FindComp<UITexture>( trans, path );
    }
    public static UISlider FindUISlider(Transform trans, string path ) {
        return FindComp<UISlider>( trans, path );
    }
}
