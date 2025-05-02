using System;
using UnityEngine;
using UnityEngine.Events;

public abstract class CellsHolder : MonoBehaviour
{
    protected Symbols[,] _table;
    [SerializeField, Range(3, 5)]
    protected int _winCounter = 3;
    public UnityEvent<Vector2, Vector2, Color> OnWin;
    public UnityEvent<Cell> OnCellRegistratedTurn;

    protected abstract void OnCellRegistrateTurn(Cell cell);
    protected Vector2 GetCellPosition(Point point)
    {
        int number = point.x + point.y * (int)Math.Sqrt(transform.childCount);
        var cell = transform.GetChild(number);
        return new Vector2(cell.localPosition.x, cell.localPosition.y);
    }
}
