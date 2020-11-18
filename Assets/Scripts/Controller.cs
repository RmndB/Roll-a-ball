using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public LayerMask groundLayerMask;
    public int id = 0;
    public float speed = 10.0f;
    public float jumpHeight = 2f;

    private bool isGrounded;
    private Rigidbody rigidbody;
    private float x;
    private float y;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        x = Input.GetAxis("Horizontal" + id);
        y = Input.GetAxis("Vertical" + id);

        if (Input.GetButtonDown("Jump" + id) && isGrounded)
        {
            jump();
        }
    }

    void FixedUpdate()
    {
        rigidbody.AddForce(new Vector3(x, 0.0f, y) * speed);
    }

    void OnCollisionStay(Collision collision)
    {
        if (((1 << collision.gameObject.layer) & groundLayerMask) != 0)
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (((1 << collision.gameObject.layer) & groundLayerMask) != 0)
        {
            isGrounded = false;
        }
    }

    public void jump()
    {
        rigidbody.AddForce(Vector3.up * Mathf.Sqrt(jumpHeight * -2f * Physics.gravity.y), ForceMode.VelocityChange);
    }
}