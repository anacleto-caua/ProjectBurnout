using UnityEngine;

public class PlayAudio : MonoBehaviour
{
    private HumanPlateBehaviour hpb;
    private bool played = false;
    private AudioSource audioSource;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        hpb = GetComponent<HumanPlateBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        if(hpb.isPressed && played == false) {
            audioSource.Play();
            played = true;
        }
    }
}
