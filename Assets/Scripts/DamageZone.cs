using UnityEngine;


public class DamageZone : MonoBehaviour 
{
    public int zone;
    void OnTriggerStay2D(Collider2D other)
    {
        RubyController controller = other.GetComponent<RubyController>();
        //if (zone == 1)
        //{
            if (controller != null)
            {
                controller.ChangeHealth(-1);
            }
       // }
        /*if(zone==2)
        {
            if(controller!=null)
            {
                controller.
            }
        }*/
    }
}
