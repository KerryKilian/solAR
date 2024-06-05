using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Orbit : MonoBehaviour
{
    public Transform sun; // Referenz zur Sonne
    public float relativeSpeed = 1.0f; // Relative Geschwindigkeit im Vergleich zur Basisgeschwindigkeit
    public float orbitalPeriod = 365.25f; // Umlaufzeit in Tagen
    private float initialDistance; // Initiale Distanz zur Sonne

    void Start()
    {
        // Initiale Distanz zur Sonne berechnen und speichern
        initialDistance = (transform.position - sun.position).magnitude;
    }

    void Update()
    {
        // Globale Zeit abrufen
        float timeInDays = GlobalSettings.Instance.timeInDays;

        // Berechne den Winkel basierend auf der Umlaufzeit
        float angle = (timeInDays / orbitalPeriod) * 360.0f;

        // Skalierte Distanz berechnen
        float distance = initialDistance * GlobalSettings.Instance.distanceScaleFactor;

        // Setze die Position des Planeten entlang der Umlaufbahn
        Vector3 position = sun.position + new Vector3(Mathf.Cos(angle * Mathf.Deg2Rad), 0, Mathf.Sin(angle * Mathf.Deg2Rad)) * distance;
        transform.position = position;
    }
}