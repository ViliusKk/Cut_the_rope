using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
    private AudioSource sfx;

    void Start()
    {
        sfx = GetComponent<AudioSource>();
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Candy"))
        {
            sfx.Play();
        }
    }
}
