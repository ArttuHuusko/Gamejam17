using UnityEngine;
using System.Collections;

public class cannonBall : MonoBehaviour
{
    bool flyRight;
	public Vector3 spawnValues;
    public GameObject boat;
    public float ballSpeed = 20f;
    public Rigidbody2D body;
	public ParticleSystem ripple;
	public float maxSpeed = 15f;
	public bool enemyBall;

    public GameObject player;

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
        if (enemyBall == true)
        {
            if (flyRight == true)
            {
                body.AddRelativeForce(Vector2.right * ballSpeed);
                if (body.velocity.magnitude > maxSpeed)
                {

                    Quaternion rotation = Quaternion.LookRotation
                    (player.transform.position - transform.position, transform.TransformDirection(Vector3.up));
                    transform.rotation = new Quaternion(0, 0, rotation.z, rotation.w);

                    body.velocity = body.velocity.normalized * maxSpeed;
                }
            }
            else
            {
                body.AddRelativeForce(Vector2.left * ballSpeed);
                if (body.velocity.magnitude > maxSpeed)
                {

                    Quaternion rotation = Quaternion.LookRotation
                    (player.transform.position - transform.position, transform.TransformDirection(Vector3.up));
                    transform.rotation = new Quaternion(0, 0, rotation.z, rotation.w);


                    body.velocity = body.velocity.normalized * maxSpeed;
                }
            }
        }
        else
        {
            if (flyRight == true)
            {
                body.AddRelativeForce(Vector2.right * ballSpeed);
                if (body.velocity.magnitude > maxSpeed)
                {
                    body.velocity = body.velocity.normalized * maxSpeed;
                }
            }
            else
            {
                body.AddRelativeForce(Vector2.left * ballSpeed);
                if (body.velocity.magnitude > maxSpeed)
                {
                    body.velocity = body.velocity.normalized * maxSpeed;
                }
            }
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
		if(enemyBall == false)
		{
			if (coll.gameObject.tag == "enemy")
			{
				enemyHealth eh = (enemyHealth) coll.transform.GetComponent("enemyHealth");
				eh.takeDamage ();
				Destroy (this.gameObject);
			}
			/*else if (coll.gameObject.tag == "player")
			{
				playerHealth ph = (playerHealth) coll.transform.GetComponent("playerHealth");
				ph.takeDamage ();
				Destroy (this.gameObject);
			}*/
		}
	}
	IEnumerator killThis ()
	{
		yield return new WaitForSeconds (0.8f);
		Vector3 spawnPos = new Vector3 (spawnValues.x, spawnValues.y, spawnValues.z);
		Quaternion spawnRotation = Quaternion.identity;
		Instantiate (ripple, spawnPos,spawnRotation);
		Destroy (gameObject);
	}
}