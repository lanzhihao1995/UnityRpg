using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour {

    private UIManager _uiManager;


    protected UIManager UIManager {
        get {
            if ( !_uiManager ) {
                _uiManager = new UIManager();
            }
            return _uiManager;
        }
    }
	
}
