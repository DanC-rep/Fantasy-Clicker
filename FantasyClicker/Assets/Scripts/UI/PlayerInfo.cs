using UnityEngine;
using UnityEngine.UI;

public class PlayerInfo : MonoBehaviour
{
    [SerializeField] private Text money;

    private void Awake()
    {
        EventManager.OnCharacterInstantiated.AddListener(SetPlayerCoins);
        EventManager.OnCharacterCoinsChanged.AddListener(SetPlayerCoins);
    }

    private void SetPlayerCoins(CharacterStats stats)
    {
        money.text = stats.Coins.ToString();
    }
}
