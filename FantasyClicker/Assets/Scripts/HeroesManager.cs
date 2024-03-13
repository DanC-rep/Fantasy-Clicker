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

    public GameObject Hero { get; set; }
    [SerializeField] private Transform heroSpawnPoint;

    private CharacterStats currentHero;
    public CharacterStats CurrentHero => currentHero;

    private void Start()
    {
        EventManager.OnCharacterInstantiated.AddListener(ChangeCurrentHero);
    }

    public void InstantiateHero()
    {
		currentHero = Instantiate(Hero, heroSpawnPoint.position, Hero.transform.rotation, heroSpawnPoint).GetComponent<CharacterStats>();
	}

    private void ChangeCurrentHero(CharacterStats stats)
    {
        currentHero = stats;
    }
}
