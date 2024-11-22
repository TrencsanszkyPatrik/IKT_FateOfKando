using System.Collections;
using UnityEngine;
public class Sit_random : MonoBehaviour, IInteractable
{

    public Transform SitPosition;
    public Transform StandPosition;
    private GameObject player;
    private Movement playerMovementScript;
    public bool isSitting = false;
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

        if (!isSitting) {
            SitDown();
            Debug.Log("Leült");
        } else {
            StandUp();
            Debug.Log("Felállt;");
        }


        Invoke("EnableInteraction", 1f);
    }

    void Update()
    {
        if (isSitting && Input.GetKeyDown(KeyCode.E) && canInteract)
        {
            Interact();
        }
    }

    public void DefaultInteract()
    {
        Debug.Log("Küldetéstől független interakció történt.");
        
    }

    private void SitDown()
    {
        SetPlayerPosition(SitPosition);
        playerMovementScript.enabled = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        isSitting = true; 
        Debug.Log("A karakter leült.");
    }

    private void StandUp()
    {
        SetPlayerPosition(StandPosition);
        playerMovementScript.enabled = true;
        Cursor.visible = false;
        isSitting = false;
        Cursor.lockState = CursorLockMode.Locked; 
        Debug.Log("A karakter felállt.");
    }

    private void SetPlayerPosition(Transform position)
    {
        player.transform.position = position.position;
        player.transform.rotation = position.rotation;
    }

    private void EnableInteraction()
    {
        canInteract = true;
    }


}
