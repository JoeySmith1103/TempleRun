using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    // Start is called before the first frame update
    //public Animator animator;


    //public float jumpForce = 10;

    private bool isAlive = true;
    private float movingSpeed = 9f;
    private bool turnLeft, turnRight;
    private bool jump, go;
    private CharacterController controller;
    private float jumpForce = 9f;
    private float gravity = -1f;
    private Vector3 upwardVector;
    private Vector3 direction;

    private Animator animator;
    private bool isJumping = false, isGrounded = true;
    private bool isRunning = false;


    //public float forwardSpeed;

    public Vector3 changeForward(ref Vector3 direction, bool left) {
        if (left) { 
            if (direction == new Vector3(0, 0, 1))
                direction = new Vector3(-1, 0, 0);
            else if (direction == new Vector3(-1, 0, 0))
                direction = new Vector3(0, 0, -1);
           else if (direction == new Vector3(0, 0, -1))
                direction = new Vector3(1, 0, 0);
            else
                direction = new Vector3(0, 0, 1);
        }
        else {
            if (direction == new Vector3(0, 0, 1))
                direction = new Vector3(1, 0, 0);
            else if (direction == new Vector3(1, 0, 0))
                direction = new Vector3(0, 0, -1);
            else if (direction == new Vector3(0, 0, -1))
                direction = new Vector3(-1, 0, 0);
            else
                direction = new Vector3(0, 0, 1);
        }
        return direction;
    }
    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        //turnLeft = Input.GetKeyDown(KeyCode.A);
        //turnRight = Input.GetKeyDown(KeyCode.D);

        //if (turnLeft) {
        //    transform.Rotate(new Vector3(0f, -90f, 0f));
        //    changeForward(ref direction, true);
        //} else if (turnRight) {
        //    transform.Rotate(new Vector3(0f, 90f, 0f));
        //    changeForward(ref direction, false);
        //}
        //if (controller.isGrounded) {
        //    if (Input.GetKeyDown(KeyCode.Space)) {
        //        Debug.Log("pushed");
        //        jump();
        //    }
        
        //}else {
        //    Debug.Log("error");
        //}
        //direction.z = moveSpeed;
        //direction.y += gravity * Time.deltaTime;
        //controller.Move(direction * moveSpeed * Time.deltaTime);
        //transform.localPosition += moveSpeed * direction * Time.deltaTime;

        if (isAlive == false) return; // dead

        go = Input.GetKeyDown(KeyCode.W);
        jump = Input.GetKeyDown(KeyCode.Space);
        turnLeft = Input.GetKeyDown(KeyCode.A);
        turnRight = Input.GetKeyDown(KeyCode.D);
        
        if (go == true) {
            isRunning = true;
            animator.SetBool("Running", true);
        }

        if (isRunning == false) return;
        else animator.SetBool("Running", true);

        if (turnLeft == true) transform.Rotate(new Vector3(0f, -90f, 0f));
        else if (turnRight == true) transform.Rotate(new Vector3(0f, 90f, 0f));

        if (controller.isGrounded == true) {
            direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            direction = direction * movingSpeed;
            isGrounded = true;
            animator.SetBool("isGrounded", true);
            isJumping = false;
            animator.SetBool("isJumping", false);
            if (jump == true) {
                upwardVector.y = jumpForce;
                isJumping = true;
                animator.SetBool("isJumping", true);
                isGrounded = false;
                animator.SetBool("isGrounded", false);
            }
        }
        else {
            upwardVector.y += Physics.gravity.y * Time.deltaTime;
        }

        controller.SimpleMove(new Vector3(0, 0, 0));
        controller.Move((transform.forward * movingSpeed + (direction + upwardVector)) * Time.deltaTime);
        CountScore.score += (2 * Time.deltaTime);
        if (transform.position.y < -10) die();
        isGrounded = true;
    }

    public void die() {
        isAlive = false;
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //CountScore.score = 0;
    }
}
