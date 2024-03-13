using System.Diagnostics.Tracing;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfo : MonoBehaviour
{
    [SerializeField] private Text money;
    [SerializeField] private Image playerIcon;

    private void Awake()
    {
        EventManager.OnCharacterCoinsChanged.AddListener(SetPlayerCoins);
        EventManager.OnCharacterInstantiated.AddListener(ChangePlayerIcon);
    }

	private void Start()
	{
		SetPlayerCoins();
	}

	private void SetPlayerCoins()
    {
        money.text = PlayerCoins.instance.Coins.ToString();
    }

    private void ChangePlayerIcon(CharacterStats stats)
    {
        playerIcon.sprite = stats.HeroInfo.Icon;
    }
}
