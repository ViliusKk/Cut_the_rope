using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        Joint2D joint = collision.gameObject.GetComponent<Joint2D>();
        if(joint != null) Destroy(joint);
        
        // my variant
        // if (collision.gameObject.CompareTag("Rope") && gameObject.activeSelf)
        // {
        //     Destroy(collision.gameObject);
        // }
    }
}
