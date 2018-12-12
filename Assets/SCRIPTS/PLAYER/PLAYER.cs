using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLAYER : PHYSICS_PLAYER
{
    [Header("VARIABLES")]

    public Animator anim;

    [Header("Properties")]
    private bool jump;
    public float jumpForce = 10f;
    public float speed = 10.0f;
    public float gravity = 1;

    public float jumpCounter = 1;

    private Vector3 moveVector = Vector3.zero;

    public CharacterController controller;

    private float crouchHeight;
    private float standarHeight;

    private float axis;//x

    public float xVelocity;

    public AudioSource jumpSFX;
    //public AudioSource walkSFX;
    public AudioSource slideSFX;

    public PLAYER_VIDA playerVida;

    public GameObject panel;

    public void Init()
    {
        playerVida = GameObject.FindGameObjectWithTag("Player").GetComponent<PLAYER_VIDA>();
        controller = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController>();

        playerVida.Ini();

        anim = GetComponent<Animator>();
        controller.enabled = true;
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        anim = GetComponent<Animator>();

        controller = GetComponent<CharacterController>();
        //smoothCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<SmoothCamera>();

        standarHeight = 1.9f;
        crouchHeight = 0.9f;
    }

    // Update is called once per frame
    public void Update()
    {

        speed = 10.0f;

        float translation = Input.GetAxis("Horizontal") * speed;

        if (Input.GetKey(KeyCode.S))
        {
            Crouching();
        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            GetUp();
        }


        if (Input.GetButtonDown("Fire3"))
        {
            slideSFX.Play();
            Sliding();
        }

        if (Input.GetButtonUp("Fire3"))
        {
            NoSliding();
        }

        if (jump && jumpCounter > 0)
        {
            moveVector.y = jumpForce;
            jumpCounter --;

            anim.SetTrigger("isJumping");
            jumpSFX.Play();

            Debug.Log("SALTADOOO");
            jump = false;
        }
        
        if(jumpCounter <= 0)
        {
            jump = false;
        }

        //FLIP, girar de direccio
        if ((isFacingRight && axis < 0) || (!isFacingRight && axis > 0))
        {
            Flip();
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z * -1);
        }

        if (controller.isGrounded)
        {
            jumpCounter = 1;

            moveVector.x = axis;
            xVelocity = axis * speed;
        }

        moveVector.y = moveVector.y - gravity * (Time.deltaTime);

        controller.Move(moveVector * Time.deltaTime);

        //NO MOURE
        if (isTouchingWall)
        {
            anim.SetBool("isRunning", false);
            anim.SetBool("isIdle", true);

            if ((axis > 0 && isFacingRight) || (axis < 0 && !isFacingRight))
            {
                xVelocity = axis * speed;
            }
        }
    }

    public void GodJump()
    {
        speed = speed * 2;
        panel.SetActive(false);

        controller.enabled = false;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(-Vector3.up * speed * Time.deltaTime);
        }
    }

    public void StartJump()
    {   
        jump = true;
    }

    public void MuelleJump()
    {
        moveVector.y = jumpForce*1.5f;
        moveVector.x = 10;
        Debug.Log("MUELLE");
    }

    public void SetaJump()
    {
        moveVector.y = jumpForce * 2f;
        Debug.Log("setajump");
    }

    public void PinxosDamageEfect()
    {
        moveVector.x = -3;
        moveVector.y = 5;
    }

    public void SetAxis(float h)
    {
        axis = h;

        float translation = Input.GetAxis("Horizontal") * speed;

        translation *= Time.deltaTime;
        //rotation *= Time.deltaTime;
        transform.Translate(translation, 0, 0);
        //transform.Rotate(0, rotation, 0);

        if ((translation != 0) && (jump))
        {
            anim.SetTrigger("isJumping");
            anim.SetBool("isRunning", false);
            anim.SetBool("isIdle", false);
        }

        if ((translation != 0) && (isTouchingWall))
        {
            anim.SetBool("isRunning", false);
            anim.SetBool("isIdle", true);
        }

        if ((translation != 0) && (!isTouchingWall))
        {
            anim.SetBool("isRunning", true);
            anim.SetBool("isIdle", false);
        }

        if ((translation == 0))
        {
            anim.SetBool("isRunning", false);
            anim.SetBool("isIdle", true);
        }

    }

    public void Crouching()
    {
        if (controller.isGrounded)
        {
            anim.SetBool("isCrouch", true);

            controller.height = crouchHeight;
            controller.center = new Vector3(0f, -0.5f, 0f);

            speed = 2.5f;

            jumpCounter = 0;
        }

        //smoothCamera.CameraSliding();
    }

    public void GetUp()
    {
        anim.SetBool("isCrouch", false);

        transform.position = new Vector3(transform.position.x, transform.position.y + 0.3f, transform.position.z);
        controller.center = new Vector3(0f, 0f, 0f);

        controller.height = standarHeight;

        xVelocity = axis * speed;

        //smoothCamera.CameraNormal();
    }

    public void Sliding()
    {
        if (controller.isGrounded)
        {
            anim.SetBool("isSlide", true);

            controller.height = crouchHeight;
            controller.center = new Vector3(0f, -0.5f, 0f);

            speed = 15;

            jumpCounter = 0;
        }

        //smoothCamera.CameraSliding();
    }

    public void NoSliding()
    {
        anim.SetBool("isSlide", false);

        transform.position = new Vector3(transform.position.x, transform.position.y + 0.3f, transform.position.z);
        controller.center = new Vector3(0f, 0f, 0f);

        controller.height = standarHeight;
        jumpCounter = 0;
        xVelocity = axis * speed;

        //smoothCamera.CameraNormal();
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {   
        Debug.DrawRay(hit.point, hit.normal, Color.red);

        switch (hit.gameObject.tag)
        {
            case "Wall":
                Destroy(hit.gameObject);
                break;
            case "Ground":
                //walkSFX.Play();
                break;
            default:
                break;
        }
    }
}