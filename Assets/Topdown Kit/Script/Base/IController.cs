using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IController {
    
    /// <summary>
    /// 隐藏模块
    /// </summary>
    void Hide();
    /// <summary>
    /// 是否显示
    /// </summary>
    bool IsShow();
    /// <summary>
    /// 设置模块
    /// </summary>
    void SetView(IView view);
    /// <summary>
    /// 获取模块
    /// </summary>
    void GetView();
    /// <summary>
    /// 初始化协议
    /// </summary>
    void InitServer();
    /// <summary>
    /// 初始化模块
    /// </summary>
    void InitView();
    /// <summary>
    /// 显示或隐藏
    /// </summary>
    void ShowOrHide();
}
