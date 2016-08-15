using UnityEngine;

public class Shooting : MonoBehaviour
{
    private const float BulletSpeed = 200f;

    public GameObject BulletHoleSprite;
    public GameObject Bullet;
    public GameObject Rifle;

    private Camera povCamera;
    private bool isInBulletHoleMode;

    void Start()
    {
        this.povCamera = Camera.main;
        this.isInBulletHoleMode = false;
    }

    void Update()
    {
        //if (Input.GetKey(KeyCode.Alpha1))
        //{
        //    this.isInBulletHoleMode = true;
        //}
        //else if (Input.GetKey(KeyCode.Alpha2))
        //{
        //    this.isInBulletHoleMode = false;
        //}

        if (Input.GetMouseButtonDown(0))
        {
            if (this.isInBulletHoleMode)
            {
                Ray ray = this.povCamera.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, 100f))
                {
                    GameObject bulletHole = Instantiate(this.BulletHoleSprite);

                    bulletHole.transform.position = hit.point;
                    bulletHole.transform.rotation = hit.collider.transform.rotation;
                }
            }
            else
            {
                Rigidbody bullet = Instantiate(this.Bullet).GetComponent<Rigidbody>();
                bullet.transform.position = this.Rifle.transform.position; // ?????

                bullet.AddRelativeForce(Vector3.forward * BulletSpeed);
            }
        }
    }
}