using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingEnemy : MonoBehaviour {

    private bool facingRight = true;

    // Update is called once per frame
    private void Update () {
		if (facingRight) {
            transform.position = new Vector3(transform.position.x + .01f, transform.position.y, 0);
        }else if (!facingRight) {
            transform.position = new Vector3(transform.position.x - .01f, transform.position.y, 0);
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.gameObject.tag == "Ground") {
            facingRight = !facingRight;
            GetComponent<SpriteRenderer>().flipX = !GetComponent<SpriteRenderer>().flipX;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Player") {
            if (!PlayerManager.instance.getAttacking()) {
                PlayerManager.instance.Dead("Moving Enemy");
            } else {
                Destroy(gameObject);
                PlayerManager.instance.PlayerScored();
            }
        }
    }
}
