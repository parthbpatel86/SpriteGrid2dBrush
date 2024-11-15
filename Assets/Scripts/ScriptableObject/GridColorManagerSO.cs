using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "GridColorManagerSO", menuName = "ScriptableObject/Grid Color Manager")]
public class GridColorManagerSO : ScriptableObject
{    

    [System.NonSerialized]
    public UnityEvent<Color> _selectedColorChanged;

    private Color _currentSelectedColor;
    public Color CurrentSelectedColor   // property
    {
        get { return _currentSelectedColor; }   // get method
        set { _currentSelectedColor = value; }  // set method
    }

    private void OnEnable()
    {
        _currentSelectedColor = Color.white;
        _selectedColorChanged = new UnityEvent<Color>();
    }

    public void OnCurrentColorChange(Color color)
    {
        _currentSelectedColor = color;
        _selectedColorChanged.Invoke(_currentSelectedColor);
        _redo.Clear();
        __redoBatch.Clear();
    }

    struct CellColor
    {
        public GridCell cell;
        public Color color;
        public Color prevColor;
        public CellColor(GridCell cell, Color color, Color prevColor)
        {
            this.cell = cell;
            this.color = color;
            this.prevColor = prevColor;
        }
    }

    List<CellColor> _undo=new List<CellColor>();
    List<CellColor> _redo=new List<CellColor>();
    Stack<List<CellColor>> _undoBatch = new Stack<List<CellColor>>();
    Stack<List<CellColor>> __redoBatch = new Stack<List<CellColor>>();

    public void BatchTouchStarted ()
    {
        if (_undo.Count > 0)
        {
            _undoBatch.Push(_undo);
            _undo = new List<CellColor>();
        }
        Debug.Log("batch started");
    }

    public void OnGridCellColorChange(GridCell cell)
    {
        Color prevColor = cell.OnColorChange(_currentSelectedColor);
        _undo.Add(new CellColor (cell, _currentSelectedColor, prevColor));
    }

    public void Undo()
    {
        BatchTouchStarted(); // if there are any new entries in undo list

        if (_undoBatch.Count == 0) return;

        var entry = _undoBatch.Pop();
        __redoBatch.Push(entry);
        for (int i = 0; i < entry.Count; i++)
        {
            entry[i].cell.OnColorChange(entry[i].prevColor);
        }
    }

    public void Redo()
    {
        if (__redoBatch.Count == 0) return;

        var entry = __redoBatch.Pop();
        _undoBatch.Push(entry);
        for (int i = 0; i < entry.Count; i++)
        {
            entry[i].cell.OnColorChange(entry[i].color);
        }
    }
}
