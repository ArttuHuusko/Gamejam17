using UnityEngine;
using System.Collections;

public class AIMovementOld : MonoBehaviour {


    public Vector2 playerShootingPosLeftBack;
    public Vector2 playerShootingPosRightBack;
    public Vector2 playerShootingPosLeftFront;
    public Vector2 playerShootingPosRightFront;

    Vector2 chosenVector;

    bool shootingPosChosen = false;

    float closestPoint;

    //Vector2[] shootingPositionArray;

    public Vector2 chosenPlayerShootingPos;

    public GameObject player;
    public Rigidbody2D body;
    public float Speed = 10;
    public float maxSpeed = 10;

    // Use this for initialization
    void Start()
    {
        body = GetComponent<Rigidbody2D>();

        //VAIHDA JOS PELAAJAN NIMI VAIHTUU SCENESSÄ
        //recommended -> player = GameObject.FindWithTag("player");
        player = GameObject.Find("boat");

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        InitPlayerShootingPositions();

        if (body.velocity.magnitude > maxSpeed)
        {
            body.velocity = body.velocity.normalized * maxSpeed;
        }

        body.AddRelativeForce(Vector2.up * Speed);

        //if (shootingPosChosen == true)
        //{
        //    chosenPlayerShootingPos 
        //}
    }

    void InitPlayerShootingPositions()
    {

        playerShootingPosLeftBack = new Vector2(player.transform.position.x - 30f, player.transform.position.y - 30f);

        playerShootingPosLeftFront = new Vector2(player.transform.position.x - 30f, player.transform.position.y + 30f);

        playerShootingPosRightBack = new Vector2(player.transform.position.x + 30f, player.transform.position.y - 30f);

        playerShootingPosRightFront = new Vector2(player.transform.position.x + 30f, player.transform.position.y + 30f);

        float posLB = Vector2.Distance(playerShootingPosLeftBack, transform.position);

        float posLF = Vector2.Distance(playerShootingPosLeftFront, transform.position);

        float posRB = Vector2.Distance(playerShootingPosRightBack, transform.position);

        float posRF = Vector2.Distance(playerShootingPosRightFront, transform.position);

        closestPoint = Mathf.Min(posLB, posLF, posRB, posRF);

        if (closestPoint == posLB)
        {
            chosenVector = playerShootingPosLeftBack;
        }
        else if (closestPoint == posLF)
        {
            chosenVector = playerShootingPosLeftFront;
        }
        else if (closestPoint == posRB)
        {
            chosenVector = playerShootingPosRightBack;
        }
        else if (closestPoint == posRF)
        {
            chosenVector = playerShootingPosRightFront;
        }

        Debug.Log(chosenVector);



        //DELET THIS
        //List <Vector2> shootingPositionList = new List<Vector2>();
        //    shootingPositionList.Add(new Vector2(player.transform.position.x - 30f, player.transform.position.y - 30f));
        //    shootingPositionList.Add(new Vector2(player.transform.position.x - 30f, player.transform.position.y + 30f));
        //    shootingPositionList.Add(new Vector2(player.transform.position.x + 30f, player.transform.position.y - 30f));
        //    shootingPositionList.Add(new Vector2(player.transform.position.x + 30f, player.transform.position.y + 30f));
        //    ChosenPlayerShootingPos == position AI will move towards to reach shooting range on player
        //    Vector2 AIPathFindTarget = shootingPositionList[Random.Range(0, shootingPositionList.Count)];
        //    Debug.Log(chosenPlayerShootingPos);
        //DELET THIS






    }

    //FIND BETTER FUNCTION NAME
    void AIBeginAttack()
    {
        shootingPosChosen = true;
    }

}
