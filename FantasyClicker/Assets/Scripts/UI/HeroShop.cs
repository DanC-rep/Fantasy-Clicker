using UnityEngine;
using UnityEngine.UI;

public class HeroShop : MonoBehaviour
{
    [SerializeField] private HeroData[] heroes;

    [SerializeField] private Image heroImg;
    [SerializeField] private Text damage;
    [SerializeField] private Text critDamage;
    [SerializeField] private Text critChance;

    [SerializeField] private Transform heroSpawnPoint;

    private int pageNum = 0;

    private GameObject currentHero;

    private void Awake()
    {
        currentHero = HeroesManager.instance.CurrentHero.gameObject;
        SetHeroData();
    }

    public void NextPage()
    {
        if (pageNum < heroes.Length - 1)
        {
            pageNum += 1;

            SetHeroData();

        }
    }

    public void PrevPage()
    {
        if (pageNum > 0)
        {
            pageNum -= 1;

            SetHeroData();
        }
    }

    public void ChooseHero()
    {
        if (currentHero != null)
        {
            Destroy(currentHero);
        }

        currentHero = Instantiate(heroes[pageNum].Hero, heroSpawnPoint.position, heroes[pageNum].Hero.transform.rotation, heroSpawnPoint);
    }

    private void SetHeroData()
    {
        CharacterStats stats = heroes[pageNum].Hero.GetComponent<CharacterStats>();

        heroImg.sprite = heroes[pageNum].Icon;
        damage.text = stats.Damage.ToString();
        critDamage.text = stats.CritDamage.ToString();
        critChance.text = stats.CritChance.ToString();
    }
}
