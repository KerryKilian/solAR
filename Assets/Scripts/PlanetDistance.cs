using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetDistance : MonoBehaviour
{
    public Transform sun; // Referenz zur Sonne
    public float baseDistance = 1.0f; // Basisabstand des Planeten von der Sonne

    void Start()
    {
        // Skalierung des Abstands basierend auf dem globalen Skalierungsfaktor
        float distanceScale = GlobalSettings.Instance.distanceScaleFactor;
        Vector3 direction = (transform.position - sun.position).normalized;
        transform.position = sun.position + direction * baseDistance * distanceScale;
    }
}