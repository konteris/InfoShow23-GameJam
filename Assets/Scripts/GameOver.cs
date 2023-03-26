using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField] private Canvas canvas;

    private void Start()
    {
        DisableCanvas();

    }

    public void DisableCanvas()
    {
        canvas.gameObject.SetActive(false);
    }

    public void ActivateCanvas()
    {
        canvas.gameObject.SetActive(true);
    }
}
