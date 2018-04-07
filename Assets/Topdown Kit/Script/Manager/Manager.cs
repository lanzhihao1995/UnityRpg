using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : Base, IManager {

    /// <summary>
    /// 获取资源名字
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    protected string AssetName( string path ) {
        string[] str = path.Split( '/' );
        string str2 = str[str.Length - 1];
        string[] str3 = str2.Split( '.' );
        return str3[0];
    }

}
