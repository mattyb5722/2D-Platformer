using UnityEngine;
using UnityEngine.UI;

public class UpdateVolume : MonoBehaviour {
	/// <summary>
    /// Updates UI values for volume
    /// </summary>
	// Update is called once per frame
	void Update () {
        float backgroundVolume = SFXManager.instance.backgroundVolume; // Music Volume
        float soundEffectVolume = SFXManager.instance.soundEffectVolume; // Effect Volume
        Text[] volumeText = GetComponentsInChildren<Text>(); // UI Text objects
        volumeText[2].text = "Music Volume:       " + (int)(backgroundVolume*100) + "%";
        volumeText[5].text = "Effect Volume:       " + (int)(soundEffectVolume * 100) + "%";
    }
}
