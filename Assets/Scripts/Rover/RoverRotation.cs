using UnityEngine;

public class RoverRotation : MonoBehaviour
{
    private RoverInput roverInputScript;
    private Vector2 inputDirection;

    void Start()
    {
        roverInputScript = GetComponent<RoverInput>();    
    }

    void Update()
    {
        inputDirection = roverInputScript.GetInputDir();
        if(inputDirection != Vector2.zero)
            transform.up = inputDirection;
    }
}
