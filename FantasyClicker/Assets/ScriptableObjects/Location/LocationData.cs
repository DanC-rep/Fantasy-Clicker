using UnityEngine;

[CreateAssetMenu(fileName = "New Location", menuName = "Location")]
public class LocationData : ScriptableObject, IPurchaseable
{
    [SerializeField] private int id;
    [SerializeField] private string sceneName;
    [SerializeField] private Sprite image;
    [SerializeField] private int cost;
    [SerializeField] private string[] bonuses;
    [SerializeField] private bool purchased;
    [SerializeField] private LocationData unlockLocation;

    [SerializeField] private int moneyModifier;
    [SerializeField] private GameObject[] unlockedEnemies;

    public int Id => id;
    public string SceneName => sceneName;
    public Sprite Image => image; 
    public int Cost => cost;
    public string[] Bonuses { get => bonuses; set => bonuses = value; }
    public bool Purchased { get => purchased; set => purchased = value; }
    public LocationData UnlockLocation => unlockLocation;

    public int MoneyModifier => moneyModifier;
    public GameObject[] UnlockedEnemies => unlockedEnemies;
}
