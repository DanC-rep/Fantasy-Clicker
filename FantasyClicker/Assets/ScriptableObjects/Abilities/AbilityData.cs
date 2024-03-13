using UnityEngine;

[CreateAssetMenu(fileName = "New Ability", menuName = "Ability")]
public class AbilityData : ScriptableObject, IPurchaseable
{
    [SerializeField] private int id;
    [SerializeField] private int cost;
    [SerializeField] private Sprite icon;
    [SerializeField] private GameObject ability;
    [SerializeField] private bool purchased;

    public int Id => id;
    public int Cost => cost;
    public Sprite Icon => icon;
    public GameObject Ability => ability;
    public bool Purchased { get => purchased; set => purchased = value; }
}
