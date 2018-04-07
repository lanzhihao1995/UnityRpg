using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Topdown_Kit.Script.MVC {
    /// <summary>
    /// 对象回收
    /// </summary>
    class ObjectPool : MonoBehaviour{

        private static Transform poolGo;
        private static Dictionary<string, GameObject> _objDict = new Dictionary<string, GameObject>();

        public static void Init() {
            poolGo = GameObject.Find( "ObjectPool" ).transform;
        }

        /// <summary>
        /// 对象池中是否有该资源
        /// </summary>
        /// <param name="assetName"></param>
        /// <returns></returns>
        public static bool IsHaveObject(string assetName ) {
            if(_objDict.ContainsKey( assetName )){
                return true;
            }
            return false;
        }

        /// <summary>
        /// 从对象池中获取资源，请先通过IsHaveObject判断是否存在;或者使用该方法的重载
        /// </summary>
        /// <param name="assetName"></param>
        /// <returns></returns>
        public static GameObject GetAsset(string assetName ) {
            GameObject obj;
            if ( _objDict.TryGetValue( assetName, out obj ) ) {
                return obj;
            }
            return null;
        }

        /// <summary>
        /// 从对象池中获取资源
        /// </summary>
        /// <param name="assetName"></param>
        /// <param name="go"></param>
        /// <returns></returns>
        public static bool GetAsset(string assetName, out GameObject go ) {
            if ( _objDict.TryGetValue( assetName, out go ) ) {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 将GameObject推入回收池中
        /// </summary>
        public static void Push(GameObject go) {
            if ( _objDict.ContainsKey( go.name ) ) {
                Destroy( go );
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
                _objDict.Remove( assetName );
                return obj;
            }
            return null;        
        }


    }
}
