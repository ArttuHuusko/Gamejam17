using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AIMovement : MonoBehaviour {

    float distanceFromPlayer;
    float angleToPlayer;
    float rotationDiff;

    Vector3 currentRotation;

    bool turning = false;

    //Quaternion playerRotation = Quaternion.identity;

    public GameObject player;
    public Rigidbody2D body;
    public float Speed = 10f;
    public float maxSpeed = 10;

	// Use this for initialization
	void Start () 
    {
       body = GetComponent<Rigidbody2D>();

       //VAIHDA JOS PELAAJAN NIMI VAIHTUU SCENESSÄ
       //recommended -> player = GameObject.FindWithTag("player");
       player = GameObject.Find("boat");
       
	}
	
	// Update is called once per frame
	void FixedUpdate () 
    {

        float distanceFromPlayer = Vector2.Distance(player.transform.position, transform.position);

        Vector3 dir = player.transform.position - transform.position;
        dir = player.transform.InverseTransformDirection(dir);
        float angleToPlayer = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

       // Debug.Log(dir);
        //Debug.Log(angleToPlayer);

        Debug.Log(distanceFromPlayer);

        if (distanceFromPlayer > 50f)
        {
            ApproachPlayer();
        }
        else if (turning == false)
        {
            TurnToShootingPosition();
            //turning = true;
        }

        if(body.velocity.magnitude > maxSpeed)
        {
            body.velocity = body.velocity.normalized * maxSpeed;
        }

        body.AddRelativeForce(Vector2.up * Speed);

       //if (shootingPosChosen == true)
       //{
       //    chosenPlayerShootingPos 
       //}
	}

    //works as intended as far as i know
    void ApproachPlayer()
    {
        Vector3 diff = player.transform.position - transform.position;
        diff.Normalize();
        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
        //transform.rotation = Vector2.MoveTowards(transform.position, player.transform.position, Speed);
    }

    //make it so the boat turns slowly this function does not differ from void InShootingPosition() right now 
    void TurnToShootingPosition()
    {
        float playerRotation = player.transform.localEulerAngles.z;
        Vector3 rotationDiff = transform.rotation.eulerAngles;
        //rotationDiff = playerRotation.z - transform.rotation.z;
        currentRotation = transform.eulerAngles;
        currentRotation.z = Mathf.Lerp(currentRotation.z, playerRotation, 0.2f * Time.deltaTime);
        transform.eulerAngles = currentRotation;
        //transform.rotation = Quaternion.Lerp(transform.rotation, playerRotation, 1);

        //InShootingPosition();
    }

    void InShootingPosition()
    {
        Quaternion rotation = Quaternion.LookRotation
            (player.transform.position - transform.position, transform.TransformDirection(Vector3.up));
        transform.rotation = new Quaternion(0, 0, rotation.z, rotation.w);
    }

   

}
