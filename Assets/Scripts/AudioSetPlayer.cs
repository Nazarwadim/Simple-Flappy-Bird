using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting;
using Unity.VisualScripting;

public class AudioSetPlayer : MonoBehaviour
{
    [SerializeField] private RandomSoundSet[] _soundCollection;

    private Dictionary<string, RandomSoundSet> _soundCollectionCache;
    private Dictionary<string, AudioSource> _audioSources;
    private GameObject _audioSourcesObject;

    private void Awake()
    {
        _soundCollectionCache = new();
        _audioSources = new();
        _audioSourcesObject = new();
        _audioSourcesObject.transform.SetParent(transform);
        _audioSourcesObject.name = "AudioSources";

        foreach (RandomSoundSet randomSoundSet in _soundCollection)
        {
            _soundCollectionCache.Add(randomSoundSet.Name, randomSoundSet);
        }

        foreach (RandomSoundSet randomSoundSet in _soundCollection)
        {
            _audioSources.Add(randomSoundSet.Name, _audioSourcesObject.AddComponent<AudioSource>());
        }
    }

    public void PlayRandomSoundFromSet(string soundSetName)
    {
        _soundCollectionCache.TryGetValue(soundSetName, out RandomSoundSet soundCollection);
        _audioSources.TryGetValue(soundSetName, out AudioSource audioSource);

        if (soundCollection != null)
        {
            AudioClip clip = soundCollection.GetRandomClip();
            if (clip != null)
            {
                audioSource.clip = clip;
                audioSource.Play();
            }
        }
        else
        {
            Debug.LogWarning("Can`t find sound collection by name");
        }

    }

    public AudioSource GetAudioSource(string soundSetName)
    {
        _audioSources.TryGetValue(soundSetName, out AudioSource audioSource);
        if (audioSource != null)
        {
            return audioSource;
        }
        Debug.LogWarning("Can`t find sound by name");
        return null;
    }
}
