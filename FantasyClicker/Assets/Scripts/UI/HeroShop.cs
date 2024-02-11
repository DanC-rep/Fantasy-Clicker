using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class HeroShop : MonoBehaviour
{
    [SerializeField] private HeroData[] heroes;

    [SerializeField] private Image heroImg;
    [SerializeField] private Text damage;
    [SerializeField] private Text critDamage;
    [SerializeField] private Text critChance;

    [SerializeField] private Transform heroSpawnPoint;

    [SerializeField] private List<LocationData> locations;

    [SerializeField] private Button chooseHeroBtn;
    [SerializeField] private Button purchaseHeroBtn;

    [SerializeField] private Text heroCost;

    private int pageNum = 0;

    private GameObject currentHero;

    private void Awake()
    {
        currentHero = HeroesManager.instance.CurrentHero.gameObject;
        SetHeroData();
    }

    public void NextPage()
    {
        if (pageNum < heroes.Length - 1)
        {
            pageNum += 1;

            SetHeroData();
            SetCanPurchaseHero();
        }
    }

    public void PrevPage()
    {
        if (pageNum > 0)
        {
            pageNum -= 1;

            SetHeroData();
            SetCanPurchaseHero();
        }
    }

    public void PurchaseHero()
    {
		if (PlayerCoins.instance.CheckEnoughCoins(heroes[pageNum].Cost))
		{
			PlayerCoins.instance.DecreaseCoins(heroes[pageNum].Cost);
			heroes[pageNum].Purchased = true;

            ChooseHero();
            SetBtnToTakeHero();
		}
	}

    public void ChooseHero()
    {
		if (currentHero != null)
		{
			Destroy(currentHero);
		}

		currentHero = Instantiate(heroes[pageNum].Hero, heroSpawnPoint.position, heroes[pageNum].Hero.transform.rotation, heroSpawnPoint);
    }

    private void SetHeroData()
    {
        CharacterStats stats = heroes[pageNum].Hero.GetComponent<CharacterStats>();

        heroImg.sprite = heroes[pageNum].Icon;
        damage.text = stats.Damage.ToString();
        critDamage.text = stats.CritDamage.ToString();
        critChance.text = stats.CritChance.ToString();

        SetBtnToTakeHero();
    }

    private bool CheckUnlockedHero() => locations.Contains(heroes[pageNum].UnlockLocation) ? true : false;
    private void SetCanPurchaseHero() => purchaseHeroBtn.interactable = CheckUnlockedHero() ? true : false;

    private void SetBtnToTakeHero()
    {
        if (heroes[pageNum].Purchased)
        {
			purchaseHeroBtn.gameObject.SetActive(false);
			chooseHeroBtn.gameObject.SetActive(true);
        }
        else
        {
            chooseHeroBtn.gameObject.SetActive(false);
            purchaseHeroBtn.gameObject.SetActive(true);
            heroCost.text = heroes[pageNum].Cost.ToString();
        }
    }
}
