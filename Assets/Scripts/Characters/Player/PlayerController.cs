using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerController : CharacterController
{
    private Camera _cam;
    private Player _player;

    private Vector3 _moveDirection;

    private void Awake()
    {
        _cam = Camera.main;
    }

    private void Start()
    {
        _player = GetComponent<Player>();
    }

    private void Update()
    {
        ApplyRotation();
    }

    private void FixedUpdate()
    {
        ApplyMovement();
    }

    public void OnMove(InputValue value)
    {
        Vector2 moveInput = value.Get<Vector2>().normalized;
        _moveDirection = new Vector3(moveInput.x, 0f, moveInput.y);

        _player.Animator.SetBool("isWalk", true);
    }

    public void OnRun()
    {

    }

    public void OnAttack()
    {
        _player.Animator.SetTrigger("Attack");
    }

    private void ApplyMovement()
    {
        Vector3 playerDirection = _player.transform.TransformDirection(_moveDirection);
        Vector3 moveVelocity = playerDirection.normalized * _player.PlayerData.GroundData.BaseSpeed;
        _player.Rigidbody.velocity = new Vector3(moveVelocity.x, _player.Rigidbody.velocity.y, moveVelocity.z);
    }

    private void ApplyRotation()
    {
        Vector3 cameraForward = _cam.transform.forward;
        cameraForward.y = 0f;

        transform.rotation = Quaternion.LookRotation(cameraForward);
    }
}
