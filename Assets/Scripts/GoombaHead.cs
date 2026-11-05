
using UnityEngine;

public class GoombaHead : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") &&
            other.attachedRigidbody.linearVelocityY <= 0)
        {
            Destroy(transform.parent.gameObject);
        }
    }
}

