using UnityEngine;

public class Particles : MonoBehaviour
{
    public GameObject particlePrefab;
    public Transform spawnPoint;
    public int particleAmount = 15;
    public float lifetime = 3;

    public void Trigger()
    {
        for (int i = 0; i < particleAmount; i++)
        {
            GameObject particle = Instantiate(particlePrefab, spawnPoint.position, Quaternion.identity);

            Rigidbody2D rb = particle.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                float randomX = Random.Range(-4, 4);
                float randomY = Random.Range(5, 9);
                rb.linearVelocity = new Vector2(randomX, randomY);

                float randomSpin = Random.Range(-120, 120);
                rb.angularVelocity = randomSpin;
            }

            // Clean up / destroy the particle after its lifetime to prevent lag
            Destroy(particle, lifetime);
        }
    }
}