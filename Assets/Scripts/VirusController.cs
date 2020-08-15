using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusController : MonoBehaviour
{
    public float moveSpeed;
    private Rigidbody2D myRigidbody;
    private int walkDirection;
    public bool collided = false;
    public Transform[] waypoints;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        ChooseDirection();
    }

    void Update()
    {
        if (collided)
        {
            myRigidbody.velocity = new Vector2(0, 0);
            ChooseDirection();
        }
        switch (walkDirection)
        {
            case 0:
                myRigidbody.velocity = new Vector2(0, moveSpeed); //North
                break;
            case 1:
                myRigidbody.velocity = new Vector2(moveSpeed, 0); //East
                break;
            case 2:
                myRigidbody.velocity = new Vector2(0, -moveSpeed); //South
                break;
            case 3:
                myRigidbody.velocity = new Vector2(-moveSpeed, 0); //West
                break;
        }
    }

    public void ChooseDirection()
    {
        walkDirection = Random.Range(0, 4);
    }
    void OnCollisionEnter2D(Collision2D collisionObject)
    {
        if (collisionObject.collider.name == "Wall")
            collided = true;
    }
    void OnCollisionExit2D(Collision2D collisionObject)
    {
        if (collisionObject.collider.name == "Wall")
            collided = false;
    }

}