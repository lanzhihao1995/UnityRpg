using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : Manager {

    private AudioSource _audioSource;
    private Dictionary<string, AudioClip> _audioDict = new Dictionary<string, AudioClip>();
    private Transform _audioPos;

    private void Start() {
        _audioSource = GameObject.Find( "AudioManager" ).GetComponent<AudioSource>();
        DontDestroyOnLoad( GameObject.Find( "AudioManager" ) );
    }

    private Vector3 DefaultPos {
        get {
            if(_audioPos == null ) {
                _audioPos = Camera.main.transform;
            }
            if(_audioPos != null ) {
                return _audioPos.position;
            }
            return Vector3.zero;
        }
    }


    public void Play(string audioPath ) {
        string key = AssetName( audioPath );
        AudioClip ac = null;
        if ( !_audioDict.TryGetValue( key, out ac ) ) {
            ac = Resources.Load<AudioClip>( audioPath );
            _audioDict.Add( key, ac );
        }
        AudioSource.PlayClipAtPoint( ac, DefaultPos );
    }
	
}
