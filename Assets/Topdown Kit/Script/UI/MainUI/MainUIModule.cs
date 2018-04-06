using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainUIModule : BaseView {

    private string[] rightBottom = { "btn_bag", "btn_chuanshuo", "btn_equip" };
    private UIList<MainUIIcon> _iconList;
    
    public MainUIModule() {
        this.layer = LayerManager.MainUI;
    }

    public override void Show( string res_path = null ) {
        base.Show( "UI/MainUI/MainUIModule" );
    }

    protected override void LoadCallBack() {
        base.LoadCallBack();

        CellData cellData = new CellData();
        cellData.go = GameObject.Find( "RightBottom/Grid" );
        cellData.showToolTip = false;
        this._iconList = new UIList<MainUIIcon>( cellData );
        this._iconList.DataProvider = rightBottom;
    }
}
