using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICellRender  {

	object Data { get; set; }
    int Index { get; set; }
    void SetData(object data);
    object SetIsSelect( bool isSelect );
    bool IsSelect { get; set; }
    void ShowLock( bool value );
}
