using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;
using Vuforia;

public class RotateObjectOnImageTarget : MonoBehaviour
{
    public GameObject modeloARotar;
    private bool isTracking;
    private Vector2 touchStartPos;
    public float rotationSpeed = 2.0f;
    private Vector3 rotationEuler;
    private int touchCount;
    [SerializeField] public GameObject sideMenu;
    [SerializeField] public GameObject handle;

    //private float initialDistance;
    //private Vector3 initialRotation;

    void Start()
    {

        isTracking = false;
        rotationEuler = transform.rotation.eulerAngles;
        touchCount = 0;
    }

    //private void Update()
    //{
    //    if (Input.touchCount == 2)
    //    {

    //        //Touch touch = Input.GetTouch(0);
    //        Touch touch1 = Input.GetTouch(0);
    //        Touch touch2 = Input.GetTouch(1);

    //        if (touch1.phase == TouchPhase.Began && touch2.phase == TouchPhase.Began)
    //        {
    //            touchStartPos = (touch1.position+touch2.position)/2;
    //        }
    //        else if (touch1.phase == TouchPhase.Moved && touch2.phase == TouchPhase.Moved)
    //        {

    //            // Detecta dos dedos tocando la pantalla


    //            //if ((touch1.phase == TouchPhase.Began || touch2.phase == TouchPhase.Began) &&
    //            //    (touch1.phase != TouchPhase.Ended && touch2.phase != TouchPhase.Ended))
    //            //{
    //            //    // Registra la posición de inicio de ambos dedos
    //            //    touchStartPos = (touch1.position + touch2.position) / 2f;
    //            //}
    //            //else if ((touch1.phase == TouchPhase.Moved || touch2.phase == TouchPhase.Moved) &&
    //            //         (touch1.phase != TouchPhase.Ended && touch2.phase != TouchPhase.Ended))
    //            //{
    //            // Calcula la diferencia de posición para obtener la rotación
    //            Vector2 touchCurrentPos = (touch1.position + touch2.position) / 2f;
    //            Vector2 touchDelta = touchCurrentPos - touchStartPos;

    //            // Aplica la rotación en función del deslizamiento de los dos dedos
    //            rotationEuler.x += touchDelta.y * rotationSpeed;
    //            rotationEuler.y = 0.0f;
    //            rotationEuler.z -= touchDelta.x * rotationSpeed;

    //            // Aplica la rotación al objeto 3D
    //            transform.rotation = Quaternion.Euler(rotationEuler);

    //            //-->touchStartPos = touchCurrentPos;

    //            touchStartPos = touchCurrentPos;
    //            //}
    //        }
    //    }
    //}
    void Update()
    {
         
        if (Input.touchCount == 1 && sideMenu.transform.position.y < 327)
        {
            Touch touch = Input.GetTouch(0);
            // Obtiene la posición del toque en coordenadas de pantalla
            Vector2 touchPos = touch.position;

            // Verifica si el toque está fuera de las coordenadas del sideMenu
            RectTransform menuRect = handle.GetComponent<RectTransform>();
            if (!RectTransformUtility.RectangleContainsScreenPoint(menuRect, touchPos))
            {

                if (touch.phase == TouchPhase.Began)
                {
                    touchStartPos = touch.position;
                }
                else if (touch.phase == TouchPhase.Moved)
                {
                    // Calcula la diferencia de posición para obtener la rotación
                    Vector2 touchDelta = touch.position - touchStartPos;

                    // Aplica la rotación en función del deslizamiento del dedo
                    //modeloARotar. transform.Rotate(Vector3.up * touchDelta.x * rotationSpeed);



                    //---------
                    //float rotationX = touchDelta.y * rotationSpeed;
                    /*float rotationY = -touchDelta.x * rotationSpeed;*/ // Cambiamos el signo para rotación en el eje Y

                    //modeloARotar.transform.Rotate(Vector3.up * rotationY);
                    //modeloARotar.transform.Rotate(Vector3.forward * rotationX);


                    //----

                    // Aplica la rotación en función del deslizamiento del dedo
                    rotationEuler.x += touchDelta.y * rotationSpeed;
                    rotationEuler.y = 0.0f;// Invierte el eje Y para una rotación más intuitiva
                    rotationEuler.z -= touchDelta.x * rotationSpeed; // Mantiene la rotación en el eje Z en 0

                    //// Aplica la rotación al objeto 3D
                    modeloARotar.transform.rotation = Quaternion.Euler(rotationEuler);




                    touchStartPos = touch.position;
                }
            }
        }
    }


}

//if (Input.touchCount == 2)
//{
//    // Detecta dos dedos tocando la pantalla
//    Touch touch1 = Input.GetTouch(0);
//    Touch touch2 = Input.GetTouch(1);

//    if (touch1.phase == TouchPhase.Began || touch2.phase == TouchPhase.Began)
//    {
//        // Registra la posición de inicio de ambos dedos
//        touchStartPos[0] = touch1.position;
//        touchStartPos[1] = touch2.position;
//    }
//    else if ((touch1.phase == TouchPhase.Moved || touch2.phase == TouchPhase.Moved) &&
//             (touch1.phase != TouchPhase.Ended && touch2.phase != TouchPhase.Ended))
//    {
//        // Calcula la diferencia de posición para obtener la rotación promedio
//        Vector2 touchDelta1 = touch1.position - touchStartPos[0];
//        Vector2 touchDelta2 = touch2.position - touchStartPos[1];
//        Vector2 touchDelta = (touchDelta1 + touchDelta2) / 2f;

//        // Aplica la rotación en función del deslizamiento de los dos dedos
//        rotationEuler.x += touchDelta.y * rotationSpeed;
//        rotationEuler.y -= touchDelta.x * rotationSpeed;
//        rotationEuler.z = 0.0f;

//        // Aplica la rotación al objeto 3D
//        transform.rotation = Quaternion.Euler(rotationEuler);

//        touchStartPos[0] = touch1.position;
//        touchStartPos[1] = touch2.position;
//    }
//}

//void OnEnable()
//{
//    // Incrementa el contador de dedos cuando un dedo toca la pantalla
//    Input.multiTouchEnabled = true;
//}

//void OnDisable()
//{
//    // Restablece el contador de dedos cuando se desactiva el script
//    Input.multiTouchEnabled = false;
//}

//void TouchCountUpdate()
//{
//    // Actualiza el contador de dedos tocando la pantalla en Update
//    activeTouchCount = Input.touchCount;
//}