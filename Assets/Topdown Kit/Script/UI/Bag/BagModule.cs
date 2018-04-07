using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagModule : Windows {

    private UIList<BagItem> _bagList;
    private UILabel _playerName;

    public BagModule() {
        base.layer = LayerManager.Window;
    }

    protected override string AssetPath {
        get {
            return "UI/Bag/BagModule";
        }
    }

    public override void Show() {
        base.Show();
    }

    protected override void PrefabLoaded() {
        base.PrefabLoaded();

        _playerName = base.FindUILabel( "PlayerName/Value" );

        _bagList = new UIList<BagItem>( new CellData() { go = GameObject.Find( "ItemList/Grid" ) } );
        _bagList.DataProvider = new object[100];

        FlushView();
    }

    void FlushView() {
        _playerName.text = Cache.Role.Name;
    }

    public override void Dispose() {
        base.Dispose();
    }
}
