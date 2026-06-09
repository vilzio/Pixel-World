using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public bool isGrounded;

    private void OnTriggerStay(Collider other)
    {
        isGrounded = true;
    }
    
    private void OnTriggerExit(Collider other)
    {
        isGrounded = false;
    }
}
