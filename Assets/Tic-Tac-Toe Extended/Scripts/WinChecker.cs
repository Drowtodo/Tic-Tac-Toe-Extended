public static class WinChecker
{
    /// <summary>
    /// Определяет наступила ли победа
    /// </summary>
    /// <param name="table"></param>
    /// <param name="currentCell"></param>
    /// <param name="winCounter"></param>
    /// <returns></returns>
    public static bool Check(Symbols[,] table, Cell currentCell, int winCounter, out Point begin, out Point end)
    {
        int count = 1;
        int x = currentCell.GetPosition().x;
        int y = currentCell.GetPosition().y;
        Symbols cs = currentCell.GetSymbol();
        bool isBeginX = x == 0;
        bool isBeginY = y == 0;
        bool isEndX = x == table.GetLength(1);
        bool isEndY = y == table.GetLength(0);
        begin = end = new Point(x, y);

        #region проверка строки на победу
        if (!isBeginX)
        {
            for (int i = x - 1; i >= 0; i--)
            {
                if (table[i, y] == cs)
                {
                    count++;
                    begin = new Point(i, y);
                }
                else
                {
                    break;
                }
            }
        }

        if(!isEndX)
        {
            for (int i = x + 1; i < table.GetLength(1); i++)
            {
                if (table[i, y] == cs)
                {
                    count++;
                    end = new Point(i, y);
                }
                else
                {
                    break;
                }
            }
        }

        if (count >= winCounter)
        {
            return true;
        }
        #endregion

        count = 1;

        #region проверка столбца на победу
        if(!isBeginY)
        {
            for (int i = y - 1; i >= 0; i--)
            {
                if (table[x, i] == cs)
                {
                    count++;
                    begin = new Point(x, i);
                }
                else
                {
                    break;
                }
            }
        }

        if (!isEndY)
        {
            for (int i = y + 1; i < table.GetLength(0); i++)
            {
                if (table[x, i] == cs)
                {
                    count++;
                    end = new Point(x, i);
                }
                else
                {
                    break;
                }
            }
        }

        if (count >= winCounter)
        {
            return true;
        }
        #endregion

        count = 1;

        #region проверка первой диагонали
        int ix = x - 1, jy = y - 1;
        while (ix >= 0 && jy >= 0)
        {
            if (table[ix,jy] == cs)
            {
                count++;
                begin = new Point(ix, jy);
            }
            ix--;
            jy--;
        }

        ix = x + 1;
        jy = y + 1;
        while (ix < table.GetLength(1) && jy < table.GetLength(0))
        {
            if (table[ix, jy] == cs)
            {
                count++;
                end = new Point(ix, jy);
            }
            ix++;
            jy++;
        }

        if (count >= winCounter)
        {
            return true;
        }
        #endregion

        count = 1;

        #region проверка второй диагонали
        ix = x - 1;
        jy = y + 1;
        while (ix >= 0 && jy < table.GetLength(0))
        {
            if (table[ix, jy] == cs)
            {
                count++;
                begin = new Point(ix, jy);
            }
            ix--;
            jy++;
        }

        ix = x + 1;
        jy = y - 1;
        while (ix < table.GetLength(1) && jy >= 0)
        {
            if (table[ix, jy] == cs)
            {
                count++;
                end = new Point(ix, jy);
            }
            ix++;
            jy--;
        }

        if (count >= winCounter)
        {
            return true;
        }
        #endregion

        return false;
    }

}
