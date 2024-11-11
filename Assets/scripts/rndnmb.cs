using UnityEngine;

public class NumGen : MonoBehaviour, IInteractable {
    public void Interact(){
        Debug.Log(Random.Range(0, 100));
    }
}