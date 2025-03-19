using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class Cell : MonoBehaviour, IPointerClickHandler
{
    private TMP_Text m_Text;
    private Point _position = new Point(-1, -1);
    private Symbols _curentSymbol;
    
    public static event Action<Cell> OnCellRegistrateTurn;

    /// <summary>
    /// �� ����� � ������ ������������� ������ �������� ���� � ���������� ������� ����������� ����
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerClick(PointerEventData eventData)
    {
        if(string.IsNullOrEmpty(m_Text.text))
        {
            m_Text.text = TurnController.GetStylizedTurnName();
            _curentSymbol = TurnController.GetCurrentTurnName();
            OnCellRegistrateTurn?.Invoke(this);
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_Text = GetComponentInChildren<TMP_Text>();
    }


    /// <summary>
    /// �������������� ������� ������
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    public void InitPostion(int x, int y)
    {
        _position = new Point(x, y);
    }

    /// <summary>
    /// ���������� ������� ������. ���� ������� �� ���� ����������������, �� ������� ������� -1, -1
    /// </summary>
    /// <returns></returns>
    public Point GetPosition()
    {
        return _position;
    }

    /// <summary>
    /// ���������� ������ � ������
    /// </summary>
    /// <returns></returns>
    public Symbols GetSymbol()
    {
        return _curentSymbol;
    }
}
