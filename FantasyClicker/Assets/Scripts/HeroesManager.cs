using UnityEngine;

public class HeroesManager : MonoBehaviour
{
    public static HeroesManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;
    }

    [SerializeField] private GameObject hero;
    [SerializeField] private Transform heroSpawnPoint;

    private CharacterStats currentHero;
    public CharacterStats CurrentHero => currentHero;

    private void Start()
    {
        currentHero = Instantiate(hero, heroSpawnPoint.position, hero.transform.rotation, heroSpawnPoint).GetComponent<CharacterStats>();
        EventManager.OnCharacterInstantiated.AddListener(ChangeCurrentHero);
    }

    private void ChangeCurrentHero(CharacterStats stats)
    {
        currentHero = stats;
    }
}
