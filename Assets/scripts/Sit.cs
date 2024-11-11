using UnityEngine;

public class Sit : MonoBehaviour, IInteractable
{
    public Transform SitPosition; 
    public Transform StandPosition; 
    public bool isSitting = false; 

    private GameObject player;
    private Movement playerMovementScript;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerMovementScript = player.GetComponent<Movement>();
    }

    public void Interact()
    {
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
    }

    void Update()
    {
        if (isSitting && Input.GetKeyDown(KeyCode.E))
        {
            Interact();
        }
    }
}
