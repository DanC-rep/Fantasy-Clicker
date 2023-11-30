using UnityEngine;

public class EnemyStats : MonoBehaviour, IEnemyInfo
{
    [SerializeField] private int maxHealth;
    [SerializeField] private new string name;
    [SerializeField] private int reward;

    private int health;

    public string Name => name;
    public int Health => health;
    public int MaxHealth => maxHealth;
    public int Reward => reward;

    private void Awake()
    {
        health = maxHealth;
    }

    public void DecreaseHealth(int damage)
    {
        health -= damage;
    }
}
