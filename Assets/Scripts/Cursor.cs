using System.Collections;
using UnityEngine;

public class Cursor : MonoBehaviour
{
    public AudioSource[] sfx;
    void OnCollisionEnter2D(Collision2D collision)
    {
        Joint2D joint = collision.gameObject.GetComponent<Joint2D>();
        if (joint != null)
        {
            sfx[Random.Range(0, sfx.Length)].Play();
            StartCoroutine(DestroyAfterSound(joint));
        }
    }
    
    IEnumerator DestroyAfterSound(Joint2D joint)
    {
        yield return new WaitForSeconds(0.1f);
        Destroy(joint);
    }
}
