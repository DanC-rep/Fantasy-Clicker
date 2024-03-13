using UnityEngine;
using UnityEngine.EventSystems;
using YG;

public class InputController : MonoBehaviour
{
    private IAttacker attacker;

    private bool canInputAttack = true;

    private void Awake()
    {
		EventManager.OnTutorialShowed.AddListener(EnableCanInputAttack);

		attacker = GetComponent<IAttacker>();
    }


	public void ReadAttack()
    {
        if (!canInputAttack)
        {
            return;
        }

        attacker.Attack();
    }

    private void EnableCanInputAttack(bool showed)
    {
        canInputAttack = showed;
	}
}

