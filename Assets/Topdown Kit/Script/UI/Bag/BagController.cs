using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagController : Controller {
    public override void InitServer() {
        
    }

    public override void InitView() {
        var view = new BagModule();
        this.SetView( view );
    }
}
