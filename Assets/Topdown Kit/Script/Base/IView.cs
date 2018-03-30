using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IView{

    /// <summary>
    /// 显示界面
    /// </summary>
    /// <param name="res_path">资源路径</param>
    void Show( string res_path );
    /// <summary>
    /// 隐藏界面
    /// </summary>
    void Hide();
    /// <summary>
    /// 界面是否显示
    /// </summary>
    bool IsShow();
    /// <summary>
    /// 显示或者隐藏
    /// </summary>
    void ShowOrHide();
    /// <summary>
    /// 销毁界面
    /// </summary>
    void Dispose();
}
