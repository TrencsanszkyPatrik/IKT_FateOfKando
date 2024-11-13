using UnityEngine;
public class GenNum : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        Debug.Log("Küldetéstől függő interakció.");
        // Küldetéstől függő logika
    }

    public void DefaultInteract()
    {
        Debug.Log("Küldetéstől független interakció: generált szám.");
        int randomNum = Random.Range(1, 101);
        Debug.Log("Generált szám: " + randomNum);
        // Bármilyen alapértelmezett logika
    }
}
