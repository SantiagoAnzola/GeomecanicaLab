using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrientacionRotacionController : MonoBehaviour
{
    private int touchCount = 0;
    public static OrientacionRotacionController instance;
    private bool mostrarOprimir=false;
    // Start is called before the first frame update
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }
    private void Update()
    {
       

    }
  
    public void incrementarTouchCount()
    {
        touchCount++;
        Debug.Log("click, --->   TouchCount: " + touchCount);
    }
    public void setMostrarOprimir(bool mostrar)
    {
        mostrarOprimir = mostrar;
    }
    public void ExplicacionRotacionModelo()
    {
        Debug.Log("EXPLICACION ROTACION-MODEO");
        transform.localScale = Vector3.one;

        //transform.GetChild(0).localScale = (transform.localScale == Vector3.one) ?
        //Vector3.zero : Vector3.one;

        if (touchCount < 1)
        {

            transform.GetChild(0).localScale = Vector3.one;
        }
        else if (touchCount >= 1 && touchCount < 2)
        {
            transform.GetChild(0).localScale = Vector3.zero;
            transform.GetChild(1).localScale = Vector3.one;
        }
        else if ((touchCount >= 2 && touchCount < 3) && mostrarOprimir)
        {
            transform.GetChild(0).localScale = Vector3.zero;
            transform.GetChild(1).localScale = Vector3.zero;
            transform.GetChild(2).localScale = Vector3.one;
        }
        else
        {
            transform.GetChild(0).localScale = Vector3.zero;
            transform.GetChild(1).localScale = Vector3.zero;
            transform.GetChild(2).localScale = Vector3.zero;
            transform.localScale = Vector3.zero;
        }

        //ExplicacionRotacion.transform.localScale = Vector3.one;
    }
    public void Reset()
    {
        touchCount = 0;
    }
}
