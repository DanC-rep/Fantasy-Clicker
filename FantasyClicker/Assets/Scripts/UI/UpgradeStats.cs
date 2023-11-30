using UnityEngine;
using UnityEngine.UI;

public class UpgradeStats : MonoBehaviour
{
    [SerializeField] private StatToUpgrade statToUpgrade;
    [SerializeField] private CharacterStats characterStats;
    [SerializeField] private Text costText;
    [SerializeField] private int cost;
    [SerializeField] private int upgradeValue;
    [SerializeField] private Text statValue;

    private void Awake()
    {
        costText.text = cost.ToString();
        statValue.text = characterStats.GetStatValue(statToUpgrade).ToString();
    }

    public void UpgradeStat()
    {
        if (CheckEnoughGold())
        {
            characterStats.UpgradeStat(statToUpgrade, upgradeValue);
            characterStats.DecreaseCoins(cost);
            statValue.text = characterStats.GetStatValue(statToUpgrade).ToString();
        }
    }

    private bool CheckEnoughGold()
    {
        return characterStats.Coins >= cost;
    }

}

public enum StatToUpgrade
{
    Damage,
    CritDamage,
    CritChance
}
