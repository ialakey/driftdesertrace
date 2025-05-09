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

        foreach (var track in tracks)
        {
            track.LoadAudioData();
        }

        for (int i = 0; i < tracks.Length; i++)
        {
            tracks[i] = AdjustVolume(tracks[i], 0.15f);
        }

        if (tracks.Length > 0)
        {
            audioSource.clip = tracks[currentTrackIndex];
            audioSource.Play();
            UpdateTrackInfo();
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
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
            trackInfoText.text = "Music is paused. \n Press P to continue.";
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
            trackInfoText.text = "Music is paused. \n Press P to continue.";
        }
        else
        {
            string trackName = tracks[currentTrackIndex].name;
            string shortenedTrackName = trackName.Substring(0, Mathf.Min(6, trackName.Length));
            trackInfoText.text = "N - next track. \n Now playing: " + shortenedTrackName;
        }
    }

    private AudioClip AdjustVolume(AudioClip clip, float volumeScale)
    {
        float[] samples = new float[clip.samples * clip.channels];
        clip.GetData(samples, 0);

        for (int i = 0; i < samples.Length; i++)
        {
            samples[i] *= volumeScale;
        }

        AudioClip newClip = AudioClip.Create(clip.name, clip.samples, clip.channels, clip.frequency, false);
        newClip.SetData(samples, 0);

        return newClip;
    }
}
