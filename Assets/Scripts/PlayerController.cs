using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public AudioClip deathClip;
    public float jumpForce = 700f;
    private int jumpcount = 0;
    private bool isGrounded = false;
    private bool isDead = false;

    private Rigidbody2D playerRigidbody;
    private Animator animator;
    private AudioSource playerAudio;
    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isDead) {

            return;
        }
        if(Input.GetMouseButtonDown(0)&&jumpcount<2) {
            jumpcount++;
            playerRigidbody.velocity = Vector3.zero;
            playerRigidbody.AddForce(new Vector2(0, jumpForce));

            playerAudio.Play();
        
        }
        else if (Input.GetMouseButtonDown(0) && playerRigidbody.velocity.y > 0) {
            playerRigidbody.velocity = playerRigidbody.velocity * 0.5f;
        }

        animator.SetBool("Grounded", isGrounded);
    }
    private void Die() {
        animator.SetTrigger("Die");

        playerAudio.clip = deathClip;
        playerAudio.Play();

        playerRigidbody.velocity=Vector2.zero;

        isDead = true;

        GameManager.Instance.OnPlayerDead();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Dead" && !isDead) {
            Die();
        }
        string collidedTag = collision.gameObject.tag;
        switch (collidedTag) {
            case "Coin1":
                CollectCoin(collision.gameObject, 1);
                
                break;
            case "Coin2":
                CollectCoin(collision.gameObject, 2);
                break;
            case "Coin3":
                CollectCoin(collision.gameObject, 3);
                break;
            default:
                // Handle other cases if needed
                break;
        }
    }

    void CollectCoin(GameObject coin, int value) {
        coin.SetActive(false);
        GameManager.Instance.AddScore(value);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.contacts[0].normal.y > 0.7f) {
            isGrounded = true;
            jumpcount = 0;
        }
    }
    private void OnCollisionExit2D(Collision2D collision) {
        isGrounded=false;
    }
}
