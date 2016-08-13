using UnityEngine;

public class MoveScript : MonoBehaviour
{
    public float Speed;

    private float distance;

    void Awake()
    {
        this.distance = (Time.deltaTime * this.Speed);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            this.transform.Translate(0f, this.distance, 0f);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            this.transform.Translate(0f, -this.distance, 0f);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.transform.Translate(-this.distance, 0f, 0f);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            this.transform.Translate(this.distance, 0f, 0f);
        }
    }
}