using UnityEngine;
using UnityEngine.UI;
using YG;

public class UpgradeStats : MonoBehaviour
{
    [SerializeField] private StatToUpgrade statToUpgrade;
    [SerializeField] private Text costText;
    private int cost;
    [SerializeField] private int upgradeValue;
    [SerializeField] private int maxUpgradeLvl;
    [SerializeField] private Text statValue;
    [SerializeField] private Button purchaseBtn;

    public Button RewardBtn;

    private void Awake()
    {
        if (HeroesManager.instance.CurrentHero.HeroInfo.Cost == 0)
        {
			cost = 15;
		}
        else
        {
			cost = HeroesManager.instance.CurrentHero.HeroInfo.Cost / 10;
		}
        costText.text = cost.ToString();
        statValue.text = HeroesManager.instance.CurrentHero.GetStatValue(statToUpgrade).ToString();
    }

    public void UpgradeStat(bool adShowed = false)
    {
        if ((CheckEnoughGold() || adShowed) && CheckNotReachMaxLvl())
        {
            HeroesManager.instance.CurrentHero.UpgradeStat(statToUpgrade, upgradeValue);
            if (!adShowed)
            {
				PlayerCoins.instance.DecreaseCoins(cost);
			}
            statValue.text = HeroesManager.instance.CurrentHero.GetStatValue(statToUpgrade).ToString();
            EventManager.SendHeroStatsUpgraded(HeroesManager.instance.CurrentHero.HeroInfo);
        }

        DisablePurchaseBtnOnMaxLvl();

		EventManager.SendUiClicked();
	}

    private bool CheckEnoughGold()
    {
        return PlayerCoins.instance.Coins >= cost;
    }

    private void OnEnable()
    {
		if (HeroesManager.instance.CurrentHero.HeroInfo.Cost == 0)
		{
			cost = 15;
		}
		else
		{
			cost = HeroesManager.instance.CurrentHero.HeroInfo.Cost / 10;
		}
		costText.text = cost.ToString();

		statValue.text = HeroesManager.instance.CurrentHero.GetStatValue(statToUpgrade).ToString();

        DisablePurchaseBtnOnMaxLvl();

        if (!RewardBtn.interactable && RewardBtn.GetComponent<RewardStatBtn>().CanInteract && CheckNotReachMaxLvl())
        {
            RewardBtn.interactable = true;
        }
    }

    public bool CheckNotReachMaxLvl() => HeroesManager.instance.CurrentHero.GetStatLvl(statToUpgrade) < maxUpgradeLvl;

    private void DisablePurchaseBtnOnMaxLvl()
    {
        if (!CheckNotReachMaxLvl())
        {
            purchaseBtn.interactable = false;
            RewardBtn.interactable = false;
        }
        else
        {
            purchaseBtn.interactable = true;
        }
    }

}

public enum StatToUpgrade
{
    Damage,
    CritDamage,
    CritChance
}
