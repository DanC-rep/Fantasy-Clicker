using UnityEngine;

public abstract class Bonus : MonoBehaviour
{
    [SerializeField] private int speed;

    private Transform bonusDestroyPoint;

    private void Awake()
    {
        bonusDestroyPoint = GameObject.FindGameObjectWithTag("BonusDestroyPoint").transform;
    }

    private void Update()
    {
        if (transform.position.y < bonusDestroyPoint.position.y)
        {
            Destroy(gameObject);
            EventManager.SendBonusDestroyed();
        }
        else
        {
            transform.Translate(Vector2.down * speed * Time.deltaTime);
        }
    }

    protected abstract void Use();
}
