using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;

public class CutsceneController : MonoBehaviour
{
    public Camera playerCamera;
    public Camera cutsceneCamera;
    public RawImage kep;
    public Animator cutsceneAnimator;

    public PlayableDirector timeline1;  // Az első Timeline
    public PlayableDirector timeline2;  // A második Timeline

    // Statikus változó, hogy az állapotot megőrizzük a játék alatt
    private static bool hasPlayedCutscene = false;

    private void Start()
    {
        // Ellenőrizd, hogy már lejátszották-e a cutscene-t
        if (!hasPlayedCutscene)
        {
            // Ha még nem játszották le:

            // Lejátszunk két Timeline-t
            if (timeline1 != null)
                timeline1.Play();  // Első Timeline elindítása
            if (timeline2 != null)
                timeline2.Play();  // Második Timeline elindítása

            // Lejátszani a cutscene-t (animáció vagy egyéb események)
            playerCamera.gameObject.SetActive(false);
            cutsceneCamera.gameObject.SetActive(true);

            if (cutsceneAnimator != null)
            {
                cutsceneAnimator.Play("CutsceneAnimation");
            }

            // Befejezni a cutscene-t egy időzítő segítségével
            Invoke("EndCutscene", 3f);  // 3 másodperc után befejezi a cutscene-t

            // Beállítjuk a PlayerPrefs-t, hogy legközelebb ne fusson le
            hasPlayedCutscene = true;
        }
        else
        {
            // Ha már lejátszották a cutscene-t, akkor csak a játék kamerát engedélyezd
            playerCamera.gameObject.SetActive(true);
            cutsceneCamera.gameObject.SetActive(false);
        }
    }

    void EndCutscene()
    {
        kep.gameObject.SetActive(false);
        cutsceneCamera.enabled = false;
        playerCamera.gameObject.SetActive(true);
    }
}
