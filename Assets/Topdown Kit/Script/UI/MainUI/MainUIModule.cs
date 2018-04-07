using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainUIModule : BaseView {

    private string[] rightBottom = { "btn_bag", "btn_chuanshuo", "btn_equip" };
    private UIList<MainUIIcon> _iconList;
    
    public MainUIModule() {
        this.layer = LayerManager.MainUI;
    }

    protected override string AssetPath {
        get {
            return "UI/MainUI/MainUIModule";
        }
    }

    public override void Show() {
        base.Show();
    }

    protected override void PrefabLoaded() {
        base.PrefabLoaded();

        CellData cellData = new CellData();
        cellData.go = GameObject.Find( "RightBottom/Grid" );
        cellData.showToolTip = false;
        this._iconList = new UIList<MainUIIcon>( cellData );
        this._iconList.DataProvider = rightBottom;
    }
}
