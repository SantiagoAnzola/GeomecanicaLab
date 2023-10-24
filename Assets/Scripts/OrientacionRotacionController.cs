using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrientacionRotacionController : MonoBehaviour
{
    private int touchCount = 0;
    public static OrientacionRotacionController instance;
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
        if (Input.touchCount > 0)
        {

            Touch touch = Input.GetTouch(0); // Obtener el primer toque
            
            // Verificar si el toque colisiona con el Collider del panel
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(touch.position);

            if (Physics.Raycast(ray, out hit) && hit.collider.gameObject == this)
            {
                Debug.Log("--------------> CLICK");
                
                ExplicacionRotacionModelo();
                touchCount++;

                Debug.Log(touchCount);

            }
        }

    }
  
    public void incrementarTouchCount()
    {
        touchCount++;
        Debug.Log("click, --->   TouchCount: " + touchCount);
    }
    public void ExplicacionRotacionModelo()
    {
        transform.localScale = Vector3.one;

        //transform.GetChild(0).localScale = (transform.localScale == Vector3.one) ?
        //Vector3.zero : Vector3.one;

        if (touchCount<1)
        {
           
            transform.GetChild(0).localScale = Vector3.one;
        }
        else if(touchCount>=1 && touchCount<2)
        {
            transform.GetChild(0).localScale = Vector3.zero;
            transform.GetChild(1).localScale = Vector3.one;
        }
        else if (touchCount >= 2 && touchCount < 3)
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
}
