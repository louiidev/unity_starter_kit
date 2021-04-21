using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    Transform buttonContainer;
    Button startButton;
    Button loadButton;
    Button options;

    private void Start()
    {
        var canInteractLoadBtn = Serialisation.HasCurrentSave();
        buttonContainer = transform.Find("ButtonContainer");
        startButton = buttonContainer.Find("Start").GetComponent<Button>();
        loadButton = buttonContainer.Find("Load").GetComponent<Button>();
        options = buttonContainer.Find("Options").GetComponent<Button>();

        loadButton.interactable = canInteractLoadBtn;
        startButton.onClick.AddListener(OnStart);
        loadButton.onClick.AddListener(OnLoad);
    }



    void OnStart()
    {
        Serialisation.ClearSave();
        SceneManager.LoadScene("");
    }

    void OnLoad()
    {
        Serialisation.Load();
    }
}
