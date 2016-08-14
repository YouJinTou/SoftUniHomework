using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject RifleBullet;

    void Update()
    {
        this.OnLeftMouseClick();
    }

    private void OnLeftMouseClick()
    {
        if (!Input.GetMouseButtonDown(0))
        {
            return;
        }

        GameObject bullet = Instantiate(this.RifleBullet);
        Vector3 target = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 50f));

        bullet.transform.position = this.RifleBullet.transform.parent.position;
        bullet.transform.LookAt(target);
        bullet.AddComponent<ProjectileEngine>();
    }
}