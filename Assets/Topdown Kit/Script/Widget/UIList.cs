using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct CellData {
    public GameObject go;
    public bool showToolTip;
}

public class UIList<CellClass> where CellClass : CellRender, new() {

    private GameObject _go = null;
    private UIScrollView _scrollView = null;
    private UIGrid _grid = null;
    private bool _showToolTip = false;
    private object[] _dataProvider = null;
    private int _selectIndex = 0;
    private Action _onChange = null;
    private object _sender = null;
    private Action<object> onRepositionComplete = null;
    private CellRender[] _cellList = null;


    public UIList( CellData data ) {
        //if ( data != null ) {
        //    this._go = dict["gameObject"] as GameObject;
        //    this._grid = dict["go"] as UIGrid;
        //    this._scrollView = ( dict["go"] as GameObject ).GetComponentInParent<UIScrollView>();
        //}
        this._go = data.go;
        this._grid = data.go.GetComponent<UIGrid>();
        this._scrollView = data.go.GetComponentInParent<UIScrollView>();
        this._showToolTip = data.showToolTip;
    }

    public object[] DataProvider {
        set {
            this._dataProvider = value;
            UpdateDataProvider();
        }
        get {
            return this._dataProvider;
        }
    }

    public int CurSelectIndex {
        get {
            return this._selectIndex;
        }
        set {
            this._selectIndex = value;
        }
    }

    //刷新数据源
    private void UpdateDataProvider() {
        Action<GameObject> reposition = delegate ( GameObject go ) {
            UIGrid grid = go.GetComponent<UIGrid>();
            if ( grid != null ) {
                grid.repositionNow = true;
                grid.Reposition();
            }
            if ( onRepositionComplete != null ) {
                if ( this._sender != null ) {
                    this.onRepositionComplete( this._sender );
                }
                else {
                    this.onRepositionComplete( null );
                }
            }
        };

        int dataProviderLength = this._dataProvider.Length;
        if ( this._cellList != null && this._cellList.Length >= dataProviderLength ) {
            int index = 0;
            for ( int i = index; i < dataProviderLength; i++ ) {
                this._cellList[i].Data = this._dataProvider[i];
                index++;
            }
            for ( int i = index; i < this._cellList.Length; i++ ) {
                CellRender cell = this._cellList[i];
                if ( cell != null && cell.UI != null ) {
                    GOUtil.RemoveClick( cell.UI );
                }
                cell.Hide();
                this._cellList[i] = null;
            }
            if(this._go!= null ) {
                reposition( this._go );
            }
        }
        else { //如果cell的数量小于data，要补加载cell
            int index = 0;
            if ( this._cellList != null ) {
                for ( int i = 0; i < this._cellList.Length; i++ ) {
                    this._cellList[i].Data = this._dataProvider[i];
                    index++;
                }
            }
            int start = index;
            Action<CellRender> LoadComplete = delegate ( CellRender cell1 ) {
                this._cellList[cell1.Index] = cell1;
                //if ( this._redPointList[cell.Index] ) {
                //    cell.ShowRedPoint(true)
                //}
                //if ( this._lockList[cell.Index] != null ) {
                //    cell.ShowLock( true );
                //}
                if ( cell1.boxColliderGO != null ) {
                    cell1.boxColliderGO = cell1.UI;
                }
                GOUtil.AddClick( cell1.boxColliderGO, this.OnChangeHandler );
                if(index == dataProviderLength ) {
                    UIWidget widget = this._go.GetComponent<UIWidget>();
                    int depth = widget != null ? widget.depth : -1;
                    for(int x = start; x < this._cellList.Length; x++ ) {
                        CellRender cellX = this._cellList[x];
                        //深度管理
                        UIWidget cellWidget = cellX.UI.GetComponent<UIWidget>();
                        if(cellWidget!= null && depth != -1 ) {
                            cellWidget.depth = depth + x;
                        }
                    }

                    reposition( this._go );
                    //resetPosition() TODO
                    if(this._selectIndex > 0 ) {
                        this.CurSelectIndex = this._selectIndex;
                    }
                }
                else {
                    index++;
                }
            };

            CellRender cell;
            for(int i = index;i < dataProviderLength; i ++ ) {
                cell = new CellClass();
                cell.Parent = this._go;
                cell.Index = i;
                cell.Show();
                cell.Data = this._dataProvider[i];
            }
        }
    }

    private void OnChangeHandler(GameObject go) {
    }
}
