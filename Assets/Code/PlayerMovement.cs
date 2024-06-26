using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public int speed;
    public Rigidbody2D rb;

    public float hInput;
    public float vInput;

    // Update is called once per frame
    void Update()
    {
        hInput = Input.GetAxis("Horizontal");
        vInput = Input.GetAxis("Vertical");

        rb.velocity = new Vector2(hInput * speed, vInput * speed);
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(hInput * speed, vInput * speed);
    }
}
