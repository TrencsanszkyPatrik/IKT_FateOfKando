using UnityEngine;

public class Sit : MonoBehaviour, IInteractable
{
    public Transform SitPosition;
    public bool isSitting = false;

    public void Interact()
    {
        GameObject player = GameObject.FindWithTag("Player");

        // Mozgásvezérlő script lekérése
        var playerMovementScript = player.GetComponent<Movement>(); // Cseréld ki a saját mozgás scripted nevére

        if (isSitting == false)
        {
            // Karakter leültetése
            player.transform.position = SitPosition.position;
            player.transform.rotation = SitPosition.rotation;

            // Mozgás letiltása és állapot frissítése
            if (playerMovementScript != null)
            {
                playerMovementScript.enabled = false;
            }
            isSitting = true;
        }
        else
        {
            // Karakter felállítása
            if (playerMovementScript != null)
            {
                playerMovementScript.enabled = true;
            }
            isSitting = false;
        }
    }
}
