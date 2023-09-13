using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class R3Teleport : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform playertransform;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")){
            // Assign the value to the class-level variable
            playertransform = other.transform;
            Vector3 targetPosition = new Vector3(546f, 81f, 804f);
            playertransform.position = targetPosition;
        }
    }

    // Update is called once per frame
    
}
