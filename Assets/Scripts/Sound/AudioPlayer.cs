using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioPlayer : MonoBehaviour
{
    public AudioSource audioData;
    public void Start()
    {
        audioData = GetComponent<AudioSource>();
    }
    public void playSound()
    {
        audioData.Play();
    }
}
