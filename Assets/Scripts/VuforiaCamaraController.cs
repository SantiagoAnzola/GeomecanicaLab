using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using Vuforia;

public class VuforiaCamaraController : MonoBehaviour
{
    public static VuforiaCamaraController Instance; // Instancia única de la clase

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            // Si ya existe una instancia, destruye esta para asegurarte de que solo haya una
            Destroy(this);
        }
        DesactivarCamaraVuforia();
    }

    public void ActivarCamaraVuforia()
    {
        // Obtenemos el componente VuforiaBehaviour
        VuforiaBehaviour vuforiaBehaviour = FindObjectOfType<VuforiaBehaviour>();

        if (vuforiaBehaviour != null)
        {
            // Habilitamos el componente VuforiaBehaviour para reanudar la cámara
            vuforiaBehaviour.enabled = true;
        }
    }
    public void DesactivarCamaraVuforia()
    {
        VuforiaBehaviour vuforiaBehaviour = FindObjectOfType<VuforiaBehaviour>();

        if (vuforiaBehaviour != null)
        {
            // Deshabilitamos el componente VuforiaBehaviour para detener la cámara
            vuforiaBehaviour.enabled = false;
        }
    }
}
