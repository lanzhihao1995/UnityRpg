using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour {

    private UIManager _uiManager;
    private AudioManager _audioManager;


    protected UIManager UIManager {
        get {
            if ( !_uiManager ) {
                _uiManager = new UIManager();
            }
            return _uiManager;
        }
    }

    protected AudioManager AudioManager {
        get {
            if ( !_audioManager ) {
                _audioManager = new AudioManager();
            }
            return _audioManager;
        }
    }
	
}
