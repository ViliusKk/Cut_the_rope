using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityFlip : MonoBehaviour
{
    public bool revert = true;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Candy"))
        {
            Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.gravityScale = -Mathf.Abs(rb.gravityScale);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (revert && other.CompareTag("Candy"))
        {
            Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.gravityScale = Mathf.Abs(rb.gravityScale);
            }
        }
    }
}
