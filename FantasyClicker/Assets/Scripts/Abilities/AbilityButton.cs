using System.Collections;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class AbilityButton : MonoBehaviour
{
    [SerializeField] private Transform spawnPos;
    [SerializeField] private Image abilityImg;
    [SerializeField] private GameObject purchaseImg;
    [SerializeField] private Text costText;
    
    private AbilityData abilityData;

    private Button btn;

    private int showAdCounter = 0;

    private void Awake()
    {
        btn = GetComponent<Button>();

        EventManager.OnCharacterInstantiated.AddListener(SetAbilityData);
    } 

	private void OnEnable()
	{
        if (!btn.interactable)
        {
			StartCoroutine(UseCooldown());
		}
	}

	public void UseAbility()
    {
        if (CheckAbilityPurchased(abilityData))
        {
            Instantiate(abilityData.Ability, spawnPos.position, abilityData.Ability.transform.rotation, spawnPos);
            StartCoroutine(UseCooldown());
        }
        else
        {
            PurchaseAbility();
        }

        if (showAdCounter == 15)
        {
            YandexGame.FullscreenShow();
            showAdCounter = 0;
        }
    }

    private IEnumerator UseCooldown()
    {
        btn.interactable = false;
        yield return new WaitForSeconds(5);
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
        if (PlayerCoins.instance.Coins - abilityData.Cost >= 0)
        {
            abilityData.Purchased = true;
            EventManager.SendAbilityPurchased(abilityData);
            PlayerCoins.instance.DecreaseCoins(abilityData.Cost);
            purchaseImg.SetActive(false);
        }
    }

    private bool CheckAbilityCellOccupied(bool cell) => cell ? true : false;
}
