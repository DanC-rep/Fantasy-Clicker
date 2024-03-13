using UnityEngine;
using UnityEngine.UI;

public abstract class Stat : MonoBehaviour
{
    [SerializeField] protected Text countText;

    public abstract void SaveValue();
    public abstract void GetValue();
}
