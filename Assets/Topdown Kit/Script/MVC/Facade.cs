using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Facade {

    static GameObject _gameManager;
    static Dictionary<string, object> _managers = new Dictionary<string, object>();

    GameObject AppGameManager {
        get {
            if ( _gameManager == null ) {
                _gameManager = GameObject.Find( "GameManager" );
            }
            return _gameManager;
        }
    }

    /// <summary>
    /// 添加管理器
    /// </summary>
    /// <param name="typeName"></param>
    /// <param name="obj"></param>
    public void AddManager(string typeName, object obj ) {
        if ( !_managers.ContainsKey( typeName ) ) {
            _managers.Add( typeName, obj );
        }
    }

    /// <summary>
    /// 添加Unity对象
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="typeName"></param>
    /// <returns></returns>
    public T AddManager<T>( string typeName ) where T : Component{
        object result = null;
        _managers.TryGetValue( typeName, out result );
        if(result != null ) {
            return ( T ) result;
        }
        Component c = AppGameManager.AddComponent<T>();
        _managers.Add( typeName, c );
        return default( T );
    }
    
    /// <summary>
    /// 获取管理器
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="typeName"></param>
    /// <returns></returns>
    public T GetManager<T>(string typeName) where T: class {
        if ( !_managers.ContainsKey( typeName ) ) {
            return default( T );
        }
        object manager = null;
        _managers.TryGetValue( typeName, out manager );
        return ( T ) manager;
    }

    public void RemoveManager(string typeName ) {
        if ( !_managers.ContainsKey( typeName ) ) {
            return;
        }
        object manager = null;
        _managers.TryGetValue( typeName, out manager );
        Type type = manager.GetType();
        if ( type.IsSubclassOf( typeof( MonoBehaviour ) ) ) {
            GameObject.Destroy( ( Component ) manager );
        }
        _managers.Remove( typeName );
    }
}
