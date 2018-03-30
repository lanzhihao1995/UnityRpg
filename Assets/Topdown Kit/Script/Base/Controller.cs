using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Controller : IController {

    private IView __view__;

    public void GetView() {
        throw new System.NotImplementedException();
    }

    public void Hide() {
        throw new System.NotImplementedException();
    }

    public abstract void InitServer();

    public abstract void InitView();

    public bool IsShow() {
        if(this.__view__ != null ) {
            return this.__view__.IsShow();
        }
        return false;
    }

    public void SetView(IView view) {
        throw new System.NotImplementedException();
    }

    public void Show(string res_path) {
        this.__view__.Show(res_path);
    }
}
