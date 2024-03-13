using UnityEngine;

public class Sound : MonoBehaviour
{
    protected AudioSource sound;

	protected virtual void Awake()
	{
		EventManager.OnSoundModeChanged.AddListener(ChangeSoundMode);
		sound = GetComponent<AudioSource>();
	}

	public virtual void Play()
    {
        sound.Play();
    }

	private void ChangeSoundMode(bool mode) => sound.mute = mode;
}
