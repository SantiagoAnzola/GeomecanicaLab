using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrientacionRotacionController : MonoBehaviour
{
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
                
            }
        }
    }
    //void OnMouseDown()
    //{
    //    ExplicacionRotacionModelo();
    //}

    public void ExplicacionRotacionModelo()
    {
        transform.localScale = (transform.localScale == Vector3.one) ?
            Vector3.zero : Vector3.one;
        //ExplicacionRotacion.transform.localScale = Vector3.one;
    }
}
