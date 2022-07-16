using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rb;
    bool move;
    InputType input;

    public float speed = 2;
    Vector3 currentPosition;
    //KeyCode keyCode;

    public enum InputType
    {
        FORWARD, BACKWARD, LEFT, RIGHT, FORWARD_RIGHT, FORWARD_LEFT, BACKWARD_LEFT, BACKWARD_RIGHT
    }
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        move = false;
        input = InputType.FORWARD;


        //keyCode = KeyCode.None;
    }

    // Update is called once per frame
    void Update()
    {
        handlePlayerInputs();

    }
    private void FixedUpdate()
    {

        handleMovement();
    }

    public void handleMovement()
    {

        if (move && input == InputType.FORWARD)
        {

            rb.AddForce(0, 0, 500 * Time.deltaTime);
        }
        else if (move && input == InputType.BACKWARD)
        {
            rb.AddForce(0, 0, -500 * Time.deltaTime);
        }
        else if (move && input == InputType.LEFT)
        {
            rb.AddForce(-500 * Time.deltaTime, 0, 0);
        }
        else if (move && input == InputType.RIGHT)
        {
            rb.AddForce(500 * Time.deltaTime, 0, 0);
        }
        else if (move && input == InputType.FORWARD_RIGHT)
        {

            rb.AddForce(500 * Time.deltaTime, 0, 500 * Time.deltaTime);
        }
        else if (move && input == InputType.FORWARD_LEFT)
        {

            rb.AddForce(-500 * Time.deltaTime, 0, 500 * Time.deltaTime);
        }
        else if (move && input == InputType.BACKWARD_LEFT)
        {

            rb.AddForce(-500 * Time.deltaTime, 0, -500 * Time.deltaTime);
        }
        else if (move && input == InputType.BACKWARD_RIGHT)
        {

            rb.AddForce(500 * Time.deltaTime, 0, -500 * Time.deltaTime);
        }

    }
    public void handlePlayerInputs()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {

            SceneManager.LoadScene(0);

        }
        if (Input.GetKey(KeyCode.W))
        {
            //  FORWARD RIGHT

            if (Input.GetKey(KeyCode.D))
            {
                move = true;
                input = InputType.FORWARD_RIGHT;
            }
            //   FORWARD LEFT

            else if (Input.GetKey(KeyCode.A))
            {
                move = true;
                input = InputType.FORWARD_LEFT;
            }
            // FORWARD 

            else
            {
                move = true;
                input = InputType.FORWARD;

            }
        }


        else if (Input.GetKey(KeyCode.A))
        {
            //* LEFT BACKWARDS

            if (Input.GetKey(KeyCode.S))
            {
                move = true;
                input = InputType.BACKWARD_LEFT;
            }
            //* LEFT FORWARDS

            else if (Input.GetKey(KeyCode.W))
            {
                move = true;
                input = InputType.FORWARD_LEFT;
            }
            // * LEFT

            else
            {
                move = true;
                input = InputType.LEFT;
            }
        }



        /*
         
         
         */

        else if (Input.GetKey(KeyCode.S))
        {
            //BACKWARDS RIGHT

            if (Input.GetKey(KeyCode.D))
            {
                move = true;
                input = InputType.FORWARD_RIGHT;
            }
            // BACKWARDS LEFT

            else if (Input.GetKey(KeyCode.A))
            {
                move = true;
            }
            //BACKWARDS

            else
            {
                move = true;
                input = InputType.BACKWARD;

            }
        }
        /*
         * 
        
         
         */

        else if (Input.GetKey(KeyCode.D))
        {
            //  RIGHT BACKWARDS

            if (Input.GetKey(KeyCode.S))
            {
                move = true;
                input = InputType.BACKWARD_RIGHT;
            }
            //  RIGHT FORWARD

            else if (Input.GetKey(KeyCode.W))
            {
                move = true;
                input = InputType.FORWARD_RIGHT;
            }
            //  RIGHT 

            else
            {
                move = true;
                input = InputType.RIGHT;
            }
        }

        /*
         NO INPUT
         */
        else
        {
            move = false;
        }
    }
}
