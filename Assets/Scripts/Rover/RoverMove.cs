using System.Collections;
using System.Collections.Generic;
using UnityEditor.XR;
using UnityEngine;

public class RoverMove : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f;
    private Rigidbody2D roverRigidbody;

    private RoverInput inputScript;
    private Vector2 inputDirection;

    private bool isMining;

    public void SetMiningState(bool x)
    {
        isMining = x;
    }

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
        if(isMining == false)
            roverRigidbody.MovePosition(roverRigidbody.position + moveSpeed * Time.fixedDeltaTime * inputDirection);
    }
}
