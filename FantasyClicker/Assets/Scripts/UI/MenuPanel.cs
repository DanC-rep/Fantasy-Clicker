using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuPanel : MonoBehaviour
{
	[SerializeField] private Image background;

    [SerializeField] private GameObject statsShop;
    [SerializeField] private GameObject heroesShop;
    [SerializeField] private GameObject locationsShop;
    [SerializeField] private GameObject statistic;

	[SerializeField] private List<Button> btns;

	[SerializeField] private GameObject[] uiToHide;

	private GameObject[] shops;

	private void Awake()
	{
		EventManager.OnTutorialShowed.AddListener(SetBtnsInteractible);

		shops = new GameObject[] { statsShop, heroesShop, locationsShop, statistic };
	}

	public void ShowStatsShop() => ShowElement(statsShop);

	public void ShowHeroesShop() => ShowElement(heroesShop);

	public void ShowLocationsShop() => ShowElement(locationsShop);

	public void ShowStatistic() => ShowElement(statistic);

	private void ShowElement(GameObject el)
    {
		if (el.activeSelf)
		{
			el.SetActive(false);
			background.enabled = false;

			foreach (var ui in uiToHide)
			{
				ui.SetActive(true);
			}

			EventManager.SendUiClicked();
			return;
		}

		el.SetActive(true);
		background.enabled = true;

		foreach (var ui in uiToHide)
		{
			ui.SetActive(false);
		}

		foreach (var shop in shops)
		{
			if (shop != el)
			{
				shop.SetActive(false);
			}
		}

		EventManager.SendUiClicked();
	}

	private void SetBtnsInteractible(bool showed)
	{
		btns.ForEach(btn => btn.interactable = showed);
	}
}
