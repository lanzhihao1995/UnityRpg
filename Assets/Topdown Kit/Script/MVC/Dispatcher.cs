



using System;
using System.Collections.Generic;

public class Dispatcher {

    private static Dictionary<int, Listener> _listenerDict = new Dictionary<int, Listener>();

    public static void AddListener( int name, Action<DataEvent> handler ) {
        Listener listener = null;
        if ( !_listenerDict.TryGetValue( name, out listener ) ) {
            listener = new Listener();
            _listenerDict.Add( name, listener );
        }
        listener.AddEventListener( handler );
    }

    public static void AddEventListener( int name, Action<DataEvent> handler ) {
        AddListener( name, handler );
    }

    public static void RemoveListener( int name, Action<DataEvent> handler ) {
        Listener listener = null;
        if ( _listenerDict.TryGetValue( name, out listener ) ) {
            listener.RemoveEventListener( handler );
        }
    }

    public static void RemoveEventListener( int name, Action<DataEvent> handler ) {
        RemoveListener( name, handler );
    }

    public static void DispatchEvent( DataEvent evt ) {
        Listener listener = null;
        if ( _listenerDict.TryGetValue( evt._type, out listener ) ) {
            listener.DispatherEvent( evt );
        }
    }

    public static void DispatchEvent( int evtName ) {
        DataEvent evt = new DataEvent( evtName, null );
        Listener listener = null;
        if ( _listenerDict.TryGetValue( evt._type, out listener ) ) {
            listener.DispatherEvent( evt );
        }
    }

    public static void DispatchEvent(int evtName, object data) {
        DataEvent evt = new DataEvent( evtName, data );
        Listener listener = null;
        if(_listenerDict.TryGetValue(evt._type, out listener ) ) {
            listener.DispatherEvent( evt );
        }
    }

    public static bool HasEventListener(int evtName ) {
        return _listenerDict.ContainsKey( evtName );
    }

    public static void Debug() {
        foreach(KeyValuePair<int, Listener> kv in _listenerDict ) {
            UnityEngine.Debug.LogError( kv.Key.ToString() + " ====== " + kv.Value.ToString() );
        }
    }
}