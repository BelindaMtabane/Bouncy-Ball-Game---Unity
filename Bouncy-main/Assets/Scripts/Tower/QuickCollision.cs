using UnityEngine;

public class QuickCollision : MonoBehaviour
{
    // Public variable 
    Tower parent;

    private void Start()
    {
        parent = GetComponentInParent<Tower>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<BallController>())
        {
            parent.OnDeadlyCollision();
        }
    }
}
