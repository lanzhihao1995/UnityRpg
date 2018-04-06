using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginModule : BaseView {

    private GameObject _btnEnter;

    public LoginModule() {
        this.layer = LayerManager.Window;
    }

    public override void Show(string path = null) {
        base.Show("UI/Login/LoginModule");
    }

    protected override void LoadCallBack() {
        _btnEnter = GameObject.Find( "LoginBtn" );



        base.AddClick( this._btnEnter, this.EnterHandler );
    }

    private void EnterHandler(GameObject go) {
        Global.SceneName = "TitleScene";
        SceneCtrl.LoadScene();

        base.Hide();
    }

}
