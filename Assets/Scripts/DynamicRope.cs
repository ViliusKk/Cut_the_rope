using UnityEngine;

public class DynamicRope : MonoBehaviour
{
    public Transform pin;
    public Transform candy;
    public GameObject rope;
    void Start()
    {
        float distance = Vector2.Distance(pin.position, candy.position);
    }
    void Update()
    {
        //GameObject ropeObj = Instantiate(rope, 0, Quaternion.identity);
    }
}
