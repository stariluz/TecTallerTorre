using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private static UIManager _instance;

    public static UIManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("UIManager is NULL");
            }

            return _instance;
        } set => _instance = value;
    }

    public UIWin uiWin;
    public UIGameOver uiGameOver;
    public UIPause uiPause;
    public UIGameplay uiGameplay;
    List<IPanel> panels = new List<IPanel>();

    private void Awake()
    {
        _instance = this;
        panels.Add(uiWin);
        panels.Add(uiGameOver);
        panels.Add(uiPause);
        panels.Add(uiGameplay);
    }

    public void Win()
    {
        HidePanels(uiWin);
        uiWin.Show();
    }

    public void GameOver()
    {
        HidePanels(uiGameOver);
        uiGameOver.Show();
    }

    public void Pause()
    {
        HidePanels(uiPause);
        uiPause.Show();
    }

    void HidePanels(IPanel exclude)
    {
        foreach (var panel in panels)
        {
            if (panel != exclude)
            {
                panel.Hide();
            }
        }
    }
}
