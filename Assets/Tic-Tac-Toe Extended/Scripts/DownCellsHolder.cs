using System;

public class DownCellsHolder : CellsHolder
{

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
            cell.OnCellRegistrateTurn += OnCellRegistrateTurn;
            _table[y, x] = Symbols.NONE;
        }
    }

    protected override void OnCellRegistrateTurn(Cell cell)
    {
        var pos = cell.GetPosition();
        _table[pos.x, pos.y] = cell.GetSymbol();
        if (WinChecker.Check(_table, cell, _winCounter, out Point begin, out Point end))
        {
            OnWin?.Invoke(GetCellPosition(begin), GetCellPosition(end), TurnController.GetColor());
        }
        OnCellRegistratedTurn?.Invoke(cell);
        TurnController.TurnChange();
    }

}
