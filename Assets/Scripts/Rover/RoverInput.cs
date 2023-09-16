using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoverInput : MonoBehaviour
{
    private Vector2 input;
    private float horizontalInput;
    private float verticalInput;

    public Vector2 GetInputDir()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        input = new Vector2(horizontalInput, verticalInput).normalized;
        return input;
    }

    public bool IsSpacePressed()
    {
        return Input.GetKeyDown(KeyCode.Space);
    }
}
