using UnityEngine;

public class CoinScript : MonoBehaviour
{
    private Vector3 startingPosition;
    private float time = 0.0f;
    private float animationTime = 2.0f;
    private float animationMovementInterval = 0.01f;
    private bool floatUp = true;
    public AudioManager audioManager;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startingPosition = transform.position;
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void FixedUpdate()
    {
        // make the coin hover up and down like an idle animation
        
        if (time < animationTime && floatUp)
        {
            time = time + Time.fixedDeltaTime;
            transform.position += new Vector3(0, animationMovementInterval, 0);
        } else {
            floatUp = false;
            transform.position += new Vector3(0, animationMovementInterval*-1, 0);
            time = time - Time.fixedDeltaTime;
            if(time < 0) {
                floatUp = true;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        audioManager.SFXPlay(audioManager.coinSound);
        Destroy(gameObject);
    }
}
