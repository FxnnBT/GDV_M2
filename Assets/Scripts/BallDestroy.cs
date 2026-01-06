using UnityEngine;

public class BallDestroy : MonoBehaviour
{
    public float destroyDelay = 3f;
    public GameObject destroyParticles;

    private float lastCollisionTime;
    private Rigidbody2D rb;
    private bool isDestroyed = false;

    void Start()
    {
        lastCollisionTime = Time.time;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (isDestroyed) return;

        if (Time.time - lastCollisionTime > destroyDelay &&
            rb.linearVelocity.magnitude < 0.1f)
        {
            DestroyWithEffect();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        lastCollisionTime = Time.time;
    }

    void DestroyWithEffect()
    {
        isDestroyed = true;

        if (destroyParticles != null)
        {
            Instantiate(destroyParticles, transform.position, Quaternion.identity);
        }

        Destroy(gameObject);
    }
}
