using UnityEngine;
using UnityEngine.UI;

public class UpgradeStats : MonoBehaviour
{
    [SerializeField] private StatToUpgrade statToUpgrade;
    [SerializeField] private Text costText;
    [SerializeField] private int cost;
    [SerializeField] private int upgradeValue;
    [SerializeField] private int maxUpgradeLvl;
    [SerializeField] private Text statValue;
    [SerializeField] private Button purchaseBtn;

    private void Awake()
    {
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
        }

        DisablePurchaseBtnOnMaxLvl();
    }

    private bool CheckEnoughGold()
    {
        return PlayerCoins.instance.Coins >= cost;
    }

    private void OnEnable()
    {
        statValue.text = HeroesManager.instance.CurrentHero.GetStatValue(statToUpgrade).ToString();
    }

    private bool CheckNotReachMaxLvl(StatToUpgrade stat) => HeroesManager.instance.CurrentHero.GetStatLvl(stat) < maxUpgradeLvl;

    private void DisablePurchaseBtnOnMaxLvl()
    {
        if (!CheckNotReachMaxLvl(statToUpgrade))
        {
            purchaseBtn.interactable = false;
        }
    }

}

public enum StatToUpgrade
{
    Damage,
    CritDamage,
    CritChance
}
