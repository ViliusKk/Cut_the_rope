using System.Collections;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    private Rigidbody2D candy;
    private AudioSource sfx;

    void Start()
    {
        sfx = GetComponent<AudioSource>();
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Candy"))
        {
            sfx.Play();
            transform.position = other.transform.position;
            transform.parent = other.transform;
            
            candy = other.gameObject.GetComponent<Rigidbody2D>();
            candy.gravityScale = -1;
        }
        else if (other.gameObject.CompareTag("Cursor") && candy != null)
        {
            sfx.Play();
            candy.gravityScale = 1;
            StartCoroutine(DestroyAfterSound());
        }
    }
    
    IEnumerator DestroyAfterSound()
    {
        yield return new WaitForSeconds(0.02f);
        Destroy(gameObject);
    }
}
