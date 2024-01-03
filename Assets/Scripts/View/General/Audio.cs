using UnityEngine;

public class Audio : MonoBehaviour
{
    [SerializeField] private AudioClip _music;

    private void Awake()
    {
        AudioSource music = gameObject.AddComponent<AudioSource>();

        music.clip = _music;

        music.Play();
    }
}
