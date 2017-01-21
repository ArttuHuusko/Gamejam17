using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AIMovement : MonoBehaviour {

    float distanceFromPlayer;
    float angleToPlayer;
    float rotationDiff;
    float t;

    public float engageTimer = 5.0f;
    float engageTimerCopy;

    Vector3 currentRotation;
    Vector3 currentRotationRet;
    Vector3 currentRotationEng;
    Vector3 moveTarget;

    Quaternion targetRotation;

    bool approaching = false;
    bool retreating = false;
    public bool facingPlayer = false;

    //Quaternion playerRotation = Quaternion.identity;

    public GameObject player;
    public Rigidbody2D body;
    public float Speed = 10f;
    public float maxSpeed = 10;
    public float maxTurnRate = 0.5f;

	// Use this for initialization
	void Start () 
    {
       engageTimerCopy = engageTimer;
       body = GetComponent<Rigidbody2D>();
       player = GameObject.FindWithTag("player");
       
	}
	
	// Update is called once per frame
	void FixedUpdate () 
    {

        //IF TIME MAKE BOAT START TURNING SLOW AND SPEED UP THE MORE IT TURNS (angularVelocity)

        float distanceFromPlayer = Vector2.Distance(player.transform.position, transform.position);

        Vector3 dir = player.transform.position - transform.position;
        dir = player.transform.InverseTransformDirection(dir);
        float angleToPlayer = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        if (retreating == true)
        {
            Vector3 diffAway = player.transform.position - transform.position;
            diffAway.Normalize();
            float rot_zAway = Mathf.Atan2(diffAway.y, diffAway.x) * Mathf.Rad2Deg;
            rot_zAway = rot_zAway + 180;
            transform.rotation = Quaternion.Euler(0f, 0f, rot_zAway - 90);

            //float playerRotationRet = player.transform.localEulerAngles.z;
            Vector3 rotationDiff = transform.rotation.eulerAngles; //possibly useless check when avaliable

            currentRotationRet = transform.eulerAngles;
            currentRotationRet.z = Mathf.Lerp(currentRotation.z, rot_zAway, maxTurnRate * Time.deltaTime);
            transform.eulerAngles = currentRotationRet;

            if (engageTimer > 0)
            {
                engageTimer = engageTimer - Time.fixedDeltaTime;
            }
            else if (engageTimer <= 0)
            {
                retreating = false;
                engageTimer = engageTimerCopy;
            }
        }
        else if (distanceFromPlayer > 50f)
        {
            BeginEngaging();
        }
        else
        {
            TurnToShootingPosition();
        }

        

        //moves boat forward at maxSpeed and doesnt let it go over that value
        if(body.velocity.magnitude > maxSpeed)
        {
            body.velocity = body.velocity.normalized * maxSpeed;
        }
        body.AddRelativeForce(Vector2.up * Speed);
        //moves boat forward at maxSpeed and doesnt let it go over that value
        if (body.angularVelocity > maxTurnRate)
        {
            body.angularVelocity = maxTurnRate;
        }

	}

    //moves boat straight towards player
    void BeginEngaging()
    {

        var newRotation = Quaternion.LookRotation(transform.position - player.transform.position, Vector3.forward);
        newRotation.x = 0.0f;
        newRotation.y = 0.0f;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, newRotation, maxTurnRate);

    }

    //make it so the boat turns slowly this function does not differ from void InShootingPosition() right now 
    void TurnToShootingPosition()
    {
        facingPlayer = false;
        float playerRotation = player.transform.localEulerAngles.z;
        Vector3 rotationDiff = transform.rotation.eulerAngles;
        //rotationDiff = playerRotation.z - transform.rotation.z;
        currentRotation = transform.eulerAngles;
        currentRotation.z = Mathf.Lerp(currentRotation.z, playerRotation, 0.2f * Time.deltaTime);
        transform.eulerAngles = currentRotation;
        //transform.rotation = Quaternion.Lerp(transform.rotation, playerRotation, 1);

        //InShootingPosition();
    }

    //never called right now
    void InShootingPosition()
    {
        Quaternion rotation = Quaternion.LookRotation
            (player.transform.position - transform.position, transform.TransformDirection(Vector3.up));
        transform.rotation = new Quaternion(0, 0, rotation.z, rotation.w);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "player")
        {
            //Fire after like half a second or smth.
            //also make failsafe if trigger doesnt hit so AI doesnt get stuck
            retreating = true;
        }
    }

   

}
