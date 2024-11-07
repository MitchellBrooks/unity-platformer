using UnityEngine;

public class FireSpawner : MonoBehaviour
{
    public GameObject fire;

    public GameObject player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Vector3 ppos = player.transform.position;
        //Instantiate(fire, new Vector3(ppos.x, -25, ppos.z), new Quaternion());
    }

    // Update is called once per frame
    void Update()
    {
        
        // spawn fire along the y axis at -100 units underneath the player such that there are 5 fires beneath the player at all times
        
    }
}
