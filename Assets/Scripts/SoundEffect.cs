using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundEffect : MonoBehaviour
{
    [SerializeField] private AudioClip _clip;

    [Range(0f, 1f)]

    [SerializeField] private float _volume = 1f;

    private AudioSource _source;

    private void Awake()
    {
        _source = GetComponent<AudioSource>();
    }

    public void Play()
    {
        _source.PlayOneShot(_clip, _volume);
    }
}
