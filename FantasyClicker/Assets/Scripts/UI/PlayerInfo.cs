using UnityEngine;
using UnityEngine.UI;

public class PlayerInfo : MonoBehaviour
{
    [SerializeField] private Text money;

    private void Awake()
    {
        EventManager.OnCharacterCoinsChanged.AddListener(SetPlayerCoins);
    }

	private void Start()
	{
		SetPlayerCoins();
	}

	private void SetPlayerCoins()
    {
        money.text = PlayerCoins.instance.Coins.ToString();
    }
}
