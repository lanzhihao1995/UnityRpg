using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginController : Controller {

    public override void InitServer() {
        return;
    }

    public override void InitView() {
        LoginModule view = new LoginModule();
        this.SetView( view );
    }
}
