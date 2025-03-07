using System;
using UnityEngine;

public class UIWin : MonoBehaviour, IPanel
{
    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
