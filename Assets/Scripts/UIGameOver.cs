using System;
using UnityEngine;

public class UIGameOver : MonoBehaviour
{
    internal void Show()
    {
        gameObject.SetActive(true);
    }

    public void ReloadScene()
    {
        GameManager.Instance.ReloadLevel();
    }
}
