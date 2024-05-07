using UnityEngine;

public class MusicEnding : MonoBehaviour
{
    public AudioClip audioClip;
    private AudioSource audioSource;
    private static bool hasAudioPlayed = false;

    void Start()
    {
        if (!hasAudioPlayed)
        {
            audioSource = GetComponent<AudioSource>();
            audioSource.clip = audioClip;
            audioSource.Play();

            hasAudioPlayed = true;

            DontDestroyOnLoad(gameObject);
        }
    }
}
