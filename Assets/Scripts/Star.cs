using System.Collections;
using UnityEngine;

public class Star : MonoBehaviour
{
    public void CollectAndDestroy(float delay)
    {
        StartCoroutine(DestroyAfterDelay(delay));
    }

    IEnumerator DestroyAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }
}
