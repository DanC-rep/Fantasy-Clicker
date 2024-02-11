using System.Threading.Tasks;
using UnityEngine;

public class PlayerCoins : MonoBehaviour
{
    public static PlayerCoins instance;

    [SerializeField] private LocationData location;

    private int coins;
    public int Coins => coins;

    private bool doubleCoins;

	private void Awake()
	{
		if (instance != null)
		{
			return;
		}
		instance = this;

		EventManager.OnCharacterRewarded.AddListener(AddCoins);
	}

	private void AddCoins(int reward)
    {
        coins += doubleCoins ? reward * 2 * location.MoneyModifier : reward * location.MoneyModifier;
        EventManager.SendCharacterCoinsChanged();
    }

    public void DecreaseCoins(int value)
    {
        coins -= value;
        EventManager.SendCharacterCoinsChanged();
    }

    public bool CheckEnoughCoins(int value) => coins - value >= 0;

    public async void DoubleCoins()
    {
        doubleCoins = true;
        await Task.Delay(5000);
        doubleCoins = false;
    }
}
