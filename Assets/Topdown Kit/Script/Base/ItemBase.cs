using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBase : Icon {

    protected UISprite _quatilyBg;
    protected UILabel _numLabel;
    protected GameObject _bindGo;
    protected override string AssetPath {
        get {
            return "UI/Base/ItemBase";
        }
    }

    public override void Show() {
        base.Show();
    }


}
