using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InteractionPromptUI : MonoBehaviour
{
    private Camera _mainCam;
    [SerializeField] private GameObject _uiPanel;
    [SerializeField] private TextMeshPro _promptText;


    private void Start()
    {
        _mainCam = Camera.main;
        _uiPanel.SetActive(false);
        _promptText.SetText("");
    }

    private void LateUpdate()
    {
        var rotation = transform.rotation;
        transform.LookAt(transform.position + rotation * Vector3.forward, rotation * Vector3.up);
    }

    public bool IsDisplayed = false;
    public void SetUp(string promptText)
    {
        _promptText.SetText(promptText);
        _uiPanel.SetActive(true);
        IsDisplayed = true;
    }

    public void Close()
    {
        _uiPanel.SetActive(false);
        _promptText.SetText("");
        IsDisplayed = false;
    }
}
