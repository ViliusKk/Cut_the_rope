using System.Collections;
using UnityEngine;

public class Candy : MonoBehaviour
{
    public AudioSource spikesfx;
    public AudioSource[] starsfx;
    public GameObject candyVFX;
    
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private bool isFrozen = false;
    private bool hasFrozen = false;
    private int count = 0;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (isFrozen)
        {
            rb.velocity = Vector2.zero;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Star"))
        {
            starsfx[count].Play();
            Star starScript = collision.GetComponent<Star>();
            if (starScript != null)
            {
                starScript.CollectAndDestroy(0.01f);
            }
            UIManager.instance.AddStar();
            count++;
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Spikes"))
        {
            spikesfx.Play();
            Instantiate(candyVFX, transform.position, Quaternion.identity);
            StartCoroutine(DestroyAfterSound());
        }
        else if (collision.gameObject.CompareTag("Cursor") && !isFrozen && !hasFrozen)
        {
            StartCoroutine(FreezeCandy(2f));
        }
    }
    
    IEnumerator DestroyAfterSound()
    {
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
    }
    
    IEnumerator FreezeCandy(float duration)
    {
        isFrozen = true;
        hasFrozen = true;

        rb.velocity = Vector2.zero;
        rb.gravityScale = 0;

        sr.color = Color.cyan;

        yield return new WaitForSeconds(duration);

        rb.gravityScale = 1;
        isFrozen = false;

        sr.color = Color.white;
    }
}
