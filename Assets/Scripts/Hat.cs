using UnityEngine;

public class Hat : MonoBehaviour
{
    public Transform hatOut;
    private AudioSource sfx;

    void Start()
    {
        sfx = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        other.transform.position = hatOut.position;
        if (other.gameObject.CompareTag("Candy"))
        {
            sfx.Play();
        }
    }
}
