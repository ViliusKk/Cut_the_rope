using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityFlip : MonoBehaviour
{
    public bool revertGravity = true;
    public AudioSource gravityOn;
    public AudioSource gravityOff;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Candy"))
        {
            gravityOn.Play();
            Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.gravityScale = -Mathf.Abs(rb.gravityScale);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (revertGravity && other.CompareTag("Candy"))
        {
            gravityOff.Play();
            Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.gravityScale = Mathf.Abs(rb.gravityScale);
            }
        }
    }
}
