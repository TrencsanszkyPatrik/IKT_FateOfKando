using UnityEngine;
using UnityEngine.UI;

public class CutsceneController : MonoBehaviour
{
    public Camera playerCamera;      
    public Camera cutsceneCamera;
    public RawImage kep;
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
        kep.gameObject.SetActive(false);
        cutsceneCamera.enabled = false;
        playerCamera.gameObject.SetActive(true);
    }
}
