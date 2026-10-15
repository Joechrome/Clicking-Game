using UnityEngine;

public class Particles : MonoBehaviour
{
    public GameObject particlePrefab;
    public Transform spawnPoint;
    public Sprite Image;
    public float Size;
    public int particleAmount = 5;
    public float lifetime = 3;


    public void Trigger()
    {
        for (int i = 0; i < particleAmount; i++)
        {
            GameObject particle = Instantiate(particlePrefab, spawnPoint.position, Quaternion.identity);
            Rigidbody2D rb = particle.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                SpriteRenderer spriteRenderer = particle.GetComponent<SpriteRenderer>();
                spriteRenderer.sprite = Image;
                particle.transform.localScale = new Vector3(Size, Size, 1f);


                float randomX = Random.Range(-40, 40)/10f;
                float randomY = Random.Range(50, 90)/10f;
                rb.linearVelocity = new Vector2(randomX, randomY);

                float randomSpin = Random.Range(-120, 120);
                rb.angularVelocity = randomSpin;
            }

            Destroy(particle, lifetime);
        }
    }
}