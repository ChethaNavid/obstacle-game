using UnityEngine;
using UnityEngine.UI; // If using Unity UI Text; or use TMPro for TextMeshPro

public class PlayerController : MonoBehaviour
{
    public Transform startPoint; // Drag your "Start" GameObject here in Inspector
    public GameObject EndGameUi; // Drag your "EndGameUI" Canvas here in Inspector
    public Color touchColor = Color.red; // Change to yellow if preferred

    private void Start()
    {
        // Set player position to start point at game start
        if (startPoint != null)
        {
            transform.position = startPoint.position;
            transform.rotation = startPoint.rotation; // Optional: Match rotation if needed
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        // Change color if it's an obstacle or sphere
        if (hit.collider.CompareTag("obstacle") || hit.collider.CompareTag("sphere"))
        {
            Renderer renderer = hit.collider.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.material.color = touchColor;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger entered with: " + other.name + " (Tag: " + other.tag + ")");
        if (other.CompareTag("Finish"))
        {
            Debug.Log("Finish detected! Activating UI.");
            if (EndGameUi != null)
            {
                EndGameUi.SetActive(true);
                Debug.Log("UI activated.");
            }
            else
            {
                Debug.LogError("EndGameUI is null—not assigned in Inspector!");
            }
            CharacterController cc = GetComponent<CharacterController>();
            if (cc != null)
            {
                cc.enabled = false;
                Debug.Log("Player movement disabled.");
            }
            else
            {
                Debug.LogError("No CharacterController on Player!");
            }
        }
    }
}