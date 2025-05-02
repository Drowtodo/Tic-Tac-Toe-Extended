using System.Collections.Generic;
public class CellSelector
{
    private static CellSelector Instance;
    private List<CellSelectorInvoker> _invokers;


    private CellSelector()
    {
        _invokers = new List<CellSelectorInvoker>();
    }

    public static CellSelector GetInstance()
    {
        if (Instance == null)
        {
            Instance = new CellSelector();
        }
        return Instance;
    }

    public static bool Add(CellSelectorInvoker invoker)
    {
        if (Instance != null)
        {
            Instance._invokers.Add(invoker);
            return true;
        }
        return false;
    }


    public static void Invoke(CellSelectorInvoker invoker)
    {
        Instance._invokers.ForEach((i) => { i.SetClickable(false); });
        invoker.gameObject.SetActive(false);
    }

    public static void ActivateAll()
    {
        Instance._invokers.ForEach((i) => 
        { 
            i.SetClickable(true);
            i.gameObject.SetActive(true);
        });
    }

    public static void DisableAllClickable()
    {
        Instance._invokers.ForEach((i) => { i.SetClickable(false); });
    }

    public static void DeactivateCurrently(int index)
    {
        Instance._invokers.ForEach((i) => { i.SetClickable(false); });
        Instance._invokers[index].gameObject.SetActive(false);
    }
}
