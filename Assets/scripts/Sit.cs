using UnityEngine;

public class Sit : MonoBehaviour, IInteractable
{
    public Transform SitPosition;
    public Transform StandPosition;
    public bool isSitting = false;

    private GameObject player;
    private Movement playerMovementScript;
    private bool canInteract = true;  

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerMovementScript = player.GetComponent<Movement>();
    }

    public void Interact()
    {
        if (!canInteract) return;  

        canInteract = false;  

        if (isSitting == false)
        {
            player.transform.position = SitPosition.position;
            player.transform.rotation = SitPosition.rotation;

            if (playerMovementScript != null)
            {
                playerMovementScript.enabled = false;
            }
            isSitting = true;
        }
        else
        {
            player.transform.position = StandPosition.position;
            player.transform.rotation = StandPosition.rotation;
            if (playerMovementScript != null)
            {
                playerMovementScript.enabled = true;
            }
            isSitting = false;
        }

        Invoke("EnableInteraction", 1f); 
    }

    void EnableInteraction()
    {
        canInteract = true;  
    }

    void Update()
    {
        if (isSitting && Input.GetKeyDown(KeyCode.E) && canInteract)
        {
            Interact();
        }
    }
}
