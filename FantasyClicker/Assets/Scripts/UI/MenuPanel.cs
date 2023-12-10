using UnityEngine;

public class MenuPanel : MonoBehaviour
{
    [SerializeField] private GameObject statsShop;
    [SerializeField] private GameObject heroesShop;
    [SerializeField] private GameObject locationsShop;

    [SerializeField] private GameObject[] uiToHideStatsShop;
    [SerializeField] private GameObject[] uiToHideHeroesShop;
    [SerializeField] private GameObject[] uiToHideLocationsShop;

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

    public void OpenHeroesShop()
    {
        heroesShop.SetActive(true);

        foreach (var ui in uiToHideHeroesShop)
        {
            ui.SetActive(false);
        }
    }

    public void CloseHeroesShop()
    {
        heroesShop.SetActive(false);

        foreach (var ui in uiToHideHeroesShop)
        {
            ui.SetActive(true);
        }
    }

    public void OpenLocationsShop()
    {
        locationsShop.SetActive(true);

        foreach (var ui in uiToHideLocationsShop)
        {
            ui.SetActive(false);
        }
    }

    public void CloseLocationsShop()
    {
        locationsShop.SetActive(false);

        foreach (var ui in uiToHideLocationsShop)
        {
            ui.SetActive(true);
        }
    }
}
