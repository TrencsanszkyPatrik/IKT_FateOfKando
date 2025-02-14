using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class CutsceneController : MonoBehaviour
{
    public Camera playerCamera;
    public Camera cutsceneCamera;
    public RawImage kep;
    public Animator cutsceneAnimator;
    

    public PlayableDirector timeline1;  
    public PlayableDirector timeline2;  


    private static bool hasPlayedCutscene = false;

    private void Start()
    {
        Scene scene = SceneManager.GetActiveScene();

        if (scene.name == "Jatek")
        {
            if (!hasPlayedCutscene)
            {
                if (timeline1 != null)
                    timeline1.Play();
                if (timeline2 != null)
                    timeline2.Play();

                playerCamera.gameObject.SetActive(false);
                cutsceneCamera.gameObject.SetActive(true);

                if (cutsceneAnimator != null)
                {
                    cutsceneAnimator.Play("CutsceneAnimation");
                }

                Invoke("EndCutscene", 3f);

                hasPlayedCutscene = true;
            }
            else
            {
                playerCamera.gameObject.SetActive(true);
                cutsceneCamera.gameObject.SetActive(false);
            }
        }
    }

    void EndCutscene()
    {
        kep.gameObject.SetActive(false);
        cutsceneCamera.enabled = false;
        playerCamera.gameObject.SetActive(true);
    }
}
