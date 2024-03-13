using UnityEngine.Jobs;

public interface IEnemyInfo 
{
    int Health { get; }
    int MaxHealth { get; }
    string Name { get; }
    int KillCount { get; }
    int Id { get; }

    int AddKillCount();
    void SetKillCount(int value);
}
