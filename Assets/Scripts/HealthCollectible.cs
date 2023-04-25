using UnityEngine;


public class HealthCollectible : MonoBehaviour 
{
    public ParticleSystem healthParticle;
    public AudioClip healSound;
    

   
    void OnTriggerEnter2D(Collider2D other)
    {
        RubyController controller = other.GetComponent<RubyController>();

        if (controller != null)
        {
            controller.ChangeHealth(1);
            Instantiate(healthParticle, transform.position + Vector3.up * 0.5f, Quaternion.identity);
            controller.PlaySound(healSound);
            Destroy(gameObject);
        }
    }
}
