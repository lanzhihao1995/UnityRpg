using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellRender : BaseView, ICellRender {

    public GameObject boxColliderGO;
    private object _data;
    private int _index;

    public virtual object Data {
        get {
            return _data;
        }

        set {
            this._data = value;
            this.SetData( this._data );
        }
    }
    

    public bool IsSelect { get { return false; } set {
        }
    }

    public int Index {
        get {
            return _index;
        }

        set {
            this._index = value;
        }
    }

    public virtual void SetData(object data) {
        
    }

    public object SetIsSelect( bool isSelect ) {
        throw new System.NotImplementedException();
    }

    public void ShowLock( bool value ) {
        throw new System.NotImplementedException();
    }
}
