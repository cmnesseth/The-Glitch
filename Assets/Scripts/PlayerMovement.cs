// 2024-04-29 AI-Tag 
// This was created with assistance from Muse, a Unity Artificial Intelligence product

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    private Rigidbody2D rb;
    private PlayerInput playerInput;
    private Vector2 move;

    void Start()
    {
        // Get the Rigidbody2D and PlayerInput components
        rb = GetComponent<Rigidbody2D>();
        playerInput = GetComponent<PlayerInput>();
    }

    void OnMove(InputValue value)
    {
        // Read the input value
        move = value.Get<Vector2>();
    }

    void FixedUpdate()
    {
        // Apply the input to the Rigidbody2D for physics-based movement
        rb.velocity = move * moveSpeed;
    }
}
