using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainUIIcon : CellRender {

    public UISprite _icon;
    //public MainUIIcon() {
    //    this.layer = LayerManager.MainUI;
    //}

    public override void Show( string res_path = null ) {
        base.Show( "UI/MainUI/MainUIRightBottomIcon" );
    }

    protected override void LoadCallBack() {
        base.LoadCallBack();

        _icon = this.UI.GetComponent<UISprite>();
    }

    public override void SetData(object data) {
        _icon.spriteName = data.ToString();
    }

}
