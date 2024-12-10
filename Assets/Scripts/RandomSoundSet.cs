using UnityEngine;

[CreateAssetMenu(fileName = "RandomSoundSet", menuName = "ScriptableObjects/RandomSoundSet", order = 1)]

public class RandomSoundSet : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private AudioClip[] _audioClips;

    public string Name => _name;
    public AudioClip[] Sounds => _audioClips;

    public RandomSoundSet(string name)
    {
        _name = name;
    }

    public AudioClip GetRandomClip()
    {
        if (_audioClips.Length == 0)
        {
            Debug.LogWarning("AudioClips array is empty!");
            return null;
        }

        int randomIndex = Random.Range(0, _audioClips.Length);
        return _audioClips[randomIndex];
    }
}
