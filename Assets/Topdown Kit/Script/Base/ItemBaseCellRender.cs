using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBaseCellRender : CellRender {

    private ItemBase _item;

    protected override string AssetPath {
        get {
            return "UI/Base/ItemBaseCellRender";
        }
    }

    protected override void PrefabLoaded() {
        base.PrefabLoaded();

        _item = new ItemBase();
        _item.Parent = base.UI;
        _item.Show();
    }

    public override void Dispose() {
        base.Dispose();

        _item.Dispose();
    }

}
