using System;
using UnityEngine;

public class TurnController: MonoBehaviour
{
    private static TurnController Instance;

    private Symbols _curentTurn = Symbols.X;

    private event Action _onTurnChange;

    [SerializeField]
    private Color _x;
    [SerializeField]
    private Color _o;

    private void Start()
    {
        if(Instance!=null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    /// <summary>
    /// Возвращает имя текущего хода
    /// </summary>
    /// <returns></returns>
    public static Symbols GetCurrentTurnName()
    {
        return Instance._curentTurn;
    }

    /// <summary>
    /// Возвращает окрашенную строку текущего хода.
    /// </summary>
    /// <returns></returns>
    public static string GetStylizedTurnName()
    {
        string color="green";
        switch (Instance._curentTurn)
        {
            case Symbols.X:
                {
                    color = '#' + ColorUtility.ToHtmlStringRGBA(Instance._x);
                }
                break;
            case Symbols.O:
                {
                    color = '#' + ColorUtility.ToHtmlStringRGBA(Instance._o);
                }
                break;
        }
        return $"<color={color}>{Instance._curentTurn}</color>";
    }

    /// <summary>
    /// Возвращает цвет текущего хода
    /// </summary>
    /// <returns></returns>
    public static Color GetColor()
    {
        switch (Instance._curentTurn)
        {
            case Symbols.X:
                {
                    return Instance._x;
                }
            case Symbols.O:
                {
                    return Instance._o;
                }
        }
        return Color.black;
    }
    /// <summary>
    /// Добвляет слушателя к событию onTurnChange
    /// </summary>
    /// <param name="action"></param>
    public static void AddListner(Action action)
    {
        Instance._onTurnChange += action;
    }

    /// <summary>
    /// Убирает слушателя из событию onTurnChange
    /// </summary>
    /// <param name="action"></param>
    public static void RemoveListner(Action action)
    {
        Instance._onTurnChange -= action;
    }

    /// <summary>
    /// Намеренный вызов смены хода
    /// </summary>
    public static void TurnChange()
    {
        switch(Instance._curentTurn)
        {
            case Symbols.X:
                {
                    Instance._curentTurn = Symbols.O;
                }
                break;
            case Symbols.O:
                {
                    Instance._curentTurn = Symbols.X;
                }
                break;
        }
        Instance._onTurnChange?.Invoke();
    }
}
