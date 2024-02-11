public class DoubleDamageBonus : Bonus
{
    private void OnMouseDown()
    {
        Use();
    }

    protected override void Use()
    {
        HeroesManager.instance.CurrentHero.DoubleDamage();
        EventManager.SendBonusDestroyed();
        Destroy(gameObject);
    }
}
