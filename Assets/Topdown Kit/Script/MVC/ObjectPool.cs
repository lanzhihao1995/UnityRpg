using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Topdown_Kit.Script.MVC {
    /// <summary>
    /// 对象回收
    /// </summary>
    class ObjectPool {

        private static Transform poolGo;
        private static Dictionary<string, GameObject> _objDict = new Dictionary<string, GameObject>();

        /// <summary>
        /// 将GameObject推入回收池中
        /// </summary>
        public static void Push(GameObject go) {
            GameObject obj;
            if ( _objDict.TryGetValue( go.name,  out obj ) ) {
                return;
            }
            else {
                _objDict.Add( go.name, go );
                go.transform.parent = poolGo;
                go.SetActive( false );
            }
        }

        /// <summary>
        /// 从对象池中获取GameObject
        /// </summary>
        /// <param name="assetName"></param>
        /// <returns></returns>
        public static GameObject Pull(string assetName ) {
            GameObject obj;
            if(_objDict.TryGetValue( assetName, out obj ) ) {
                return obj;
            }
            return null;        
        }


    }
}
