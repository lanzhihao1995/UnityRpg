using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoleCache  {

    private PlayerStatus _playerStatus;

    
	public RoleCache() {
        GameObject go = GameObject.FindGameObjectWithTag( "Player" );
        _playerStatus = go.GetComponent<PlayerStatus>();
    }

    public string Name {
        get {
            return _playerStatus.playerName;
        }
    }
}
