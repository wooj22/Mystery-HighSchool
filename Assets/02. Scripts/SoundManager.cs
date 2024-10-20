using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] AudioSource bgmSource;
    [SerializeField] AudioSource sfxSource;
    [SerializeField] List<AudioClip> bgmClip;
    [SerializeField] List<AudioClip> sfxClipList;
    [SerializeField] float fadeVolumeTime;

    /// ΩÃ±€≈Ê
    public static SoundManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    /// BGM
    public void PlayBGM(string clipName)
    {
        AudioClip clipToPlay = sfxClipList.Find(clip => clip.name == clipName);
        bgmSource.clip = clipToPlay;
        bgmSource.loop = true;
        bgmSource.volume = 0f;
        bgmSource.Play();
        StartCoroutine(FadeInVolume());
    }

    public void StopBGM()
    {
        StartCoroutine(FadeOutVolume());
    }

    /// SFX
    public void PlaySFX(string clipName)
    {
        AudioClip clipToPlay = sfxClipList.Find(clip => clip.name == clipName);
        sfxSource.PlayOneShot(clipToPlay);
    }

    public void StopSFX()
    {
        sfxSource.Stop();
    }

    /// ∫º∑˝ ∆‰¿ÃµÂ¿Œ
    private IEnumerator FadeInVolume()
    {
        float targetVolume = 1f;
        float currentTime = 0f;

        while (currentTime < fadeVolumeTime)
        {
            currentTime += Time.deltaTime;
            bgmSource.volume = Mathf.Lerp(0f, targetVolume, currentTime / fadeVolumeTime);
            yield return null;
        }

        bgmSource.volume = targetVolume;
    }

    /// ∫º∑˝ ∆‰¿ÃµÂæ∆øÙ
    private IEnumerator FadeOutVolume()
    {
        float startVolume = bgmSource.volume;
        float currentTime = 0f;

        while (currentTime < fadeVolumeTime)
        {
            currentTime += Time.deltaTime;
            bgmSource.volume = Mathf.Lerp(startVolume, 0f, currentTime / fadeVolumeTime);
            yield return null;
        }

        bgmSource.volume = 0f;
        bgmSource.Stop();
    }
}
