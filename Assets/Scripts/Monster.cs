using UnityEngine;

public class Monster : MonoBehaviour
{
    public float horizontalLimit = 1.6f;
    Vector3 offset;
    bool isDragging = false;
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(mousePos))
            {
                offset = transform.position - (Vector3)mousePos;
                isDragging = true;
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }

        if (isDragging)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            float newX = Mathf.Clamp(mousePos.x + offset.x, -horizontalLimit, horizontalLimit);
            transform.position = new Vector3(newX, transform.position.y, transform.position.z);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Candy"))
        {
            Destroy(collision.gameObject);
            
            UIManager.instance.OpenNextLevelScreen();
        }
    }
}