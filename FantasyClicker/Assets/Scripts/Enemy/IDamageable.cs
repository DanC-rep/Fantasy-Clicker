public interface IDamageable
{
    void TakeDamage(int damage);
    void Death();

    bool CanBeDamaged { get; }
}
