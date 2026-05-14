using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class AudioPlayer : Installer
{
    private const string SoundsPath = "Sounds";

    [SerializeField] private AudioSourcePool _soundAudioSourcePool;
    [SerializeField] private AudioSourcePool _musicAudioSourcePool;

    private static AudioPlayer _instance;

    private Dictionary<AudioKeys.Sound, AudioClip> _sounds = new();
    private Dictionary<AudioKeys.Music, AudioClip> _music = new();

    protected override void Install()
    {
        if (_instance != null)
        {
            Debug.LogError($"Multiple instances of {nameof(AudioPlayer)} detected. Leaving the last instantiated one.");
            Destroy(_instance.gameObject);
        }

        _instance = this;

        _instance.gameObject.name = nameof(AudioPlayer);
    }

    public static void PlaySoundEffect(SoundEffect soundEffect)
    {
        _instance.PlaySoundEffectInternal(soundEffect).Forget();
    }

    private async UniTaskVoid PlaySoundEffectInternal(SoundEffect soundEffect)
    {
        AudioSource audioSource = _soundAudioSourcePool.Get();
        audioSource.pitch = Random.Range(soundEffect.PitchRange.x, soundEffect.PitchRange.y);
        audioSource.transform.position = soundEffect.Position;
        audioSource.spatialBlend = 1f;
        audioSource.minDistance = 4f;
        audioSource.PlayOneShot(GetClip(soundEffect.SoundKey));

        await UniTask.WaitWhile(() => audioSource != null && audioSource.isPlaying);

        if (audioSource != null)
            _soundAudioSourcePool.Release(audioSource);
    }

    private AudioClip GetClip(AudioKeys.Sound key)
    {
        if (_sounds.TryGetValue(key, out AudioClip clip) == false)
        {
            clip = Resources.Load<AudioClip>($"{SoundsPath}/{key}");
            _sounds[key] = clip;
        }

        return clip;
    }
}