using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class PlayerMovement : MonoBehaviour
{

    public float speed = 5;
    public float maxX = 7.5f;

    float movementHorizontal;

    bool onceAtStart = true;
    bool onEveryTurn = true;

    int track_health;

    public GameObject panel_Ins;
    public GameObject go_bouncyBall;
    Rigidbody2D rb;
    //RigidBody2D go_ball_rb = obj_bouncyBall_rigidBody = FindObjectOfType<BouncyBall>().GetComponent<Rigidbody2D>();
    // Start is called before the first frame update
    void Start()
    {
        rb = go_bouncyBall.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movementHorizontal = Input.GetAxis("Horizontal");
        if ((movementHorizontal > 0 && transform.position.x < maxX) || (movementHorizontal < 0 && transform.position.x > -maxX))
        {
            if (onceAtStart)
            {
                hideInstructions();
            }
            track_health = go_bouncyBall.GetComponent<BouncyBall>().lives;
            if (onEveryTurn && track_health >= 0)
            {
                rb.gravityScale = 1;
            }
            transform.position += Vector3.right * movementHorizontal * speed * Time.deltaTime;
        }
    }

    void hideInstructions()
    {
        panel_Ins.SetActive(false);
        onceAtStart = false;

    }
}
