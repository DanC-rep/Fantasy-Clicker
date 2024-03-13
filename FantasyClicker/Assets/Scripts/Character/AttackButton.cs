using UnityEngine;
using UnityEngine.UI;

public class AttackButton : MonoBehaviour
{
	private Button btn;

	private void Awake()
	{
		btn = GetComponent<Button>();
		EventManager.OnCharacterInstantiated.AddListener(AddAttackHandler);
	}

	private void AddAttackHandler(CharacterStats stats)
	{
		btn.onClick.RemoveAllListeners();
		btn.onClick.AddListener(() => stats.GetComponent<InputController>().ReadAttack());
	}
}
