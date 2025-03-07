using System;
using UnityEngine;

public class UIGameOver : MonoBehaviour, IPanel
{
    public void ReloadScene()
    {
        GameManager.Instance.ReloadLevel();
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
