using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private const float EarthAcceleration = 9.81f;
    private const float AccelerationInAir = 19.82f;
    private const float JumpForce = 3f;
    private const float SpeedCoeff = 2.5f;
    private const float MouseSpeedX = 1f;
    private const float MouseSpeedY = 1f;

    private Rigidbody heroRigidBody;
    private Camera povCamera;
    private bool isGrounded;

    void Start()
    {
        Physics.gravity = Vector3.down * EarthAcceleration;
        this.heroRigidBody = GetComponent<Rigidbody>();
        this.povCamera = Camera.main;
    }

    void Update()
    {
        this.UpdateSpatialMovement();
        this.UpdateMouseMovement();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            this.Jump();
        }
    }    

    private void UpdateSpatialMovement()
    {
        Vector3 velocityVector = new Vector3(this.heroRigidBody.velocity.x, this.heroRigidBody.velocity.z, 0f); // Can't go up the y-axis
        this.heroRigidBody.velocity = new Vector3(velocityVector.x, this.heroRigidBody.velocity.y, velocityVector.y);

        this.heroRigidBody.AddRelativeForce(Input.GetAxis("Horizontal") * SpeedCoeff, 0f, Input.GetAxis("Vertical") * SpeedCoeff, ForceMode.Force);
    }

    private void UpdateMouseMovement()
    {
        float mouseHorizontal = (this.transform.rotation.eulerAngles.y + (Input.GetAxis("Mouse X") * MouseSpeedY));
        float mouseVertical = (this.povCamera.transform.localRotation.eulerAngles.x - (Input.GetAxis("Mouse Y") * MouseSpeedX));
        this.transform.rotation = Quaternion.Euler(0f, mouseHorizontal, 0f); // parent
        this.povCamera.transform.localRotation = Quaternion.Euler(mouseVertical, 0f, 0f); // child
    }

    private void Jump()
    {
        if (!this.isGrounded) // We are in the air; can't jump again
        {
            return;
        }

        this.heroRigidBody.AddForce(0f, EarthAcceleration * JumpForce, 0f);
    }

    private void SetGravity(int type)
    {
        Physics.gravity = Vector3.down * ((type == 1) ? EarthAcceleration : AccelerationInAir);
    }

    private void OnTriggerStay(Collider col)
    {
        if (col.tag == "Floor" && !this.isGrounded)
        {
            this.isGrounded = true;
        }
    }

    private void OnTriggerEnter (Collider col)
    {
        if (col.tag == "Floor" && !this.isGrounded)
        {
            this.SetGravity(1);

            this.isGrounded = true;
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.tag == "Floor" && this.isGrounded)
        {
            this.SetGravity(2);

            this.isGrounded = false;
        }
    }
}