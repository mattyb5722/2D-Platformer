using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingRocksButton : MonoBehaviour {

    public GameObject rock;

    private List<GameObject> rocks = new List<GameObject>();

    private bool used = false;

    private Vector3 screenEdge;
    private Camera mainCamera;

    private void Start() {
        mainCamera = Camera.main;
    }

    private void Spawn (GameObject rock) {
        screenEdge = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height));
        for (int i = 0; i < 5; i++) {
            float leftEdge = (-1 * screenEdge.x) + (2* mainCamera.transform.position.x);
            // float rightEdge = screenEdge.x;
            // float TopEdge = screenEdge.y;

            GameObject temp = Instantiate(rock);
            temp.transform.position = new Vector3(Random.Range(leftEdge, screenEdge.x), screenEdge.y, 0f);
            temp.SetActive(true);
            rocks.Add(temp);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Player" && !used) {
            Spawn(rock);
            used = true;
        }
    }

    public void Reset() {
        foreach (GameObject rock in rocks) {
            Destroy(rock);
        }
        rocks.Clear();
    }
}
