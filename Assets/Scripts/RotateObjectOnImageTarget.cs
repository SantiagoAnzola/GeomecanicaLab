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
    public float scaleFactor = 2.0f;
    private Vector3 rotationEuler;
    private int touchCount;
    [SerializeField] public GameObject sideMenu;
    [SerializeField] public GameObject handle;

    private float touchDistance;
    private Vector2 touchPositiojnDiff;
    private float scaleTolerance = 25f;
    private float rotationTolerance = 1.5f;
  

    void Start()
    {

        isTracking = false;
        rotationEuler = transform.rotation.eulerAngles;
        touchCount = 0;
    }
    void Update()
    {
       
        if (Input.touchCount > 0) 
        { 
            Touch touch = Input.GetTouch(0);
            if (Input.touchCount == 1 && sideMenu.transform.position.y < 327)
            {

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
                        //Calcula la diferencia de posición para obtener la rotación
                       Vector2 touchDelta = touch.position - touchStartPos;

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
            if (Input.touchCount == 2 && sideMenu.transform.position.y < 327)
            {

                Touch touchTwo = Input.GetTouch(1);
                if (touch.phase==TouchPhase.Began || touchTwo.phase == TouchPhase.Began)
                {
                    touchPositiojnDiff=touchTwo.position - touch.position;
                    touchDistance=Vector2.Distance(touchTwo.position, touch.position);
                }
                if (touch.phase == TouchPhase.Moved || touchTwo.phase == TouchPhase.Moved)
                {
                    Vector2 currentTouchPosDiff=touchTwo.position - touch.position;
                    float currentTouchDis = Vector2.Distance(touchTwo.position, touch.position);
                    float difDistance = currentTouchDis - touchDistance;

                    if (Mathf.Abs(difDistance) > scaleTolerance)
                    {
                        Vector3 neeScale = modeloARotar.transform.localScale + Mathf.Sign(difDistance) * Vector3.one * scaleFactor;
                        modeloARotar.transform.localScale = Vector3.Lerp(modeloARotar.transform.localScale, neeScale, 0.05f);
                    }



                }

            }
        }
    }


}

