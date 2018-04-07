using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataEvent {

    public int _type;
    public object _data;
    public DataEvent(int n = -1, object d = null) {
        _type = n;
        _data = d;
    }

    public override string ToString() {
        return string.Format( "{0}: mName = {1}, mData = {2}", GetType().Name, _type, _data );
    }

    public static DataEvent New(int n = -1, object d = null ) {
        return new DataEvent( n, d );
    }
}
