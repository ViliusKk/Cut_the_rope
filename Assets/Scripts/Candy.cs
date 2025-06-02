using UnityEngine;

public class Candy : MonoBehaviour
{
    public AudioSource spikesfx;
    //public AudioSource starsfx;
    public GameObject candyVFX;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Star"))
        {
            Destroy(collision.gameObject);
            UIManager.instance.AddStar();
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Spikes"))
        {
            spikesfx.Play();
            Instantiate(candyVFX, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
