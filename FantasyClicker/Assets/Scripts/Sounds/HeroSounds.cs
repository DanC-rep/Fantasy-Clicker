public class HeroSounds : Sound
{
	private void Start()
	{
		if (SoundMode.instance.Muted)
		{
			sound.mute = true;
		}
	}

	public override void Play()
	{
		if (sound.isPlaying)
		{
			return;
		}

		sound.Play();
	}
}
