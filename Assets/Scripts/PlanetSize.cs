using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetSize : MonoBehaviour
{
    public float baseSize = 1.0f; // Basisgröße des Planeten

    void Start()
    {
        // Skalierung des Planeten basierend auf dem globalen Skalierungsfaktor
        float sizeScale = GlobalSettings.Instance.sizeScaleFactor;
        transform.localScale = Vector3.one * baseSize * sizeScale;
    }
}