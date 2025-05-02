using System;

public class HighCellsHolder : CellsHolder
{
    private void Start()
    {
        int count = (int)Math.Sqrt(transform.childCount);

        _table = new Symbols[count, count];
        CellSelector.GetInstance();
        for (int i = 0; i < transform.childCount; i++)
        {
            int x = i % count;
            int y = i / count;
            var cell = transform.GetChild(i).GetComponent<Cell>();
            cell.InitPostion(x, y);
            cell.OnCellRegistrateTurn += OnCellRegistrateTurn;
            _table[y, x] = Symbols.NONE;
            CellSelector.Add(cell.transform.GetChild(2).gameObject.GetComponent<CellSelectorInvoker>());
            cell.transform.GetChild(0).GetComponent<DownCellsHolder>().OnWin.AddListener((v1, v2, cl) => 
            {
                cell.transform.GetChild(2).gameObject.SetActive(true);
                cell.transform.GetChild(3).gameObject.SetActive(true);
                cell.Set();
            });
        }
    }
    protected override void OnCellRegistrateTurn(Cell cell)
    {
        var pos = cell.GetPosition();
        _table[pos.x, pos.y] = cell.GetSymbol();
        if (WinChecker.Check(_table, cell, _winCounter, out Point begin, out Point end))
        {
            OnWin?.Invoke(GetCellPosition(begin), GetCellPosition(end), TurnController.GetColor());
            CellSelector.DisableAllClickable();
        }
    }


    public void SelectCell(Cell cell)
    {
        CellSelector.ActivateAll();
        var pos = cell.GetPosition();
        if (_table[pos.x, pos.y] == Symbols.NONE)
        {
            CellSelector.DeactivateCurrently(pos.y * _table.GetLength(0) + pos.x);
        }
    }
}
