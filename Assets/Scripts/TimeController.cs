using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class TimeController : MonoBehaviour
{

    public Slider timeSlider;
    public Text timeLabel;
    public float timeSpeed = 1.0f; // Geschwindigkeit der Zeit (Tage pro Sekunde)

    private bool isSliderBeingDragged = false;

    void Start()
    {
        // Initialisiere den Slider
        timeSlider.minValue = -365 * 100; // 10 Jahre in der Vergangenheit
        timeSlider.maxValue = 365 * 100; // 10 Jahre in der Zukunft
        timeSlider.value = 0; // Startzeitpunkt

        // Aktualisiere die Zeit bei der Initialisierung
        UpdateTime(timeSlider.value);

        // Füge einen Listener hinzu, um die Zeit bei Veränderung des Sliders zu aktualisieren
        timeSlider.onValueChanged.AddListener(UpdateTime);

        // Listener hinzufügen, um zu erkennen, wenn der Slider gezogen wird
        EventTrigger trigger = timeSlider.gameObject.AddComponent<EventTrigger>();
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.BeginDrag;
        entry.callback.AddListener((eventData) => { isSliderBeingDragged = true; });
        trigger.triggers.Add(entry);

        entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.EndDrag;
        entry.callback.AddListener((eventData) => { isSliderBeingDragged = false; });
        trigger.triggers.Add(entry);
    }

    void Update()
    {
        // Wenn der Slider nicht gezogen wird, die Zeit automatisch fortsetzen
        if (!isSliderBeingDragged)
        {
            float newTime = GlobalSettings.Instance.timeInDays + (timeSpeed * Time.deltaTime);
            timeSlider.value = newTime;
            UpdateTime(newTime);
        }
    }


    void UpdateTime(float value)
    {
        // Aktualisiere die globale Zeit
        GlobalSettings.Instance.SetTime(value);

        // Aktualisiere das Label (optional)
        if (timeLabel != null)
        {
            timeLabel.text = "Tage: " + value.ToString("F0");
        }
    }

    public void SetTimeSpeed(float newTimeSpeed)
    {
        timeSpeed = newTimeSpeed;
    }
}
