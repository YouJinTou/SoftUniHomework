using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    private const float RotationSpeed = 2.0f;

    void Update()
    {
        this.transform.Rotate(new Vector3(0f, Input.GetAxis("Mouse X") * RotationSpeed, 0f));
    }
}