using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("----- Audio Source -----")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SfxSource;

    [Header("----- Audio Clip -----")]
    public AudioClip backgroundSound;
    public AudioClip coinSound;
    public AudioClip jumpSound;
    public AudioClip damageSound;

    private void Start() {
        musicSource.clip = backgroundSound;
        musicSource.Play();
    }

    public void SFXPlay(AudioClip audioClip) {
        SfxSource.PlayOneShot(audioClip);
    }
}
