using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class AbilityButton : MonoBehaviour
{
    [SerializeField] private Transform spawnPos;
    [SerializeField] private Image abilityImg;
    [SerializeField] private GameObject purchaseImg;
    [SerializeField] private Text costText;
    
    private AbilityData abilityData;

    private Button btn;

    private void Awake()
    {
        btn = GetComponent<Button>();

        EventManager.OnCharacterInstantiated.AddListener(SetAbilityData);
    }

    public void UseAbility()
    {
        if (CheckAbilityPurchased(abilityData))
        {
            Instantiate(abilityData.Ability, spawnPos.position, abilityData.Ability.transform.rotation, spawnPos);
            UseCooldown();
        }
        else
        {
            PurchaseAbility();
        }
    }

    private async void UseCooldown()
    {
        btn.interactable = false;
        await Task.Delay(2000);
        btn.interactable = true;
    }

    private void SetAbilityData(CharacterStats stats)
    {

        if (CheckAbilityCellOccupied(stats.AbilityCell1Occupied))
        {
            abilityData = stats.Abilities[1];
            abilityImg.sprite = abilityData.Icon;
            stats.AbilityCell2Occupied = true;
        }
        else
        {
            abilityData = stats.Abilities[0];
            abilityImg.sprite = abilityData.Icon;
            stats.AbilityCell1Occupied = true;
        }

        if (!CheckAbilityPurchased(abilityData))
        {
            purchaseImg.SetActive(true);
            costText.text = abilityData.Cost.ToString();
        }
        else
        {
            purchaseImg.SetActive(false);
        }
    }

    private bool CheckAbilityPurchased(AbilityData ability) => ability.Purchased ? true : false;

    private void PurchaseAbility()
    {
        if (HeroesManager.instance.CurrentHero.Coins - abilityData.Cost >= 0)
        {
            abilityData.Purchased = true;
            HeroesManager.instance.CurrentHero.DecreaseCoins(abilityData.Cost);
            purchaseImg.SetActive(false);
        }
    }

    private bool CheckAbilityCellOccupied(bool cell) => cell ? true : false;
}
