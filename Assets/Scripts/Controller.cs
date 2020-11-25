using System;
using UnityEngine;

public class Controller : MonoBehaviour
{
    private const float SPEED = 10.0f;
    private const float JUMP_HEIGHT = 2.0f;

    [SerializeField]
    private int controller = default;
    [SerializeField]
    private LayerMask groundLayer = default;
    [SerializeField]
    private int id = default;

    private new Rigidbody rigidbody;
    private bool isGrounded;
    private float x;
    private float y;

    private bool fp1, fp2, bp1, bp2, lp1, lp2, rp1, rp2, jp1, jp2;
    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        fp1 = fp2 = bp1 = bp2 = lp1 = lp2 = rp1 = rp2 = jp1 = jp2 = false;
    }

    private void FixedUpdate()
    {
        if (controller == 1)
        {
            // Player 1
            if (Input.GetKey(ControlsManager.ControlMng.forwardP1))
            {
                fp1 = true;
                y = moveBall(y, true);
            }
            else if (fp1)
            {
                fp1 = false;
                y = 0;
            }

            if (Input.GetKey(ControlsManager.ControlMng.backwardP1))
            {
                bp1 = true;
                y = moveBall(y, false);
            }
            else if (bp1)
            {
                bp1 = false;
                y = 0;
            }

            if (Input.GetKey(ControlsManager.ControlMng.rightP1))
            {
                rp1 = true;
                x = moveBall(x, true);
            }
            else if (rp1)
            {
                rp1 = false;
                x = 0;
            }

            if (Input.GetKey(ControlsManager.ControlMng.leftP1))
            {
                lp1 = true;
                x = moveBall(x, false);
            }
            else if (lp1)
            {
                lp1 = false;
                y = 0;
            }

            if (Input.GetKey(ControlsManager.ControlMng.jumpP1) && isGrounded)
            {
                jp1 = true;
                Jump();
            }
            else if (jp1)
            {
                jp1 = false;
                y = 0;
            }
        }
        else
        {
            // Player 2
            if (Input.GetKey(ControlsManager.ControlMng.forwardP2))
            {
                fp2 = true;
                y = moveBall(y, true);
            }
            else if (fp2)
            {
                fp2 = false;
                y = 0;
            }

            if (Input.GetKey(ControlsManager.ControlMng.backwardP2))
            {
                bp2 = true;
                y = moveBall(y, false);
            }
            else if (bp2)
            {
                bp2 = false;
                y = 0;
            }

            if (Input.GetKey(ControlsManager.ControlMng.rightP2))
            {
                rp2 = true;
                x = moveBall(x, true);
            }
            else if (rp2)
            {
                rp2 = false;
                x = 0;
            }

            if (Input.GetKey(ControlsManager.ControlMng.leftP2))
            {
                lp2 = true;
                x = moveBall(x, false);
            }
            else if (lp2)
            {
                lp2 = false;
                y = 0;
            }

            if (Input.GetKey(ControlsManager.ControlMng.jumpP2) && isGrounded)
            {
                jp2 = true;
                Jump();
            }
            else if (jp2)
            {
                jp2 = false;
                y = 0;
            }
        }

        rigidbody.AddForce(new Vector3(x, 0.0f, y) * SPEED);
    }

    private float moveBall(float variable, bool add)
    {
        if (add)
        {
            if (variable < -0.15)
                variable = 0;
            else if (variable > 1.5f)
                variable = 1.5f;
            variable += 0.05f;
            return variable;
        }
        else
        {
            if (variable > 0.15)
                variable = 0;
            else if (variable < -1.5f)
                variable = -1.5f;
            variable -= 0.05f;
            return variable;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (((1 << collision.gameObject.layer) & groundLayer) != 0)
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (((1 << collision.gameObject.layer) & groundLayer) != 0)
        {
            isGrounded = false;
        }
    }

    public void Jump()
    {
        rigidbody.AddForce(Vector3.up * Mathf.Sqrt(JUMP_HEIGHT * -2f * Physics.gravity.y), ForceMode.VelocityChange);
    }
}