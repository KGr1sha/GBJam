using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoverMove : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f;
    private Rigidbody2D roverRigidbody;

    private RoverInput inputScript;
    private Vector2 inputDirection;

    private void Start()
    {
        inputScript = GetComponent<RoverInput>();
        roverRigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        inputDirection = inputScript.GetInputDir();
    }


    private void FixedUpdate()
    {
        roverRigidbody.MovePosition(roverRigidbody.position + inputDirection * moveSpeed * Time.fixedDeltaTime);
    }
}
