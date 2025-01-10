using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using jatek;
using UnityEngine.SceneManagement;

public class Roller : MonoBehaviour
{
    public GameObject cigaretteBox;
    public GameObject cigarettePaper;
    public GameObject tobacco;
    public Button lickButton;
    public GameObject completedMessage;
    public GameObject timingBar;

    private bool isPaperTaken = false;
    private bool isTobaccoDragged = false;
    private bool isRollingStarted = false;
    private bool isLicked = false;
    private RectTransform draggedObject;
    private Vector2 originalPosition;
    private DragAndDrop tobaccoDragAndDrop;public TimingBar timingbar;  


    void Start()
    {
        cigarettePaper.SetActive(false);
        lickButton.gameObject.SetActive(false);
        completedMessage.SetActive(false);
        timingBar.gameObject.SetActive(false); 

        tobaccoDragAndDrop = tobacco.GetComponent<DragAndDrop>();
        timingbar = timingbar.GetComponent<TimingBar>();
    }

    void Update()
    {
        CheckTobaccoPlacement();
    }

    public void OnCigaretteBoxClicked()
    {
        if (!isPaperTaken)
        {
            cigarettePaper.SetActive(true);
            isPaperTaken = true;
            tobacco.SetActive(true);
        }
    }



    private void CheckTobaccoPlacement()
    {
        if (tobaccoDragAndDrop != null && tobaccoDragAndDrop.IsPlaced())
        {
            if (!isTobaccoDragged)
            {
                isTobaccoDragged = true;
                timingBar.gameObject.SetActive(true);
            }
        }
        if (timingbar.isRolled())
        {
            Debug.Log("Sikeresen megtekerted a cigit");
            SceneManager.LoadScene("Jatek2", LoadSceneMode.Single);
        }
    }

    public bool IsPaperAvailable()
    {
        return cigarettePaper.activeSelf;
    }
}
