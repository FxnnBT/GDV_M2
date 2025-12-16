using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        BumperHit.onBumperHit += PlayBumperSound;
    }

    void OnDestroy()
    {
        BumperHit.onBumperHit -= PlayBumperSound;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            audioSource.Play();
        }
    }

    void PlayBumperSound(string bumperTag, int score)
    {
        audioSource.Play();
    }
}