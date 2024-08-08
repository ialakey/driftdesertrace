using UnityEngine;
using UnityEngine.UI;  

public class MusicPlayer : MonoBehaviour
{
    public AudioClip[] tracks;  
    public Text trackInfoText;  
    private AudioSource audioSource;
    private int currentTrackIndex = 0;
    private bool isPaused = false;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.loop = true;  

        if (tracks.Length > 0)
        {
            audioSource.clip = tracks[currentTrackIndex];
            audioSource.Play();
            UpdateTrackInfo();  
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            PlayNextTrack();
        }
        else if (Input.GetKeyDown(KeyCode.P))
        {
            TogglePlayPause();
        }
    }

    private void PlayNextTrack()
    {
        currentTrackIndex = (currentTrackIndex + 1) % tracks.Length;
        audioSource.clip = tracks[currentTrackIndex];
        audioSource.Play();
        isPaused = false;  
        UpdateTrackInfo();
    }

    private void TogglePlayPause()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Pause();
            isPaused = true;
            trackInfoText.text = "Music is paused. Press P to continue.";
        }
        else
        {
            audioSource.Play();
            isPaused = false;
            UpdateTrackInfo();
        }
    }

    private void UpdateTrackInfo()
    {
        if (isPaused)
        {
            trackInfoText.text = "Music is paused. Press P to continue.";
        }
        else
        {
            trackInfoText.text = "G - next track. Now playing: " + tracks[currentTrackIndex].name;
        }
    }
}
