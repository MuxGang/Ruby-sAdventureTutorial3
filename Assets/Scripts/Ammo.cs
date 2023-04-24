using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnCollisionStay2D(Collision2D other)
    {
        RubyController controller = other.collider.GetComponent<RubyController>();

        if (controller != null)
            controller.ammoCount+=4;
    }
}
