using UnityEngine;
using UnityEngine.EventSystems;

public class InputController : MonoBehaviour
{
    private IAttacker attacker;

    private void Awake()
    {
        attacker = GetComponent<IAttacker>();
    }

    private void ReadAttack()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            attacker.Attack();
        }
    }

    private void Update()
    {
        ReadAttack();
    }
}

