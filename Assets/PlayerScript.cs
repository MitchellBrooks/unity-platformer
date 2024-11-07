using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public Rigidbody2D rb;
    private bool isJumpPressed = false;
    private bool isJumpVelocityAdded = false;
    private bool isDoubleJumpUsed = false;
    private bool isDoubleJumpVelocityAdded = false;
    private bool isLeftPressed = false;
    private bool isRightPressed = false;
    private Vector3 startPosition;
    private int coinCount = 0;
    private AudioManager audioManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startPosition = transform.position;
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("space")) {
            if(!isDoubleJumpUsed) {
                if(isJumpPressed) {
                    isDoubleJumpUsed = true;
                }
                isJumpPressed = true;
            }
        }
        if(Input.GetKey("d")) {
            isRightPressed = true;
        }
        if(Input.GetKey("a")) {
            isLeftPressed = true;
        }
    }

    void FixedUpdate() {
        if((isJumpPressed && !isJumpVelocityAdded) || (isDoubleJumpUsed && !isDoubleJumpVelocityAdded)) {
            rb.linearVelocity = new Vector3(0, 15, 0);
            if(isJumpVelocityAdded) {
                isDoubleJumpVelocityAdded = true;
            }
            isJumpVelocityAdded = true;
            audioManager.SFXPlay(audioManager.jumpSound);
        }
        if(isRightPressed) {
            transform.position += new Vector3(0.25f, 0, 0);
            isRightPressed = false;
        }
        if(isLeftPressed) {
            transform.position += new Vector3(-0.25f, 0, 0);
            isLeftPressed = false;
        }
    }

    void OnCollisionEnter2D(Collision2D coll){
        if(coll.gameObject.tag=="Ground")
        {
            isJumpPressed = false;
            isJumpVelocityAdded = false;
            isDoubleJumpUsed = false;
            isDoubleJumpVelocityAdded = false;
        }
        if(coll.gameObject.tag=="Fire")
        {
            Debug.Log("died");
            audioManager.SFXPlay(audioManager.damageSound);
            Die();
        }
        if(coll.gameObject.tag == "Coin") {
            Debug.Log("coin");
            coinCount++;
        }
    }

    void Die() {
        transform.position = startPosition;
        transform.rotation = new Quaternion();
        rb.linearVelocity = Vector2.zero;
        rb.angularVelocity = 0f;
    }
}
