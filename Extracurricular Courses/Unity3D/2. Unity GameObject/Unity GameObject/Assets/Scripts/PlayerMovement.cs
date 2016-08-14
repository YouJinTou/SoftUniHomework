using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float Speed;

    private float distance;

    void Awake()
    {
        this.distance = (Time.deltaTime * this.Speed);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            this.transform.Translate(0f, 0f, this.distance);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            this.transform.Translate(0f, 0f, -this.distance);
        }

        if (Input.GetKey(KeyCode.A))
        {
            this.transform.Translate(-this.distance, 0f, 0f);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            this.transform.Translate(this.distance, 0f, 0f);
        }
    }
}