using UnityEngine;
using System.Collections;

public class cannonBall : MonoBehaviour
{
    bool flyRight;
	public Vector3 spawnValues;
    public GameObject boat;
    public float ballSpeed = 10f;
    public Rigidbody2D body;
	public ParticleSystem ripple;
    // Use this for initialization
    void Start()
    {
		StartCoroutine (killThis ());
        //this.transform.rotation = boat.transform.rotation;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
		spawnValues = transform.position;
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
	void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.tag == "enemy")
		{
			enemyHealth eh = (enemyHealth) coll.transform.GetComponent("enemyHealth");
			eh.takeDamage ();
			Destroy (this.gameObject);
		}
	}
	IEnumerator killThis ()
	{
		yield return new WaitForSeconds (1.5f);
		Vector3 spawnPos = new Vector3 (spawnValues.x, spawnValues.y, spawnValues.z);
		Quaternion spawnRotation = Quaternion.identity;
		Instantiate (ripple, spawnPos,spawnRotation);
		Destroy (gameObject);
	}
}