using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalSettings : MonoBehaviour
{
    // Singleton-Instanz
    public static GlobalSettings Instance { get; private set; }

    // Globale Variable für die Standardgeschwindigkeit
    public float baseOrbitSpeed = 7.0f;
    public float sizeScaleFactor = 0.01f;
    public float distanceScaleFactor = 0.3f;
    public float timeInDays = 0.0f;

    private void Awake()
    {
        // Singleton-Pattern, um sicherzustellen, dass nur eine Instanz existiert
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Behalte das Objekt beim Szenenwechsel
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetTime(float days)
    {
        timeInDays = days;
    }
}
