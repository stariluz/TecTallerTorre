using UnityEngine;
using UnityEngine.UI;

public class UIGameplay : MonoBehaviour, IPanel
{
    public Image image;

    // Update is called once per frame
    void Update()
    {
        image.fillAmount = GameManager.Instance.popComboProgress;
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
