using UnityEngine;

public class PushObject : MonoBehaviour
{
    public float pushForce = 5f;
    private float lastPushTime = -1f;
    private float pushCooldown = 0.1f;

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (Time.time - lastPushTime < pushCooldown) return;

        // Skip if it's a wall
        if (hit.collider.CompareTag("wall")) return;

        Rigidbody rb = hit.collider.attachedRigidbody;
        if (rb != null && !rb.isKinematic)
        {
            Vector3 pushDir = hit.moveDirection;
            rb.AddForce(pushDir * pushForce, ForceMode.Impulse);
            lastPushTime = Time.time;
        }
    }
}