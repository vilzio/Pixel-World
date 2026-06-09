using UnityEngine;

public class DelayedDestroy : MonoBehaviour
{
    public float delay = 10f;
    
    void Start()
    {
        Destroy(gameObject, delay);
    }
}
