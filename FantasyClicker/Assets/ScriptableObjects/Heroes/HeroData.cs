using UnityEngine;

[CreateAssetMenu(fileName = "New Hero", menuName = "Hero")]
public class HeroData : ScriptableObject
{
    [SerializeField] private int cost;
    [SerializeField] private Sprite icon;
    [SerializeField] private GameObject hero;

    public int Cost => cost;
    public Sprite Icon => icon;
    public GameObject Hero => hero;
}
