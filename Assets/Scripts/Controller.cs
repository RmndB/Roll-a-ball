using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    private Rigidbody _rb;
    public LayerMask Ground;

    private float _xInput;
    private float _yInput;

    public float speed = 10.0f;
    public float JumpHeight = 2f;
    public bool isGrounded;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void OnCollisionStay(Collision collision)
    {
        if (((1 << collision.gameObject.layer) & Ground) != 0)
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (((1 << collision.gameObject.layer) & Ground) != 0)
        {
            isGrounded = false;
        }
    }

    void Update()
    {
        _xInput = Input.GetAxis("Horizontal");
        _yInput = Input.GetAxis("Vertical");

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            _rb.AddForce(Vector3.up * Mathf.Sqrt(JumpHeight * -2f * Physics.gravity.y), ForceMode.VelocityChange);
        }
    }

    void FixedUpdate()
    {
        _rb.AddForce(new Vector3(_xInput, 0.0f, _yInput) * speed);
    }
}