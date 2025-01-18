using UnityEngine;

public class PlayAudioOrb : MonoBehaviour
{
    private GhostOrbController goc;
    private bool played = false;
    private AudioSource audioSource;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        goc = GetComponent<GhostOrbController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(goc.active && played == false) {
            audioSource.Play();
            played = true;
        }
    }
}
