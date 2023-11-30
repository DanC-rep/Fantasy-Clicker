using UnityEngine;

public class MenuPanel : MonoBehaviour
{
    [SerializeField] private GameObject statsShop;

    [SerializeField] private GameObject[] uiToHideStatsShop;

    public void OpenStatsShop()
    {
        statsShop.SetActive(true);

        foreach (var ui in uiToHideStatsShop)
        {
            ui.SetActive(false);
        }
    }

    public void CloseStatsShop()
    {
        statsShop.SetActive(false);

        foreach (var ui in uiToHideStatsShop)
        {
            ui.SetActive(true);
        }
    }
}
