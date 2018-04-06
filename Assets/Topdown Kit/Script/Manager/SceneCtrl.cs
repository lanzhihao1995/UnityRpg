using Assets.Topdown_Kit.Script.MVC;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneCtrl  {

    public static void LoadScene() {
        //Loading load = new Loading( sceneName );
        AppFacade.Instance.AddManager<UIManager>( "UIManager" ).LoadUIGameObject( "UI/Loading/LoadingView", LayerManager.Loading );
    }
	
}
