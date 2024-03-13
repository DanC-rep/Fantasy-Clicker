public class DoubleDamageBonus : Bonus
{
    private void OnMouseDown()
    {
        Use();
    }

    protected override void Use()
    {
        HeroesManager.instance.CurrentHero.StartDoubleDamage();
        EventManager.SendBonusDestroyed();
        Destroy(gameObject);
    }
}
