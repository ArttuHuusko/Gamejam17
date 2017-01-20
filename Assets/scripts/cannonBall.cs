using UnityEngine;
using System.Collections;

public class cannonBall : MonoBehaviour
{
    bool flyRight;

    public GameObject boat;
    public float ballSpeed = 10f;
    public Rigidbody2D body;

    // Use this for initialization
    void Start()
    {
        //this.transform.rotation = boat.transform.rotation;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (flyRight == true)
        {
            body.AddRelativeForce(Vector2.right * ballSpeed);
        }
        else
        {
            body.AddRelativeForce(Vector2.left * ballSpeed);
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "cannonRight")
        {
            flyRight = true;
        }
    }
}



