using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Listener {

    protected Action<DataEvent> _actionHandler;
    protected int _count = 0;

    public void AddEventListener(Action<DataEvent> handler ) {
        _actionHandler += handler;
        _count++;
    }

    public void RemoveEventListener(Action<DataEvent> handler ) {
        _actionHandler -= handler;
        _count--;
    }

    public void DispatherEvent(DataEvent evt ) {
        if ( _actionHandler != null )
            _actionHandler( evt );
    }

    public override string ToString() {
        return string.Format( "Listener mCounter = {0} . ", _count );
    }
}
