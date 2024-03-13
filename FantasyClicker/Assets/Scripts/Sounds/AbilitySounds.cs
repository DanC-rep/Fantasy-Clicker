public class AbilitySounds : Sound
{
	private void Start()
	{
		if (SoundMode.instance.Muted)
		{
			sound.mute = true;
		}
	}

	private void Update()
	{
		if (!sound.isPlaying)
		{
			Destroy(gameObject);
		}
		
	}
}
