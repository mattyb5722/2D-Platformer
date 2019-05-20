using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {
    /// <summary>
    /// Manages the player's movement
    /// </summary>

    public static PlayerManager instance = null;

    private Camera mainCamera;

    private Animator anim;
    private Rigidbody2D body;

    private bool facingRight = true;
    private bool dead = false;
    private int score = 0;


    private bool attacking = false;
    private float attackingCD = 2f;
    private float lastAttackTime = -2f;


    private void Awake() {
        if (instance == null) { instance = this; } 
        else { Destroy(gameObject); }

        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        mainCamera = Camera.main;
    }

    private void FixedUpdate() {

        if (!dead) {
            if (Input.GetKey(KeyCode.W)) {          // Jump
                if (Grounded.grounded) {
                    anim.SetTrigger("Jump");
                    body.AddForce(transform.up * 350f);
                }
            }

            if (Input.GetKey(KeyCode.A)) {          // Move Left
                if (facingRight) {
                    GetComponent<SpriteRenderer>().flipX = true;
                    facingRight = !facingRight;
                }
                anim.SetBool("Walking", true);

                if (Grounded.grounded) {
                    SFXManager.instance.WalkingPlay();
                    body.AddForce(transform.right * -5f);
                } else {
                    body.AddForce(transform.right * -2.5f);
                }
            }

            if (Input.GetKey(KeyCode.D)) {          // Move Right
                if (!facingRight) {
                    GetComponent<SpriteRenderer>().flipX = false;
                    facingRight = !facingRight;
                }
                anim.SetBool("Walking", true);

                if (Grounded.grounded) {
                    SFXManager.instance.WalkingPlay();
                    body.AddForce(transform.right * 5f);
                } else {
                    body.AddForce(transform.right * 2.5f);
                }
            }

            if (!Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A)) {
                SFXManager.instance.WalkingStop();
                anim.SetBool("Walking", false);
            }
            if (Input.GetKey(KeyCode.Space)) {      // Attack
                if (Time.time >= attackingCD + lastAttackTime) {
                    lastAttackTime = Time.time;
                    StartCoroutine(Attack());
                }
            }

            Vector3 screenEdge = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height));
            if (transform.position.x < (-1 * screenEdge.x) + (2 * mainCamera.transform.position.x)) {      // Left border of the screen
                Dead("Boarder");
            } else if (transform.position.x > screenEdge.x) {   // Right border of the screen
                Dead("Boarder");
            } else if (transform.position.y < -1 * screenEdge.y) {      // Bottom border of the screen
                Dead("Boarder");
            }

            if (!Grounded.grounded) {
                SFXManager.instance.WalkingStop();
            }
        }
    }

    public void Dead(string reason) {
        if (reason == "Boarder") {
            StartCoroutine(Dead(false));
        } else {
            StartCoroutine(Dead(true));
        }
    }

    private IEnumerator Dead(bool deathAnimation) {
        SFXManager.instance.WalkingStop();
        dead = true;

        if (deathAnimation) {
            anim.SetTrigger("Dead");
            yield return new WaitForSeconds(1);
        }
        
        SceneChanger.instance.ChangeScene("Game Over"); // Change Scene

        // SceneChanger.instance.ChangeScene("Game Play"); // Change Scene


        float temp = score + 2 * mainCamera.transform.position.x;
        HighScoreManager.instance.NewHighScore(temp); // Update High Scores

        yield return null;
    }

    // When the player scores
    public void PlayerScored() {
        score += 10;                          // Incroment score
    }

    private IEnumerator Attack() {
        attacking = true;
        anim.SetTrigger("Attack");
        yield return new WaitForSeconds(5 / 6f);
        attacking = false;
    }

    public int getScore() {
        return score;
    }

    public bool getAttacking() {
        return attacking;
    }

}
