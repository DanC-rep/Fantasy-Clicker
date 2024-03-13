using UnityEngine;

public class EnemyStats : MonoBehaviour, IEnemyInfo
{
    [SerializeField] private int maxHealth;
    [SerializeField] private new string name;
    [SerializeField] private int reward;
    [SerializeField] private int killCount;
    [SerializeField] private int id;

    private int health;

    public string Name { get => name; set => name = value; }
    public int Health => health;
    public int MaxHealth => maxHealth;
    public int Reward => reward;
    public int KillCount => killCount;
    public int Id => id;

    private void Awake()
    {
        health = maxHealth;
    }

    public void DecreaseHealth(int damage)
    {
        health -= damage;
    }

    public int AddKillCount()
    {
        killCount+= 1;
        EventManager.SendEnemyKillCountChanged(this);
        return killCount;
    }

    public void SetKillCount(int value)
    {
        killCount = value;
    }
}
