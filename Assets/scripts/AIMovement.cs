using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AIMovement : MonoBehaviour {

    //TODO: TWEAK NUMBERS, MAKE SO AI BOATS DONT COLLIDE

    public float distanceFromPlayer;
    float t;
    public float engageTimer = 5.0f;
    float engageTimerCopy;
    public float inFiringPosition = 6f;
    float inFiringPositionCopy;
    public float shootDelay = 0.5f;
    float shootDelayCopy;
    public float reloadingTime = 5;
    public float ammo = 1;
    public float dirNum;

    Vector3 currentRotation;
    Vector3 currentRotationRet;
    Vector3 currentRotationEng;
    Vector3 moveTarget;

    Quaternion targetRotation;

    public bool retreating = false;
    public bool facingPlayer = false;
    public bool shootDelayTime = false;
    public bool fire = false;

    public GameObject player;
    public Rigidbody2D body;
    public float Speed = 10f;
    public float maxSpeed = 2;
    public float maxTurnRate = 0.5f;
    float evasionTimer = 2f;
    float xAxisRestrictor = 0;

    public GameObject cannonBall;

	public ParticleSystem cannonfire;
	public ParticleSystem cannonfire2;
	public ParticleSystem cannonfire3;
	public ParticleSystem cannonfire4;
	// Use this for initialization
	void Start () 
    {
       shootDelayCopy = shootDelay;
       inFiringPositionCopy = inFiringPosition;
       engageTimerCopy = engageTimer;
       body = GetComponent<Rigidbody2D>();
       player = GameObject.FindWithTag("Player");
       
	}
	
	// Update is called once per frame
	void FixedUpdate () 
    {

        //IF TIME MAKE BOAT START TURNING SLOW AND SPEED UP THE MORE IT TURNS (angularVelocity)

        Vector3 heading = player.transform.position - transform.position;
        dirNum = AngleDir(transform.forward, heading, transform.up);

        float distanceFromPlayer = Vector2.Distance(player.transform.position, transform.position);
        

        Vector3 dir = player.transform.position - transform.position;
        dir = player.transform.InverseTransformDirection(dir);

        //called after AI shoots or runs out of inFiringPositionTime
        if (retreating == true)
        {
            Vector3 diffAway = player.transform.position - transform.position;
            diffAway.Normalize();
            float rot_zAway = Mathf.Atan2(diffAway.y, diffAway.x) * Mathf.Rad2Deg;
            rot_zAway = rot_zAway + 180;
            transform.rotation = Quaternion.Euler(0f, 0f, rot_zAway - 90);

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
        else if (distanceFromPlayer > 6.5f)
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
        }

        //moves boat forward at maxSpeed and doesnt let it go over that value
        if(body.velocity.magnitude > maxSpeed)
        {
            body.velocity = body.velocity.normalized * maxSpeed;
        }

        //forces boat local y velocity to 0 i.e disables drifting
        Vector3 localVel = transform.InverseTransformDirection(body.velocity);
        localVel.y = maxSpeed;
        body.velocity = transform.TransformDirection(localVel);
        //forces boat local y velocity to 0 i.e disables drifting

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
        var newRotation = Quaternion.LookRotation(transform.position - player.transform.position, Vector3.forward);
        newRotation.x = 0.0f;
        newRotation.y = 0.0f;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, newRotation, maxTurnRate);

    }

    //Faces player
    void TurnToShootingPosition()
    {
        //calculates angles and differences between player and AIboat
        facingPlayer = false;
        float playerRotation = player.transform.localEulerAngles.z;
        currentRotation = transform.eulerAngles;
        currentRotation.z = Mathf.Lerp(currentRotation.z, playerRotation, 0.2f * Time.deltaTime);
        transform.eulerAngles = currentRotation;
    }

    public void EvasiveManeuvers()
    {
        Debug.Log("PICNIC");
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            shootDelayTime = true;
            retreating = true;
        }
        if (inFiringPosition <= 0)
        {
            retreating = true;
        }
    }

    //calculates if player is on left or right side of this gameobject 1 = right, -1 = left
    float AngleDir(Vector3 fwd, Vector3 targetDir, Vector3 up)
    {
        Vector3 perp = Vector3.Cross(fwd, targetDir);
        float dir = Vector3.Dot(perp, up);
        if (dir > 0f)
        {
            return 1f;
        }
        else if (dir < 0f)
        {
            return -1f;
        }
        else
        {
            return 0f;
        }
    }

    IEnumerator Firing()
    {
        ammo -= 1;
        yield return new WaitForSeconds(0.3f);
        if (dirNum == -1)
        {
            Instantiate(cannonBall, transform.FindChild("cannon").transform.position, this.transform.rotation);
			cannonfire.Play ();
            Instantiate(cannonBall, transform.FindChild("cannon (2)").transform.position, this.transform.rotation);
			cannonfire2.Play ();
        }
        else
        {
            Instantiate(cannonBall, transform.FindChild("cannon (3)").transform.position, this.transform.rotation);
			cannonfire3.Play ();
            Instantiate(cannonBall, transform.FindChild("cannon (5)").transform.position, this.transform.rotation);
			cannonfire4.Play ();
        }
        
    }

   

}
