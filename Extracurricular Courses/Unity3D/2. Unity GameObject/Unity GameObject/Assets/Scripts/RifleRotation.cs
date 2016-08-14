using UnityEngine;

public class RifleRotation : MonoBehaviour
{
    private const float RotationSpeed = 4.0f;

    void Update()
    {
        this.transform.Rotate(new Vector3(-Input.GetAxis("Mouse Y") * RotationSpeed, 0f, 0f));
    }
}