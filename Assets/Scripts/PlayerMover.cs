using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.AnimatedValues;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private Vector3 moveVector = Vector3.zero;
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private float gravity = 20f;
    [SerializeField] private float jumpForce = 6f;
    [SerializeField] private bool isGrounded = true;
    
    private CharacterController characterController;
    private Animator animator;
    private Rigidbody rigidbody;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        moveVector.y -= gravity * Time.deltaTime;
        characterController.Move(moveVector*moveSpeed*Time.deltaTime);
        SetAnimator();
    }


    private void OnMove(InputValue inputValue)
    {
        Debug.Log(inputValue.Get<Vector3>());
        moveVector = inputValue.Get<Vector3>();
    }

    private void SetAnimator()
    {
        animator.SetFloat("XSpeed", moveVector.x);
        animator.SetFloat("ZSpeed", moveVector.z);
    }

    
    private void OnJump(InputValue inputValue)
    {
        Debug.Log(inputValue.Get());
        if(inputValue.Get() != null && characterController.isGrounded)
        {
            moveVector.y = jumpForce;
        }
        else if(moveVector.y > 0) 
        {
            //moveVector.y = moveVector.y / 2;
        }
    }
    
}
