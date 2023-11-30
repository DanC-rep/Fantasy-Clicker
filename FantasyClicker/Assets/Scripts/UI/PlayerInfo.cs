using UnityEngine;
using UnityEngine.UI;

public class PlayerInfo : MonoBehaviour
{
    [SerializeField] private CharacterStats playerStats;
    [SerializeField] private Text money;

    private void Update()
    {
        money.text = playerStats.Coins.ToString();
    }

    // Изменить работу с монетами, когда игрок будет создаваться через Instantiate, работа будет происходить через события
}
