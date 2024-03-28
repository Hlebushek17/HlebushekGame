using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    private float _fallVelocity = 0;
    
    public float gravity = 9.8f;

    public float  jumpForce;
    public float speed;

    private Vector3 _moveVector;


    private CharacterController _characterController;

    // Start is called before the first frame update
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    void Update(){

        _moveVector = Vector3.zero;

        //W
        if(Input.GetKey(KeyCode.W)){
            _moveVector += transform.forward;
        }

        //A
        if(Input.GetKey(KeyCode.A)){
            _moveVector -= transform.right;
        }

        //S
        if(Input.GetKey(KeyCode.S)){
            _moveVector -= transform.forward;
        }

        //D
        if(Input.GetKey(KeyCode.D)){
            _moveVector += transform.right;
        }

        if(_moveVector != Vector3.zero)
        {
            animator.SetBool("isRun",true);
        }
        else
        {
            animator.SetBool("isRun",false);
        }                           

        //Jump
        if(Input.GetKeyDown(KeyCode.Space) && _characterController.isGrounded){
            _fallVelocity = -jumpForce;
            animator.SetBool("isGrounded",false);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _characterController.Move( _moveVector * speed * Time.fixedDeltaTime);

        _fallVelocity += gravity * Time.fixedDeltaTime;
         _characterController.Move(Vector3.down * _fallVelocity * Time.fixedDeltaTime);

         if(_characterController.isGrounded){
            _fallVelocity = 0;
            animator.SetBool("isGrounded",true);
         }
    }
}
