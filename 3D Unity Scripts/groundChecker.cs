using UnityEngine;

//Scripts for checking is the immediate object is standing on the ground, provided the object has a collider set up for checking ground collision
//This script requires my BoolData scriptable object script and the cooresponding asset titled GroundCheck 

public class groundChecker : MonoBehaviour
{
    //establishing our BoolData variable for ground checks
    public BoolData GC;

    //as long as player is on the ground the groundcheck bool is set to true. This requires ground objects being tagged as "Ground"
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            GC.value = true;

        }

        
    }

    //once Groundcheck collider has left the ground we set the GroundCheck to false until we are back on the ground.
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            GC.value = false;

        }
    }
}
