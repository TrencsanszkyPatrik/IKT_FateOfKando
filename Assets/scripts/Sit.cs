using UnityEngine;
public class Sit : MonoBehaviour, IInteractable
{
    public Camera playerCamera;
    public Camera cutsceneCamera;
    public Transform SitPosition;
    public Transform StandPosition;
    private QuestManager questManager;
    private GameObject player;
    private Movement playerMovementScript;
    public GameObject test;
    public bool isSitting = false;

    private bool canInteract = true;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerMovementScript = player.GetComponent<Movement>();
        questManager = FindFirstObjectByType<QuestManager>();
    }

    public void Interact()
    {
        if (!canInteract) return;

        canInteract = false;

        if (questManager.currentQuestIndex == 0)
        {
            SitDown();
            questManager.CompleteQuest(0);  
        } 
        else if(questManager.currentQuestIndex == 1) {
            StandUp();
        }
        else
        {

            DefaultInteract();
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

        playerCamera.gameObject.SetActive(false); // kurva anyad
        cutsceneCamera.gameObject.SetActive(true);
        test.SetActive(true);
        isSitting = true;
        Debug.Log("A karakter leült.");
    }

    private void StandUp()
    {
        SetPlayerPosition(StandPosition);
        playerMovementScript.enabled = true;
        test.SetActive(false);
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
