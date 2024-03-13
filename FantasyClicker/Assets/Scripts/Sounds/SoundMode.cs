using UnityEngine;
using UnityEngine.UI;

public class SoundMode : MonoBehaviour
{
    [SerializeField] private Sprite turnOn;
    [SerializeField] private Sprite turnOff;

	public static SoundMode instance;

	private void Awake()
	{
		if (instance != null)
		{
			return;
		}
		instance = this;

		icon = GetComponent<Image>();
	}

	private Image icon;

    private bool muted;
	public bool Muted => muted;

    public void SetSoundMode()
    {
        muted = !muted;
		SetSoundUiState();
        EventManager.SendSoundModeChanged(muted);
        EventManager.SendUiClicked();
    }

	public void SetSoundMode(bool _muted)
	{
		muted = _muted;
		SetSoundUiState();
		EventManager.SendSoundModeChanged(muted);
	}

	private void SetSoundUiState() => icon.sprite = muted ? turnOff : turnOn;
}
