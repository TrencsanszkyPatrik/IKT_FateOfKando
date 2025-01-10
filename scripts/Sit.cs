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

    private GameObject player;
    private bool isSitting = false;
    private bool canInteract = true;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        if (player == null)
        {
            Debug.LogError("Player object not found!");
        }

        if (questManager == null)
        {
            questManager = FindObjectOfType<QuestManager>(); // Use FindObjectOfType if you need to find QuestManager in the scene
            if (questManager == null)
            {
                Debug.LogError("QuestManager not found!");
            }
        }

        if (playerMovement == null && player != null)
        {
            playerMovement = player.GetComponent<Movement>();
            if (playerMovement == null)
            {
                Debug.LogError("Movement component not found on player!");
            }
        }

        // Default state: enable player camera and disable cutscene camera
        if (playerCamera != null) playerCamera.enabled = true;
        if (cutsceneCamera != null) cutsceneCamera.enabled = false;
    }

    public void Interact()
    {
        if (!canInteract) return;

        if (!isSitting)
        {
            SitDown();
        }
        else
        {
            StandUp();
        }

        canInteract = false;
        Invoke(nameof(EnableInteraction), 0.5f); // Could increase delay for better user feedback
    }

    public void DefaultInteract()
    {
        Debug.Log("Nem tudod most leültetni a karaktert!");
    }

    private void SitDown()
    {
        SetPlayerPosition(sitPosition);

        if (playerMovement != null)
        {
            playerMovement.enabled = false;
        }
        Cursor.visible = true;

        // Switch cameras
        if (cutsceneCamera != null) cutsceneCamera.gameObject.SetActive(true);
        if (playerCamera != null) playerCamera.gameObject.SetActive(false);

        if (sittingStateUI != null)
            sittingStateUI.SetActive(true);

        isSitting = true;
    }

    private void StandUp()
    {
        SetPlayerPosition(standPosition);

        if (playerMovement != null)
        {
            playerMovement.enabled = true;
        }
        Cursor.visible = false;

        // Switch cameras back to player view
        if (cutsceneCamera != null) cutsceneCamera.gameObject.SetActive(false);
        if (playerCamera != null) playerCamera.gameObject.SetActive(true);

        if (sittingStateUI != null)
            sittingStateUI.SetActive(false);

        isSitting = false;

        // Complete quest if applicable
        if (questManager != null)
        {
            questManager.CompleteQuest(questManager.currentQuestIndex);
        }
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
}
