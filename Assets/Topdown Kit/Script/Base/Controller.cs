using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Controller : IController {

    private IView __view__;

    public Controller() {
        this.InitServer();
        this.InitView();
    }

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
        this.__view__ = view;
    }

    public IView View {
        get {
            return this.__view__;
        }
        set {
            this.__view__ = value;
        }
    }

    public void ShowOrHide() {
        this.View.ShowOrHide();
    }
}
