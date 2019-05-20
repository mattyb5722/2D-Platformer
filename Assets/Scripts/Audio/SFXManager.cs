using UnityEngine;

public class SFXManager : MonoBehaviour {
    /// <summary>
    /// This script manages the background music as well as the 
    /// sound made when an enemy is hit.
    /// </summary>
 
    public static SFXManager instance = null;   // Instance of this class

    [Header("Background")]
    private AudioSource backgroundSource;        // Music Sourse
    [Range(0, 1)]
    public float backgroundVolume;              // Music Volume

    [Header("Sound Effect")]
    private AudioSource soundEffectSource;       // Effect Sourse
    public AudioClip walkingClip;           // Effect Clip
    [Range(0, 1)]
    public float soundEffectVolume;             // Effect Volume

    public void Awake(){
        // Creates instance of this class
        if (instance == null){ instance = this; }
        else{ Destroy(gameObject); }

        AudioSource [] sources = GetComponentsInChildren<AudioSource>();
        backgroundSource = sources [0];
        soundEffectSource = sources [1];

        // Creates player volume preferences (Music)
        if (!PlayerPrefs.HasKey("Background Volume"))
        {
            PlayerPrefs.SetFloat("Background Volume", backgroundVolume); // Defualt Value
        }
        instance.backgroundVolume = PlayerPrefs.GetFloat("Background Volume"); // Get past perference
        instance.backgroundSource.volume = instance.backgroundVolume; // Set Music Volume


        // Creates player volume preferences (Effects)
        if (!PlayerPrefs.HasKey("Effect Volume"))
        {
            PlayerPrefs.SetFloat("Effect Volume", soundEffectVolume); // Defualt Value
        }
        instance.soundEffectVolume = PlayerPrefs.GetFloat("Effect Volume");  // Get past perference
        instance.soundEffectSource.volume = instance.soundEffectVolume; // Set Effect Volume
    }

    // Increaing the Music Volume
    public void BackgroundVolumeUp() {
        instance.backgroundVolume += .1f; // Increase 

        if (instance.backgroundVolume > 1){
            instance.backgroundVolume = 1;
        }
        PlayerPrefs.SetFloat("Background Volume", instance.backgroundVolume); // Set player preference
        instance.backgroundSource.volume = instance.backgroundVolume; // Set Music Volume

    }
    // Decreasing the Music Volume
    public void BackgroundVolumeDown(){
        instance.backgroundVolume -= .1f;
        if (instance.backgroundVolume < 0){
            instance.backgroundVolume = 0;
        }
        PlayerPrefs.SetFloat("Background Volume", instance.backgroundVolume); // Set player preference
        instance.backgroundSource.volume = instance.backgroundVolume; // Set Music Volume
    }
    // Increaing the Effect Volume
    public void EffectVolumeUp(){
        instance.soundEffectVolume += .1f;
        if (instance.soundEffectVolume > 1){
            instance.soundEffectVolume = 1;
        }
        PlayerPrefs.SetFloat("Effect Volume", instance.soundEffectVolume); // Set player preference
        instance.soundEffectSource.volume = instance.soundEffectVolume; // Set Effect Volume

    }
    // Decreasing the Effect Volume
    public void EffectVolumeDown()
    {
        instance.soundEffectVolume -= .1f;

        if (instance.soundEffectVolume < 0){
            instance.soundEffectVolume = 0;
        }
        PlayerPrefs.SetFloat("Effect Volume", instance.soundEffectVolume); // Set player preference
        instance.soundEffectSource.volume = instance.soundEffectVolume; // Set Effect Volume

    }

    // Sound of an asteroid being destroyed
    public void SoundEffectPlayOneShot(){
        soundEffectSource.PlayOneShot(walkingClip);
    }

    // Sound of an asteroid being destroyed
    public void WalkingPlay() {
        if (!soundEffectSource.isPlaying) {
            soundEffectSource.Play();
        }
    }

    // Sound of an asteroid being destroyed
    public void WalkingStop() {
        soundEffectSource.Stop();
    }
}
