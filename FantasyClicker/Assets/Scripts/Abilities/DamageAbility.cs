using UnityEngine;

public class DamageAbility : MonoBehaviour, IAbility
{
    [SerializeField] private bool firstAbility;

    private void Awake()
    {
        MakeEffect();
    }

    public void MakeEffect()
    {
        EventManager.SendCharacterAttacked(firstAbility ? HeroesManager.instance.CurrentHero.BaseDamage * (3 + HeroesManager.instance.CurrentHero.HeroInfo.DamageLvl)
			: HeroesManager.instance.CurrentHero.BaseDamage * (6 + HeroesManager.instance.CurrentHero.HeroInfo.DamageLvl));
    }
}
