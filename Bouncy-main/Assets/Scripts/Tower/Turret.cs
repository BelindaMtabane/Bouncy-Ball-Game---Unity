using UnityEngine;

public class Turret : MonoBehaviour
{
    //<summary>
    //Ball position
    //shoots the ball
    //rotate the turret
    //where to spawn 
    public Transform spawnLocation;
    //what to spawn
    public GameObject bullet;
    //how often
    public float maxTime = 1;

    public float currentTime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.LookAt(BallController.Instance.transform);
    }

    // Update is called once per frame
    void Update()
    {
        //rotate turrent to look at player
        transform.LookAt(BallController.Instance.transform);
        //set time to decrease
        currentTime -= Time.deltaTime;
        if(currentTime <= 0)
        {
            //spawn bullet position
            var go = Instantiate(bullet);
            //place in right spot
            go.transform.position = spawnLocation.position;
            go.transform.rotation = transform.rotation; 

            currentTime = maxTime;
        }
        

    }
}
