public class ClickSound : Sound
{
	protected override void Awake()
	{
		base.Awake();

		EventManager.OnUiClicked.AddListener(Play);
	}
}
