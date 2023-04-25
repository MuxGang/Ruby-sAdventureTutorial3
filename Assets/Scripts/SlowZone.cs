using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowZone : MonoBehaviour
{
    private RubyController ruby;
    public bool isPlayerHere = false;

    void Start()
    {
        ruby = FindObjectOfType<RubyController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            isPlayerHere = true;
            ruby.speed /= 2f;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            isPlayerHere = false;
            ruby.speed *= 2f;
        }
    }

   /* void Update()
    {
        if(isPlayerHere)
        {
            ruby.speed /= 2f;
        }
        else
        {
            ruby.speed *= 2f;
        }
    }*/
}
