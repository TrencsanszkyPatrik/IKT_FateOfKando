using System.Collections;
using UnityEngine;
public class Sit : MonoBehaviour, IInteractable
{
    public GameObject playerCamera;
    public GameObject cutsceneCamera;
    public Transform SitPosition;
    public Transform StandPosition;
    private QuestManager questManager;
    private GameObject player;
    private Movement playerMovementScript;
    public GameObject kep;
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

        if (questManager.currentQuestIndex == 1)
        {
            SitDown();
            questManager.CompleteQuest(1);  
        }
        else if (questManager.currentQuestIndex == 2 && isSitting)
        {
            StandUp();  
        }
        else
        {
            DefaultInteract();
        }

        Invoke("EnableInteraction", 1f);
    }

    public void DefaultInteract()
    {
        Debug.Log("Küldetéstől független interakció történt.");
        // Ha a karakter ül, akkor mindig fel tud állni
        if (isSitting && Input.GetKeyDown(KeyCode.E) && canInteract)
        {
            StandUp();
        }
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
        StartCoroutine(SwitchToCutsceneCamera());
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
        StartCoroutine(SwitchToPlayerCam());
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


    private IEnumerator SwitchToCutsceneCamera()
    {
        yield return null;
        kep.gameObject.SetActive(false);
        playerCamera.gameObject.SetActive(false);
        cutsceneCamera.gameObject.SetActive(true);
        Debug.Log("Váltás cutscene kamerára.");
    }

    private IEnumerator SwitchToPlayerCam()
    {
        yield return null;
        kep.gameObject.SetActive(true);
        playerCamera.gameObject.SetActive(true);
        cutsceneCamera.gameObject.SetActive(false);
        Debug.Log("Váltás play kamerára.");
    }
}
