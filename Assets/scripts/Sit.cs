using UnityEngine;
using UnityEngine.UI;

public class Sit : MonoBehaviour, IInteractable
{
    public Transform SitPosition;
    public Transform StandPosition;
    public bool isSitting = false;

    private GameObject player;
    private Movement playerMovementScript;
    private bool canInteract = true;
    public GameObject test;


    public Toggle t1;
    public Toggle t2;

    void Start()
    {
        t1.isOn = false;    
        t2.isOn = false;
        player = GameObject.FindWithTag("Player");
        playerMovementScript = player.GetComponent<Movement>();
    }

    public void Interact()
    {
        if (!canInteract) return;

        canInteract = false;

        if (isSitting == false)
        {
            SitDown();
            

        }
        else
        {
            Up();
        }

        Invoke("EnableInteraction", 1f);

    }

    void SitDown()
    {
        player.transform.position = SitPosition.position;
        player.transform.rotation = SitPosition.rotation;

        if (playerMovementScript != null)
        {
            playerMovementScript.enabled = false;
        }
        isSitting = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        test.SetActive(true);
    }

    void Up()
    {
        player.transform.position = StandPosition.position;
        player.transform.rotation = StandPosition.rotation;
        if (playerMovementScript != null)
        {
            playerMovementScript.enabled = true;
        }
        isSitting = false;
        test.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    void EnableInteraction()
    {
        canInteract = true;
    }

    void Update()
    {
        if (t1.isOn)
        {
            Debug.Log("Az egyes be van kapcsolva");
        }
        if (isSitting && Input.GetKeyDown(KeyCode.E) && canInteract)
        {
            
            Interact();
        }
    }
}
