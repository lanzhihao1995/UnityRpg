using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainUIController : Controller {

    

    public override void InitServer() {
        
    }

    public override void InitView() {
        var view = new MainUIModule();
        base.SetView( view );
    }
}
