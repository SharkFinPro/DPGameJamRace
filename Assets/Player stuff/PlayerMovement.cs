using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            rb.AddForce(new Vector2(0f, 500f));
        }

        if (Input.GetKeyDown("right"))
        {
            rb.AddForce(new Vector2(150f, 0f));
        }

        if (Input.GetKeyDown("left"))
        {
            rb.AddForce(new Vector2(-150f, 0f));
        }
    }
}
