using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class Cell : MonoBehaviour, IPointerClickHandler
{
    private TMP_Text m_Text;
    private Point _position = new(-1, -1);
    private Symbols _curentSymbol;
    [SerializeField]
    private bool _clickReacting = true;
    
    public event Action<Cell> OnCellRegistrateTurn;

    /// <summary>
    /// По клику в клетку проставляется символ текущего хода и вызывается событие регистрации хода
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerClick(PointerEventData eventData)
    {
        if(_clickReacting && string.IsNullOrEmpty(m_Text.text))
        {
            Set();
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for(int i = 0; i< transform.childCount; i++)
        {
            if(transform.GetChild(i).gameObject.TryGetComponent<TMP_Text>(out m_Text))
            {
                break;
            }
        }
    }


    /// <summary>
    /// Вызвать для установки символа
    /// </summary>
    public void Set()
    {
        m_Text.text = TurnController.GetStylizedTurnName();
        _curentSymbol = TurnController.GetCurrentTurnName();
        OnCellRegistrateTurn?.Invoke(this);
    }

    /// <summary>
    /// Инициализирует позицию клетки
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    public void InitPostion(int x, int y)
    {
        _position = new Point(x, y);
    }

    /// <summary>
    /// Возвращает позицию клетки. Если позиция не была инициализирована, то вернётся позиция -1, -1
    /// </summary>
    /// <returns></returns>
    public Point GetPosition()
    {
        return _position;
    }

    /// <summary>
    /// Возвращает символ в клетке
    /// </summary>
    /// <returns></returns>
    public Symbols GetSymbol()
    {
        return _curentSymbol;
    }
}
