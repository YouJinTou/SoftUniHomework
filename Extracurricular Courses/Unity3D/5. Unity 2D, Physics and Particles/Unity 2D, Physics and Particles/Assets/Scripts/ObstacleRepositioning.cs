using UnityEngine;

public class ObstacleRepositioning : MonoBehaviour
{
    private Rigidbody2D obstacle;

    void Start()
    {
        this.obstacle = GetComponent<Rigidbody2D>();
    }

    void OnTriggerExit2D(Collider2D other)
    {
        float newX = ((other.bounds.size.x / 2) + (this.obstacle.GetComponent<Collider2D>().bounds.size.x / 2));
        float currentY = this.obstacle.transform.position.y;

        this.obstacle.transform.position = new Vector3(newX, currentY, 0f);
    }
}
