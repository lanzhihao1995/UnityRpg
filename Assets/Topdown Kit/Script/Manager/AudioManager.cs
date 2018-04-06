using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : Manager {

    private AudioSource _audioSource;

    private void Start() {
        _audioSource = GameObject.Find( "AudioManager" ).GetComponent<AudioSource>();
        DontDestroyOnLoad( GameObject.Find( "AudioManager" ) );
    }

    public static void Play(string audioPath ) {

    }
	
}
