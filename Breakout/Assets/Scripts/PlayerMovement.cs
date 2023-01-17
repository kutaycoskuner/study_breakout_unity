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
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start");
    }

    // Update is called once per frame
    void Update()
    {
        movementHorizontal = Input.GetAxis("Horizontal");
        //Debug.Log(movementHorizontal);
        if ((movementHorizontal>0 && transform.position.x<maxX) || (movementHorizontal < 0 && transform.position.x > -maxX)) 
        { 
        transform.position += Vector3.right * movementHorizontal * speed * Time.deltaTime;
        }
    }
}
