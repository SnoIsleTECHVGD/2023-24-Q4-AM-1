using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class UISounds : MonoBehaviour, IPointerEnterHandler, ISubmitHandler
{
    public AudioClip soundEffect;
    public float volume = 1f;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        PlaySoundEffect();
    }

    public void OnSubmit(BaseEventData eventData)
    {
        PlaySoundEffect();
    }

    private void PlaySoundEffect()
    {
        if (soundEffect != null)
        {
            audioSource.clip = soundEffect;
            audioSource.volume = volume;
            audioSource.Play();
        }
    }
}
