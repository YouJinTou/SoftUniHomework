using UnityEngine;
using UnityEngine.SceneManagement;

public class Flying : MonoBehaviour
{
    private const float Velocity = 2f;
    private const float UpwardBurstCoef = 3.5f;
    private readonly Vector2 MaxVelocityVector = (Vector2.up * UpwardBurstCoef);

    private Rigidbody2D projectile;

    private float VelocityMagnitude
    {
        get
        {
            return (Vector2.up * UpwardBurstCoef + this.projectile.velocity).magnitude;
        }
    }

    void Start()
    {
        this.projectile = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetMouseButton(0) || Input.GetKey(KeyCode.Space))
        {
            this.PropelUpward();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name != "Background")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }    

    void OnTriggerExit2D(Collider2D other)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void PropelUpward()
    {
        this.projectile.gravityScale = 0.5f;

        bool tooHighMagnitude = (this.VelocityMagnitude >= MaxVelocityVector.magnitude);

        if (tooHighMagnitude)
        {
            float adjustedUpwardBurstCoef = 1.75f;

            this.projectile.AddForce(Vector2.up * adjustedUpwardBurstCoef, ForceMode2D.Impulse);
        }
        else
        {
            this.projectile.AddForce(Vector2.up * UpwardBurstCoef, ForceMode2D.Impulse);
        }

        this.projectile.gravityScale = 1.5f;
    }
}