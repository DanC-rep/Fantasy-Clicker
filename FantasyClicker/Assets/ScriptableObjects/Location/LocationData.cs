using UnityEngine;

[CreateAssetMenu(fileName = "New Location", menuName = "Location")]
public class LocationData : ScriptableObject
{
    [SerializeField] private string sceneName;
    [SerializeField] private Sprite image;
    [SerializeField] private int cost;
    [SerializeField] private string[] bonuses;
    [SerializeField] private bool purchased;

    [SerializeField] private int moneyModifier;
    [SerializeField] private GameObject[] unlockedEnemies;
    [SerializeField] private GameObject[] unlockedHeroes;

    public string SceneName => sceneName;
    public Sprite Image => image; 
    public int Cost => cost;
    public string[] Bonuses => bonuses;
    public bool Purchased { get => purchased; set => purchased = value; }

    public int MoneyModifier => moneyModifier;
    public GameObject[] UnlockedEnemies => unlockedEnemies;
    public GameObject[] UnlockedHeroes => unlockedHeroes;
}
