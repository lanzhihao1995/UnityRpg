using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerManager {

    public static Dictionary<int, string> layerDict = new Dictionary<int, string>();

    public static void Init() {
        layerDict.Add( Window, "Window" );
        layerDict.Add( MainUI, "MainUI" );
        layerDict.Add( Loading, "Loading" );
        layerDict.Add( None, "None" );
    }

    public static int None = -1;
    public static int MainUI = 1;          //主界面UI
    public static int Window = 2;          //普通窗口层级
    public static int Loading = 100;       //加载层级

}
