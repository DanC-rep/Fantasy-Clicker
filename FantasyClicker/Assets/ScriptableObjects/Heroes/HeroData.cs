using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

[CreateAssetMenu(fileName = "New Hero", menuName = "Hero")]
public class HeroData : ScriptableObject, IPurchaseable
{
    [SerializeField] private int id;
    [SerializeField] private int cost;
    [SerializeField] private Sprite icon;
    [SerializeField] private GameObject hero;
    [SerializeField] private LocationData unlockLocation;
    [SerializeField] private bool purchased;

    [SerializeField] private int damage;
    [SerializeField] private int critChance;
    [SerializeField] private int critDamage;

    // после тестов убрать serializefield

	[SerializeField] private int damageLvl;
	[SerializeField] private int critDamageLvl;
	[SerializeField] private int critChanceLvl;

    public int Id => id;
	public int Cost => cost;
    public Sprite Icon => icon;
    public GameObject Hero => hero;
    public LocationData UnlockLocation => unlockLocation;
    public bool Purchased { get => purchased; set => purchased = value; }

    public int Damage { get => damage; set => damage = value; }
    public int CritChance { get => critChance; set => critChance = value; }
    public int CritDamage { get => critDamage; set => critDamage = value; }

    public int DamageLvl { get => damageLvl; set => damageLvl = value; }
	public int CritChanceLvl { get => critChanceLvl; set => critChanceLvl = value; }
	public int CritDamageLvl { get => critDamageLvl; set => critDamageLvl = value; }
}
