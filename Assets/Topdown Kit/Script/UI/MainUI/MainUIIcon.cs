using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainUIIcon : CellRender {

    public UISprite _icon;
    //public MainUIIcon() {
    //    this.layer = LayerManager.MainUI;
    //}

    protected override string AssetPath {
        get {
            return "UI/MainUI/MainUIRightBottomIcon";
        }
    }

    public override void Show() {
        base.Show();
    }

    protected override void PrefabLoaded() {
        base.PrefabLoaded();

        _icon = this.UI.GetComponent<UISprite>();
        this.AddClick( _icon.gameObject, this.ClickHandler );
    }

    public override void SetData(object data) {
        _icon.spriteName = data.ToString();

        
    }

    void ClickHandler(GameObject go ) {
        if ( base.Data.ToString() == "btn_bag" ) {
            Dispatcher.DispatchEvent( EventName.ShowModule, ModuleTypes.Bag );
        }
    }

}
