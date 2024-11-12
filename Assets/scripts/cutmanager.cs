using UnityEngine;

public class CutsceneController : MonoBehaviour
{
    public Camera playerCamera;      
    public Camera cutsceneCamera;    
    public Animator cutsceneAnimator; 

    private void Start()
    {
        playerCamera.gameObject.SetActive(false);
        cutsceneCamera.gameObject.SetActive(true);

        if (cutsceneAnimator != null)
        {
            cutsceneAnimator.Play("CutsceneAnimation");
        }

        Invoke("EndCutscene", 3f); 
    }

    void EndCutscene()
    {
        cutsceneCamera.gameObject.SetActive(false);
        playerCamera.gameObject.SetActive(true);
    }
}
