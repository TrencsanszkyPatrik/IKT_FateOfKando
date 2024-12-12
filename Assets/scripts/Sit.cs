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

        if (questManager == null)
            questManager = FindFirstObjectByType<QuestManager>();

        if (playerMovement == null && player != null)
            playerMovement = player.GetComponent<Movement>();

        // Alapértelmezetten mindkét kamera lehet aktív
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

        // Explicit kameraváltás
        if (playerCamera != null) playerCamera.enabled = false;
        if (cutsceneCamera != null) cutsceneCamera.enabled = true;

        if (sittingStateUI != null)
            sittingStateUI.SetActive(true);

        isSitting = true;
        questManager.CompleteQuest(questManager.currentQuestIndex);
    }

    private void StandUp()
    {
        SetPlayerPosition(standPosition);

        playerMovement.enabled = true;
        Cursor.visible = false;

        // Explicit kameraváltás visszafelé
        if (cutsceneCamera != null) cutsceneCamera.enabled = false;
        if (playerCamera != null) playerCamera.enabled = true;

        if (sittingStateUI != null)
            sittingStateUI.SetActive(false);

        isSitting = false;
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