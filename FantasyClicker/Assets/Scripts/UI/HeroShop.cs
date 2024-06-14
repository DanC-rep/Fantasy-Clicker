using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using YG;

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

    private IEnumerable<LocationData> unlockedLocations;

    private void Awake()
    {
        currentHero = HeroesManager.instance.CurrentHero.gameObject;
    }

	private void OnEnable()
	{
		SetUnlockedHeroes();
		SetHeroData();
	}

    private void SetUnlockedHeroes()
    {
        unlockedLocations = locations.Where(l => l.Purchased);
    }

	public void NextPage()
    {
        if (pageNum < heroes.Length - 1)
        {
            pageNum += 1;

            SetHeroData();
            SetCanPurchaseHero();
        }

		EventManager.SendUiClicked();
	}

    public void PrevPage()
    {
        if (pageNum > 0)
        {
            pageNum -= 1;

            SetHeroData();
            SetCanPurchaseHero();
		}

		EventManager.SendUiClicked();
	}

    public void PurchaseHero()
    {
		if (PlayerCoins.instance.CheckEnoughCoins(heroes[pageNum].Cost))
		{
			PlayerCoins.instance.DecreaseCoins(heroes[pageNum].Cost);
			heroes[pageNum].Purchased = true;
            EventManager.SendHeroPurchased(heroes[pageNum]);

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

		EventManager.SendUiClicked();
	}

    private void SetHeroData()
    {

        heroImg.sprite = heroes[pageNum].Icon;
        damage.text = heroes[pageNum].Damage.ToString();
        critDamage.text = heroes[pageNum].CritDamage.ToString();
        critChance.text = heroes[pageNum].CritChance.ToString();

        SetBtnToTakeHero();
    }

    private bool CheckUnlockedHero() => unlockedLocations.Contains(heroes[pageNum].UnlockLocation) ? true : false;
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
