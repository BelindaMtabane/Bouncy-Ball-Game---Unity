using System.Runtime.CompilerServices;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class TowerBullet : MonoBehaviour
{
    //variables
    [SerializeField]
    float speed = 0;
    int damage = 100000;

    private void Update()
    {
        //transform.position += new Vector3(speed, 0, 0);//manual method
        //get forward movement
        Vector3 forward = transform.forward;

        //never start with float 
        Vector3 direction = forward * speed;

        //take our direction/speed and actually mocve our object
        transform.position += direction;

    }
    //to see if the bullet hits the player
    private void OnCollisionEnter(Collision collision)
    {
        //physics based
        if(collision.gameObject.GetComponent<BallController>() != null)
        {
            //we have collided with player
            BallController playerBallController = collision.gameObject.GetComponent<BallController>();
            playerBallController.ResetPosition();
        }
        //destroy with time by Destroy(gameObject, 20.of);
        Destroy(gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("PLayer"))
        {
            //we have collided with player
            BallController playerBallController = other.gameObject.GetComponent<BallController>();
            playerBallController.ResetPosition();
        }
        Destroy(gameObject);
    }
}
