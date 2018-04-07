using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginModule : BaseView {

    private GameObject _btnEnter;

    public LoginModule() {
        this.layer = LayerManager.Window;
    }
    protected override string AssetPath {
        get {
            return "UI/Login/LoginModule";
        }
    }

    public override void Show() {
        base.Show();
    }

    protected override void PrefabLoaded() {
        _btnEnter = GameObject.Find( "LoginBtn" );



        base.AddClick( this._btnEnter, this.EnterHandler );
    }

    private void EnterHandler(GameObject go) {
        Global.SceneName = "TitleScene";
        SceneCtrl.LoadScene();

        base.Hide();
    }

}
