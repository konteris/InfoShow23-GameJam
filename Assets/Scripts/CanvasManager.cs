using UnityEngine;
using UnityEngine.UI;
using System;

public class CanvasManager : MonoBehaviour
{
    public GameObject canvas;
    public Button closeButton;
    public Button resumeButton;

    void Start()
    {
        canvas.SetActive(false);
        // Add click event listener to close button
        closeButton.onClick.AddListener(CloseCanvas);
        resumeButton.onClick.AddListener(ResumeGame);
    }

    void Update()
    {
        // Turn canvas on/off when escape key is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            canvas.SetActive(!canvas.activeSelf);
        }
    }

    void CloseCanvas()
    {
        // Close the canvas
        canvas.SetActive(false);
    }
    void ResumeGame() 
    {
        canvas.SetActive(!canvas.activeSelf);
    }

    public void QuitGame()
    {
        // Quit the game
        Application.Quit();
    }
}