using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIManager : MonoBehaviour {

    /// <summary>
    /// Manages UI during the game.
    /// </summary>

    public Text scoreText;
    public Text distanceText;

    private void FixedUpdate() {
        scoreText.text = "Score: " + PlayerManager.instance.getScore(); // Updates score
        distanceText.text = "Distance Traveled: " + Mathf.Round(Camera.main.transform.position.x * 100) / 100;
    }
}
