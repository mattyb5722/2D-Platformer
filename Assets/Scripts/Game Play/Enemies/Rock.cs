using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour {

    private Vector3 screenEdge;
    private Camera mainCamera;

    private void Start() {
        mainCamera = Camera.main;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Player") {
            PlayerManager.instance.Dead("Rock");
            Destroy(gameObject);
        } else if (collision.gameObject.tag == "Ground") {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    private void Update() {
        screenEdge = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height));

        if (transform.position.y < -1 * screenEdge.y) {         // Bottom border of the screen
            Destroy(gameObject);
        }
    }
}
