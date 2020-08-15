using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Rigidbody2D theRB;
    public float moveSpeed;
    public Animator myAnim;
    public Joystick joystick;
    private Vector3 bottomLeftLimit;
    private Vector3 topRightLimit;
    public bool virusEaten = false;

    public static PlayerController instance;

    // Start is called before the first frame update
    void Start()
    {
         instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        theRB.velocity = new Vector2(joystick.Horizontal, joystick.Vertical) * moveSpeed;

        myAnim.SetFloat("moveX", theRB.velocity.x);
        myAnim.SetFloat("moveY", theRB.velocity.y);

        if (joystick.Horizontal >= 0.1 || joystick.Horizontal <= -0.1 || joystick.Vertical >= 0.1 || joystick.Vertical <= -0.1)

        {
            myAnim.SetFloat("lastMoveX", joystick.Horizontal);
            myAnim.SetFloat("lastMoveY", joystick.Vertical);
        }

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, bottomLeftLimit.x, topRightLimit.x), Mathf.Clamp(transform.position.y, bottomLeftLimit.y, topRightLimit.y), transform.position.z);
    }

    public void SetBounds(Vector3 botLeft, Vector3 topRight)
    {
        bottomLeftLimit = botLeft + new Vector3(0.5f, 1f, 0f);
        topRightLimit = topRight + new Vector3(-1f, -1f, 0f);
    }

    void OnCollisionEnter2D(Collision2D co)
    {
        if (co.gameObject.name == "Virus")
        {
            Destroy(co.gameObject);
            AudioManager.instance.PlaySFX(0);
            CountdownController.instance.startTimer = false;
            virusEaten = true;
        }
    }
}
