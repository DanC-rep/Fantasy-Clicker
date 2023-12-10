using UnityEngine;
using UnityEngine.UI;

public class UpgradeStats : MonoBehaviour
{
    [SerializeField] private StatToUpgrade statToUpgrade;
    [SerializeField] private Text costText;
    [SerializeField] private int cost;
    [SerializeField] private int upgradeValue;
    [SerializeField] private Text statValue;

    private void Awake()
    {
        costText.text = cost.ToString();
        statValue.text = HeroesManager.instance.CurrentHero.GetStatValue(statToUpgrade).ToString();
    }

    public void UpgradeStat()
    {
        if (CheckEnoughGold())
        {
            HeroesManager.instance.CurrentHero.UpgradeStat(statToUpgrade, upgradeValue);
            HeroesManager.instance.CurrentHero.DecreaseCoins(cost);
            statValue.text = HeroesManager.instance.CurrentHero.GetStatValue(statToUpgrade).ToString();
        }
    }

    private bool CheckEnoughGold()
    {
        return HeroesManager.instance.CurrentHero.Coins >= cost;
    }

    private void OnEnable()
    {
        statValue.text = HeroesManager.instance.CurrentHero.GetStatValue(statToUpgrade).ToString();
    }

}

public enum StatToUpgrade
{
    Damage,
    CritDamage,
    CritChance
}
