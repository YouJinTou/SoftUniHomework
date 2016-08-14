using UnityEngine;

public class TurretShooting : MonoBehaviour
{
    private const float MinDistance = 15;

    public Transform Enemy;
    public GameObject TurretBullet;

    private float timeout;

    void Start()
    {
        this.timeout = 1f;
    }

    void Update()
    {
        this.OnEnemyApproaching();
    }

    private void OnEnemyApproaching()
    {
        this.timeout -= Time.deltaTime;

        if (this.timeout > 0)
        {
            return;
        }

        this.timeout = 1f;
        float distance = Vector3.Distance(this.transform.position, this.Enemy.transform.position);

        if (distance > MinDistance)
        {
            return;
        }

        GameObject bullet = Instantiate(this.TurretBullet);

        bullet.transform.position = this.TurretBullet.transform.parent.position;
        bullet.transform.LookAt(this.Enemy);
        bullet.AddComponent<ProjectileEngine>();
    }
}