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
    void OnTriggerEnter2D(Collider2D collision)
    {
        var destroy = collision.gameObject;
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
        else if (collision.gameObject.CompareTag("Cursor"))
        {
            
        }
    }
    
    IEnumerator DestroyAfterSound()
    {
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
    }
}
