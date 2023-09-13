using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTeleport : MonoBehaviour
{
    public GameObject Player;     
    public GameObject TeleportTo; 

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Teleporter"))
        {
            if (Player != null && TeleportTo != null)
            {
                
                Player.transform.position = TeleportTo.transform.position;
            }
            else
            {
                Debug.LogError("Player or TeleportTo GameObject is not assigned!");
            }
        }
    }
}
