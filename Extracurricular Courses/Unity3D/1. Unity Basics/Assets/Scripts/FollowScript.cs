using UnityEngine;

public class FollowScript : MonoBehaviour
{
    public Transform Guide;
    public float FollowSpeed;
    public float MinDistance;

    private float distance;

    void Awake()
    {
        this.distance = (this.FollowSpeed * Time.deltaTime);
    }

    void LateUpdate()
    {
        if (this.Guide == null)
        {
            return;
        }

        this.transform.LookAt(this.Guide);

        if (Vector3.Distance(this.transform.position, this.Guide.position) > this.MinDistance)
        {
            this.transform.Translate(0f, 0f, this.distance);
        }        
    }
}