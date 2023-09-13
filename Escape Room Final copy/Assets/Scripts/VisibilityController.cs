using UnityEngine;

public class ObjectVisibilityController : MonoBehaviour
{
    public GameObject objectToMakeVisible;
    private bool hasBeenTouched = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasBeenTouched)
        {
            // Make the objectToMakeVisible visible
            objectToMakeVisible.SetActive(true);
            hasBeenTouched = true;
        }
    }
}

