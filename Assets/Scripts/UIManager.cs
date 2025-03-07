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

    private void Awake()
    {
        _instance = this;
    }

    public void Win()
    {
        uiWin.Show();
    }

    public void GameOver()
    {
        uiGameOver.Show();
    }

    public void Pause()
    {
        uiPause.Show();
    }
}
