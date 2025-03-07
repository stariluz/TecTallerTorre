using System;
using UnityEngine;

public class UIPause : MonoBehaviour, IPanel
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
