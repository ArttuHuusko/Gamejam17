using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AIMovement : MonoBehaviour {

    //TODO: TWEAK NUMBERS, MAKE SO AI BOATS DONT COLLIDE

    public float distanceFromPlayer;
    public float angleToPlayer;
    public float rotationDiff;
    float t;
    public float engageTimer = 5.0f;
    float engageTimerCopy;
    public float inFiringPosition = 6f;
    float inFiringPositionCopy;
    public float shootDelay = 0.5f;
    float shootDelayCopy;
    public float reloadingTime = 5;
    public float ammo = 1;

    Vector3 currentRotation;
    Vector3 currentRotationRet;
    Vector3 currentRotationEng;
    Vector3 moveTarget;

    Quaternion targetRotation;

    bool approaching = false;
    public bool retreating = false;
    public bool facingPlayer = false;
    public bool shootDelayTime = false;
    bool reloading = false;
    public bool fire = false;

    public GameObject player;
    public Rigidbody2D body;
    public float Speed = 10f;
    public float maxSpeed = 2;
    public float maxTurnRate = 0.5f;

    public GameObject cannonBall;


	// Use this for initialization
	void Start () 
    {
       shootDelayCopy = shootDelay;
       //AICannonsScript = GetComponentsInChildren<AICannons>();
       inFiringPositionCopy = inFiringPosition;
       engageTimerCopy = engageTimer;
       body = GetComponent<Rigidbody2D>();
       player = GameObject.FindWithTag("Player");
       
	}
	
	// Update is called once per frame
	void FixedUpdate () 
    {

        //IF TIME MAKE BOAT START TURNING SLOW AND SPEED UP THE MORE IT TURNS (angularVelocity)

        float distanceFromPlayer = Vector2.Distance(player.transform.position, transform.position);
        

        Vector3 dir = player.transform.position - transform.position;
        dir = player.transform.InverseTransformDirection(dir);
        float angleToPlayer = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        //called after AI shoots or runs out of inFiringPositionTime
        if (retreating == true)
        {
            Vector3 diffAway = player.transform.position - transform.position;
            diffAway.Normalize();
            float rot_zAway = Mathf.Atan2(diffAway.y, diffAway.x) * Mathf.Rad2Deg;
            rot_zAway = rot_zAway + 180;
            transform.rotation = Quaternion.Euler(0f, 0f, rot_zAway - 90);

            Vector3 rotationDiff = transform.rotation.eulerAngles; //possibly useless check when avaliable

            currentRotationRet = transform.eulerAngles;
            currentRotationRet.z = Mathf.Lerp(currentRotation.z, rot_zAway, maxTurnRate * Time.deltaTime);
            transform.eulerAngles = currentRotationRet;

            shootDelay -= Time.fixedDeltaTime;

            if (ammo > 0)
            {
                StartCoroutine(Firing());
            }

            //starts logic from the beginning, and resets all timers
            if (engageTimer > 0)
            {
                engageTimer = engageTimer - Time.fixedDeltaTime;
            }
            else if (engageTimer <= 0)
            {
                retreating = false;
                shootDelay = shootDelayCopy;
                ammo += 1;
                inFiringPosition = inFiringPositionCopy;
                engageTimer = engageTimerCopy;
            }
        }
        else if (distanceFromPlayer > 10f) //<--- change number possibly
        {
            BeginEngaging();
        }
        else
        {
            TurnToShootingPosition();
        }

        if (shootDelayTime == true)
        {
            shootDelay -= Time.fixedDeltaTime;

        }
        if (reloadingTime > 0)
        {
            shootDelayTime = false;
            //shootDelay = shootDelayCopy;
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

    //turns boat when it is close to player
    void BeginEngaging()
    {
        //inFiringPosition -= Time.fixedDeltaTime;
        var newRotation = Quaternion.LookRotation(transform.position - player.transform.position, Vector3.forward);
        newRotation.x = 0.0f;
        newRotation.y = 0.0f;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, newRotation, maxTurnRate);

    }

    //Faces player
    void TurnToShootingPosition()
    {
        //calculates angles and differences between player and AIboat
        //may have useless stuff check later
        facingPlayer = false;
        float playerRotation = player.transform.localEulerAngles.z;
        Vector3 rotationDiff = transform.rotation.eulerAngles;
        currentRotation = transform.eulerAngles;
        currentRotation.z = Mathf.Lerp(currentRotation.z, playerRotation, 0.2f * Time.deltaTime);
        transform.eulerAngles = currentRotation;

        //InShootingPosition();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.tag == "Player")
        {
            shootDelayTime = true;
            retreating = true;
            //StartCoroutine(Reload());
        }
        if (inFiringPosition <= 0)
        {
            retreating = true;
        }
    }

    IEnumerator Firing()
    {
        ammo -= 1;
        yield return new WaitForSeconds(0.3f);
        Instantiate(cannonBall, transform.FindChild("cannon").transform.position, this.transform.rotation);
        Instantiate(cannonBall, transform.FindChild("cannon (2)").transform.position, this.transform.rotation);
        Instantiate(cannonBall, transform.FindChild("cannon (3)").transform.position, this.transform.rotation);
        Instantiate(cannonBall, transform.FindChild("cannon (5)").transform.position, this.transform.rotation);
        
    }

   

}
