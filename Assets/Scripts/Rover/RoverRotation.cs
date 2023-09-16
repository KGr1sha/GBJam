using UnityEngine;

public class RoverRotation : MonoBehaviour
{
    private Vector2 inputDirection;

    void Update()
    {
        float hInput = Input.GetAxisRaw("Horizontal");
        float vInput = Input.GetAxisRaw("Vertical");

        inputDirection = new Vector2(hInput, vInput);

        if (inputDirection != Vector2.zero)
            transform.up = inputDirection;
    }
}
