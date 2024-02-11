using UnityEngine;

[CreateAssetMenu(fileName = "New Hero", menuName = "Hero")]
public class HeroData : ScriptableObject
{
    [SerializeField] private int cost;
    [SerializeField] private Sprite icon;
    [SerializeField] private GameObject hero;
    [SerializeField] private LocationData unlockLocation;
    [SerializeField] private bool purchased;

    public int Cost => cost;
    public Sprite Icon => icon;
    public GameObject Hero => hero;
    public LocationData UnlockLocation => unlockLocation;
    public bool Purchased { get => purchased; set => purchased = value; }
}
