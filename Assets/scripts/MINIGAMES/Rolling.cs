using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using jatek;

public class Roller : MonoBehaviour
{
    public GameObject cigaretteBox;
    public GameObject cigarettePaper;
    public GameObject tobacco;
    public Slider rollingSlider;
    public Button lickButton;
    public GameObject completedMessage;

    private bool isPaperTaken = false;
    private bool isTobaccoDragged = false;
    private bool isRollingStarted = false;
    private bool isLicked = false;
    private RectTransform draggedObject;
    private Vector2 originalPosition;
    private DragAndDrop tobaccoDragAndDrop;

    void Start()
    {
        cigarettePaper.SetActive(false);
        lickButton.gameObject.SetActive(false);
        completedMessage.SetActive(false);
        rollingSlider.gameObject.SetActive(false);

        tobaccoDragAndDrop = tobacco.GetComponent<DragAndDrop>();
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

    public void OnLickButtonPressed()
    {
        if (!isLicked)
        {
            isLicked = true;
            lickButton.gameObject.SetActive(false);
            rollingSlider.gameObject.SetActive(true);
            StartRolling();
        }
    }

    public void OnRollingSliderChanged()
    {
        if (isRollingStarted)
        {
        }
    }

    private void StartRolling()
    {
        if (isLicked)
        {
            isRollingStarted = true;
            rollingSlider.gameObject.SetActive(true);
            completedMessage.SetActive(false);
        }
    }

    private void CheckTobaccoPlacement()
    {
        if (tobaccoDragAndDrop != null && tobaccoDragAndDrop.IsPlaced())
        {
            if (!isTobaccoDragged)
            {
                isTobaccoDragged = true;
                lickButton.gameObject.SetActive(true);
            }
        }
    }

    public bool IsPaperAvailable()
    {
        return cigarettePaper.activeSelf;
    }
}
