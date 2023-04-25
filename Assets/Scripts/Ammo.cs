using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    public int reload =4;
    public RubyController player;
    public GameObject particle;

    void TriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            player.ammoCount += reload;
            Destroy(gameObject);
        }
        
        
        /*RubyController controller = other.GetComponent<RubyController>();

        if (controller != null)
        {
            controller.ammoCount += 4;
            Destroy(gameObject);
        }*/
    }
}
