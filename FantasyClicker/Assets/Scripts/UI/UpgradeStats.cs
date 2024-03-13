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

    public void UpgradeStat()
    {
        if (CheckEnoughGold() && CheckNotReachMaxLvl(statToUpgrade))
        {
            HeroesManager.instance.CurrentHero.UpgradeStat(statToUpgrade, upgradeValue);
            PlayerCoins.instance.DecreaseCoins(cost);
            statValue.text = HeroesManager.instance.CurrentHero.GetStatValue(statToUpgrade).ToString();
            EventManager.SendHeroStatsUpgraded(HeroesManager.instance.CurrentHero.HeroInfo);
        }

        DisablePurchaseBtnOnMaxLvl(true);

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
    }

    private bool CheckNotReachMaxLvl(StatToUpgrade stat) => HeroesManager.instance.CurrentHero.GetStatLvl(stat) < maxUpgradeLvl;

    private void DisablePurchaseBtnOnMaxLvl(bool showAd = false)
    {
        if (!CheckNotReachMaxLvl(statToUpgrade))
        {
            purchaseBtn.interactable = false;

            if (showAd)
            {
                YandexGame.FullscreenShow();
            }
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
