using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModuleData {
    public string _moduleType;
    public string _desc;

    /// <summary>
    /// ModuleTypes数据
    /// </summary>
    /// <param name="ModuleType">模块名</param>
    /// <param name="desc">文本描述</param>
    public ModuleData(string moduleType, string desc = "") {
        _moduleType = moduleType;
        _desc = desc;
    }
}

public class ModuleTypes  {

    public static ModuleData Login;
    public static ModuleData MainUI;
    public static ModuleData Bag;

	public static void Init() {
        Login = new ModuleData( "Login", "登陆" );
        MainUI = new ModuleData( "MainUI", "主界面" );
        Bag = new ModuleData( "Bag", "背包" );



        Dispatcher.AddEventListener( EventName.ShowModule, ShowModuleByType );
    }

    static void ShowModuleByType( DataEvent evt ) {
        if(evt._data == ModuleTypes.Bag ) {
            GameController.Bag.ShowOrHide();
        }
    }

}
