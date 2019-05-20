using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour {

    private bool used = false;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Player" && !used) {
            used = true;
            PlayerManager.instance.PlayerScored();
            Destroy(gameObject);
        }
    }
}
