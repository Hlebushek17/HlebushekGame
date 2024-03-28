using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private float _fallVelocity = 0;
    
    public float gravity = 9.8f;

    public float  jumpForce;
    public float speed;

    public Animator animator;

    private Vector3 _moveVector;

    private CharacterController _characterController;

    // Start is called before the first frame update
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    void Update(){

        MovementUpdate();
        JumpUpdate();

    }

    private void MovementUpdate()
    {
        _moveVector = Vector3.zero;
        var runDirection = 0;

        //W1
        if(Input.GetKey(KeyCode.W)){
            _moveVector += transform.forward;
            runDirection = 1;
        }

        //A4
        if(Input.GetKey(KeyCode.A)){
            _moveVector -= transform.right;
            runDirection = 4;
        }

        //S2
        if(Input.GetKey(KeyCode.S)){
            _moveVector -= transform.forward;
            runDirection = 2;
        }

        //D3
        if(Input.GetKey(KeyCode.D)){
            _moveVector += transform.right;
            runDirection = 3;
        }

        animator.SetInteger("rundirection",runDirection);
    }

    private void JumpUpdate()
    {
        if (Input.GetKey(KeyCode.Space) && _characterController.isGrounded)
        {
            _fallVelocity = -jumpForce;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _characterController.Move( _moveVector * speed * Time.fixedDeltaTime);

        _fallVelocity += gravity * Time.fixedDeltaTime;
         _characterController.Move(Vector3.down * _fallVelocity * Time.fixedDeltaTime);

    }
}
