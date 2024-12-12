using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Rolling : MonoBehaviour
{
    public Button gomb;

    void Start()
    {
        Button btn = gomb.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        Debug.Log("You have clicked the button!");
    }
}