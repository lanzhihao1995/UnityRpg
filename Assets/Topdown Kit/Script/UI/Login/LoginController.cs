using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginController : Controller {

    public override void InitServer() {
        throw new System.NotImplementedException();
    }

    public override void InitView() {
        IView view = new LoginModule();
        this.SetView( view );
    }
}
