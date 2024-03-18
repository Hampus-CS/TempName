using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float moveSpeed = 1f;

    private PlayerControls playerControls;
    private Vector2 movement;
    private Rigidbody2D rb;

    //

    void Awake()
    {
        playerControls = new PlayerControls();
        rb = GetComponent<Rigidbody2D>();
    }

    void OnEnable()
    {
        playerControls.Enable();
    }

    void Update()
    {
        PlayerInput();
    }

    void FixedUpdate()
    {
        Move();
    }

    //

    void PlayerInput()
    {
        movement = playerControls.Movement.Move.ReadValue<Vector2>();
    }

    void Move()
    {
        rb.MovePosition(rb.position + movement * (moveSpeed * Time.fixedDeltaTime));
    }
}
