using TMPro;
using UnityEngine;

interface IInteractable {
    public void Interact();
}

public class Interact : MonoBehaviour
{
    public TMP_Text text;
    public Transform InteractSource;
    public float InteractRange;

    void Start()
    {
        text.enabled = false; // A szöveg alapértelmezetten rejtve van
    }

    void Update()
    {
        Ray r = new Ray(InteractSource.position, InteractSource.forward);
        if (Physics.Raycast(r, out RaycastHit hitInfo, InteractRange))
        {
            if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactObj))
            {
                text.enabled = true; // Megjeleníti a "(E) interakció" szöveget

                if (Input.GetKeyDown(KeyCode.E))
                {
                    interactObj.Interact(); // Az interakció végrehajtása
                }
                return;
            }
        }

        // Ha nincs interakciós objektum a hatótávban, elrejti a szöveget
        text.enabled = false;
    }
}
