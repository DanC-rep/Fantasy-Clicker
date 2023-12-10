using UnityEngine;

[CreateAssetMenu(fileName = "New Location", menuName = "Location")]
public class LocationData : ScriptableObject
{
    [SerializeField] private string sceneName;
    [SerializeField] private Sprite image;
    [SerializeField] private int cost;
    [SerializeField] private string[] bonuses;

    public string SceneName => sceneName;
    public Sprite Image => image;
    public int Cost => cost;
    public string[] Bonuses => bonuses;
}
