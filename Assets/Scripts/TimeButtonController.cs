using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeButtonController : MonoBehaviour
{
    public Button buttonTimeSpeed1;
    public Button buttonTimeSpeed2;
    public Color activeColor = Color.yellow;
    public Color inactiveColor = Color.white;

    private TimeController timeController;

    void Start()
    {
        // Referenz zum TimeController Skript
        timeController = FindObjectOfType<TimeController>();

        // Initiale Farben setzen
        SetButtonColor(buttonTimeSpeed1, inactiveColor);
        SetButtonColor(buttonTimeSpeed2, inactiveColor);

        // Event Listener hinzufügen
        buttonTimeSpeed1.onClick.AddListener(SetButtonTimeSpeed1);
        buttonTimeSpeed2.onClick.AddListener(SetButtonTimeSpeed2);
    }

    void SetButtonTimeSpeed1()
    {
        OnButtonClick(buttonTimeSpeed1, 1.0f);
    }

    void SetButtonTimeSpeed2()
    {
        OnButtonClick(buttonTimeSpeed2, 100.0f);
    }

    void OnButtonClick(Button clickedButton, float timeSpeed)
    {
        // Zeitgeschwindigkeit setzen
        timeController.SetTimeSpeed(timeSpeed);

        // Farben der Buttons aktualisieren
        SetButtonColor(buttonTimeSpeed1, inactiveColor);
        SetButtonColor(buttonTimeSpeed2, inactiveColor);
        SetButtonColor(clickedButton, activeColor);
    }

    public void SetButtonColor(Button button, Color color)
    {
        ColorBlock colorBlock = button.colors;
        colorBlock.normalColor = color;
        colorBlock.highlightedColor = color;
        colorBlock.pressedColor = color;
        colorBlock.selectedColor = color;
    
        button.colors = colorBlock;
    }
}
