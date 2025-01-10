using UnityEngine;

public class hangeffektek : MonoBehaviour
{
    public AudioSource AudioSource;
    public AudioClip AudioClip;
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
        }
    }
}
