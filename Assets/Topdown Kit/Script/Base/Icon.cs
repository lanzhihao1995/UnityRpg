using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Icon : BaseView {

    protected GameObject _icon;
    protected UISprite _iconSprite;
    protected GameObject _selectSprite;
    protected float _width;
    protected float _height;
    protected string _iconName;
    protected bool _isGray;
    protected override string AssetPath {
        get {
            return "UI/Base/IconBase";
        }
    }

    public override void Show() {
        base.Show();
    }

    protected override void PrefabLoaded() {
        base.PrefabLoaded();

        _icon = this.UI.transform.Find( "Icon" ).gameObject;
        _iconSprite = _icon.GetComponent<UISprite>();
        _selectSprite = GameObject.Find( "Selected" );

    }

    public void SetIcon(string _spriteName ) {
        _iconSprite.spriteName = _spriteName;
    }

    public bool IsGray {
        get { return _isGray; }
        set {
            if ( _isGray == value )
                return;
            if ( value ) {
                _iconSprite.color = Color.black;
            }
            else {
                _iconSprite.color = Color.white;
            }
        }
    }
}
