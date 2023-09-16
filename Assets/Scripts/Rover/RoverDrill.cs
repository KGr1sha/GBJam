using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RoverDrill : MonoBehaviour
{
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private float castDistance;
    [SerializeField] private LayerMask mineralMask;
    
    private RaycastHit2D hit;
    private Vector2 castSize;
    private RoverMove moveScript;

    private void Start()
    {
        moveScript = GetComponent<RoverMove>();
        castSize = new Vector2(boxCollider.bounds.size.x * 0.5f, boxCollider.bounds.size.y * 0.3f);
        castDistance *= 0.1f;
    }

    private void Update()
    {
        if (IsNearMineral() && Input.GetKeyDown(KeyCode.Space))
        {
            Drill();
        }
    }

    private bool IsNearMineral()
    {
        hit = Physics2D.BoxCast(transform.position, castSize, transform.eulerAngles.z, transform.up, castDistance, mineralMask); ;
        return hit.collider != null;
    }

    private void OnDrawGizmos()
    {
        if (IsNearMineral())
            Gizmos.color = Color.green;
        else
            Gizmos.color = Color.red;

        Gizmos.DrawWireCube(transform.position + transform.up * castDistance, castSize);
    }

    private void Drill()
    {

        
    }
}
