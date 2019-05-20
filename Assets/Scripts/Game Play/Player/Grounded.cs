using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grounded : MonoBehaviour {

    public static bool grounded = false;


    private void OnTriggerStay2D(Collider2D collision) {
        if (collision.gameObject.tag == "Ground") {
            grounded = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Ground") {
            grounded = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.gameObject.tag == "Ground") {
            grounded = false;
        }
    }
}
