using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginModule : BaseView {

    public LoginModule() {
        this.layer = LayerManager.Window;
    }

    public override void Show(string path = null) {
        base.Show("UI/Login/LoginModule");
    }



}
