using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Global  {

    private static string _sceneName;
    public static string SceneName {
        get {
            return _sceneName;
        }
        set {
            _sceneName = value;
        }
    }


    //private static int _eventId = 0;
    //public static int EventId {
    //    get {
    //        return _eventId++;
    //    }
    //}
}
