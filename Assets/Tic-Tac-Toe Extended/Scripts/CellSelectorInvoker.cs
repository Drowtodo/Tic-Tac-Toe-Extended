using UnityEngine;
using UnityEngine.EventSystems;

public class CellSelectorInvoker : MonoBehaviour, IPointerClickHandler
{
    private bool _isClickable = true;
    public void OnPointerClick(PointerEventData eventData)
    {
        if (_isClickable)
        {
            CellSelector.Invoke(this);
        }
    }

    public void SetClickable(bool state)
    {
        _isClickable = state;
    }
}
