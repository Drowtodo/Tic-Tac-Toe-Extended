using System;
using UnityEngine;
using UnityEngine.Events;

public class CellsHeader : MonoBehaviour
{
    private Symbols[,] _table;
    [SerializeField, Range(3, 5)]
    private int _winCounter = 3;
    public UnityEvent<Vector2, Vector2, Color> OnWin;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int count = (int)Math.Sqrt(transform.childCount);

        _table = new Symbols[count, count];
        for (int i = 0; i < transform.childCount; i++)
        {
            var cell = transform.GetChild(i).GetComponent<Cell>();
            int x = i % count;
            int y = i / count;
            cell.InitPostion( x, y);
            _table[y, x] = Symbols.NONE;
        }
        Cell.OnCellRegistrateTurn += OnCellRegistrateTurn;
    }

    private void OnCellRegistrateTurn(Cell cell)
    {
        var pos = cell.GetPosition();
        _table[pos.x, pos.y] = cell.GetSymbol();
        if (WinChecker.Check(_table, cell, _winCounter, out Point begin, out Point end))
        {
            OnWin?.Invoke(GetCellPosition(begin), GetCellPosition(end), TurnController.GetColor());
        }
        TurnController.TurnChange();
    }

    private Vector2 GetCellPosition(Point point)
    {
        int number = point.x + point.y * (int)Math.Sqrt(transform.childCount);
        var cell = transform.GetChild(number);
        return new Vector2(cell.localPosition.x, cell.localPosition.y);
    }
}
