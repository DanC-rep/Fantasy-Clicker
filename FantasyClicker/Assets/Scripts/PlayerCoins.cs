using System.Collections;
using System.Threading.Tasks;
using UnityEngine;

public class PlayerCoins : MonoBehaviour
{
    public static PlayerCoins instance;

    [SerializeField] private LocationData location;
    [SerializeField] private SaveData saveData;
    private Leaderboard leaderboard;

    private int coins;
    public int Coins => coins;

    private bool doubleCoins;
    private bool doubleCoinsReward;

	private void Awake()
	{
		if (instance != null)
		{
			return;
		}
		instance = this;

        leaderboard = GetComponent<Leaderboard>();

		EventManager.OnCharacterRewarded.AddListener(AddCoins);
	}

	private void AddCoins(int reward)
    {
        int value = doubleCoins ? reward * 2 * location.MoneyModifier : reward * location.MoneyModifier;
        int rewardValue = doubleCoinsReward ? reward * location.MoneyModifier : 0;
		coins += value + rewardValue;

        EventManager.SendCharacterCoinsChanged();
        Statistic.instance.UpdateSimpleStat(SimpleStatEn.Coins, value);
        saveData.SaveTotalCoins(value);
        leaderboard.AddRecord();
    }

    public void DecreaseCoins(int value)
    {
        coins -= value;
        EventManager.SendCharacterCoinsChanged();
    }

    public void SetCoins(int value)
    {
        coins = value;
        EventManager.SendCharacterCoinsChanged();
    }

    public bool CheckEnoughCoins(int value) => coins - value >= 0;

    private IEnumerator DoubleCoins()
    {
        doubleCoins = true;
        yield return new WaitForSeconds(5);
        doubleCoins = false;
    }

    private IEnumerator DoubleCoinsReward()
    {
        doubleCoinsReward = true;
        yield return new WaitForSeconds(60);
        doubleCoinsReward = false;
    }

    public void StartDoubleCoins()
    {
        StartCoroutine(DoubleCoins());
    }

    public void StartDoubleCoinsReward()
    {
        StartCoroutine(DoubleCoinsReward());
    }
}
