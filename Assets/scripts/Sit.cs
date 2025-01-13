using UnityEngine;
using System.Collections;

public class Sit : MonoBehaviour, IInteractable
{
    [Header("Camera References")]
    [SerializeField] private Camera playerCamera;
    [SerializeField] private Camera cutsceneCamera;

    [Header("Position References")]
    [SerializeField] private Transform sitPosition;
    [SerializeField] private Transform standPosition;

    [Header("Game Components")]
    [SerializeField] private QuestManager questManager;
    [SerializeField] private Movement playerMovement;

    [Header("Interaction Settings")]
    [SerializeField] private GameObject sittingStateUI;
    [SerializeField] private GameObject test;

    [SerializeField] private GameObject kep;

    private GameObject player;
    private bool isSitting = false;
    private bool canInteract = true;
    private bool hasSatDown = false; 

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        if (questManager == null)
            questManager = FindFirstObjectByType<QuestManager>();

        if (playerMovement == null && player != null)
            playerMovement = player.GetComponent<Movement>();
        if (cutsceneCamera != null) cutsceneCamera.gameObject.SetActive(false);
    }

    public void Interact()
    {

        if (questManager == null)
            questManager = FindFirstObjectByType<QuestManager>();

        Debug.Log($"Current quest index: {questManager.currentQuestIndex}");
        Debug.Log($"Has sat down: {hasSatDown}");

        if (!isSitting && !hasSatDown && questManager.currentQuestIndex == 1)
        {
            SitDown();
            questManager.CompleteQuest(1);
        }
        else if (isSitting)
        {
            StandUp();
        }

        canInteract = false;
        Invoke(nameof(EnableInteraction), 0.5f);
    }


    public void DefaultInteract()
    {
        Debug.Log("Nem tudod most leültetni a karaktert!");
    }

    private void SitDown()
    {
        SetPlayerPosition(sitPosition);
        playerMovement.enabled = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        playerCamera.gameObject.SetActive(false);
        cutsceneCamera.gameObject.SetActive(true);
        test.SetActive(true);
        isSitting = true;
        hasSatDown = true;
        Debug.Log("Character sat down. hasSatDown set to true.");
        StartCoroutine(SwitchToCutsceneCamera());
    }


    private void StandUp()
    {
        SetPlayerPosition(standPosition);
        playerMovement.enabled = true;
        test.SetActive(false);
        Cursor.visible = false;
        isSitting = false;
        Cursor.lockState = CursorLockMode.Locked;
        StartCoroutine(SwitchToPlayerCam());
        Debug.Log("A karakter felállt.");
    }

    private void SetPlayerPosition(Transform targetPosition)
    {
        if (player != null)
        {
            player.transform.position = targetPosition.position;
            player.transform.rotation = targetPosition.rotation;
        }
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
