using UnityEngine;

public class ProjectileEngine : MonoBehaviour
{
    private const float Speed = 8.0f;

    private float timeout;

    void Start()
    {
        this.timeout = 2.0f;
    }

    void Update()
    {
        this.transform.position += (this.transform.forward * (Time.deltaTime * Speed));

        this.timeout -= Time.deltaTime;

        if (this.timeout <= 0f)
        {
            Destroy(this.gameObject);
        }
    }
}