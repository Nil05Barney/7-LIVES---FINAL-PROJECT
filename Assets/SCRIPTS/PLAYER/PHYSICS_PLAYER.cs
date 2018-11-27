using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PHYSICS_PLAYER : MonoBehaviour
{
    /*[Header("Physics properties")]
    public float gravityMagnitude = 1;*/

    [Header("Collision state")]
    public bool isGrounded;
    protected bool wasGrounded;
    protected bool justGrounded;
    protected bool justNotGrounded;
    public bool isTouchingWall;
    protected bool wasTouchingWall;
    protected bool justTouchingWall;
    protected bool justNotTouchingWall;
    public bool isFacingRight;

    /*
    [Header("Ground collision")]
    public Vector3 gDirection;
    public LayerMask gMask;
    public float gDistance;
    public int gNumRays;
    public float gDistBTrays;
    */

    [Header("Wall collision")]
    public Vector3 wDirection;
    public LayerMask wMask;
    public float wDistance;
    public int wNumRays;
    public float wDistBTrays;
    


    protected virtual void Start()
    {
        isFacingRight = true;
    }

    
    protected virtual void FixedUpdate()
    {
        //CheckGround();
        CheckWall();
    }

    /*void CheckGround()
    {
        //Default collisions state
        wasGrounded = isGrounded;
        isGrounded = false;
        justGrounded = false;
        justNotGrounded = false;

        Vector3 pos = transform.position;
        int sign = 1;
        for (int i = 0; i < gNumRays; i++)
        {
            RaycastHit hit = new RaycastHit();
            Ray ray = new Ray(pos, gDirection);
            if (Physics.Raycast(ray, out hit, gDistance, gMask))
            {
                isGrounded = true;
                if (!wasGrounded) justGrounded = true;
                break;
            }

            pos.x += sign * ((i + 1) * gDistBTrays);
            sign *= -1;
        }

        if (!isGrounded && wasGrounded) justNotGrounded = true;
    }*/

    void CheckWall()
    {
        //Default collisions state
        wasTouchingWall = isTouchingWall;
        isTouchingWall = false;
        justTouchingWall = false;
        justNotTouchingWall = false;

        Vector3 pos = transform.position;
        int sign = 1;
        for (int i = 0; i < wNumRays; i++)
        {
            RaycastHit hit = new RaycastHit();
            Ray ray = new Ray(pos, wDirection);
            if (Physics.Raycast(ray, out hit, wDistance, wMask))
            {
                isTouchingWall = true;
                if (!wasTouchingWall) justTouchingWall = true;
                break;
            }

            pos.z += sign * ((i + 1) * wDistBTrays);
            sign *= -1;
        }

        if (!isTouchingWall && wasTouchingWall) justNotTouchingWall = true;
    }

    protected virtual void Flip()
    {
        isFacingRight = !isFacingRight;

        if (isFacingRight) wDirection = Vector3.right;
        else wDirection = Vector3.left;
    }

    
    private void OnDrawGizmos()
    {
        //DrawGroundRays();
        DrawWallRays();

    }

   /*void DrawGroundRays()
    {
        if (isGrounded) Gizmos.color = Color.blue;
        else Gizmos.color = Color.green;

        Vector3 pos = transform.position;
        int sign = 1;
        for (int i = 0; i < gNumRays; i++)
        {
            Gizmos.DrawRay(pos, gDirection * gDistance);
            pos.x += sign * ((i + 1) * gDistBTrays);
            sign *= -1;
        }
    }
    */

    void DrawWallRays()
    {
        if (isTouchingWall) Gizmos.color = Color.blue;
        else Gizmos.color = Color.red;

        Vector3 pos = transform.position;
        int sign = 1;
        for (int i = 0; i < wNumRays; i++)
        {
            Gizmos.DrawRay(pos, wDirection * wDistance);
            pos.y += sign * ((i + 1) * wDistBTrays);
            sign *= -1;
        }
    }
}
