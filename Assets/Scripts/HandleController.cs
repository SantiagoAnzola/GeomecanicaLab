using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//BORRAR

public class HandleController : MonoBehaviour
{
    //[SerializeField] public GameObject sideMenu;
    //[SerializeField] public GameObject ContentInfo;
    //[SerializeField] public GameObject handle;


    //public void setHandleToggleWhenScollViewIsOnTop()
    //{
    //    if (sideMenu.transform.position.y > 327)
    //    {
    //        if (ContentInfo.transform.position.y < 2)
    //        {
    //            RectTransform rectTransform = handle.GetComponent<RectTransform>();
    //            if (rectTransform != null)
    //            {
    //                rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x, 394.34f);
    //            }
    //        }
    //    }
    //}


    public GameObject scrollView;
    public GameObject sideMenu;
    public GameObject ContentInfo;
    public GameObject handle;

    private float scrollViewPositionY;
    private float contentInfoPositionY;
    private float previousScrollViewPositionY;
    private bool isScrollViewOnTop = true;

    void Start()
    {
        previousScrollViewPositionY = ContentInfo.transform.position.y;
    }

    void Update()
    {
        // Obt�n las posiciones Y actuales de los GameObjects
        scrollViewPositionY = scrollView.transform.position.y;
        contentInfoPositionY = ContentInfo.transform.position.y;

        // Verifica si el ScrollView se est� desplazando hacia abajo
        if (scrollViewPositionY < previousScrollViewPositionY)
        {
            // El ScrollView se est� desplazando hacia abajo
            Debug.Log("ScrollView desplaz�ndose hacia abajo");

            // Llama al m�todo setHandleToggleWhenScollViewIsOnTop si el ScrollView estaba en la parte superior antes
            if (isScrollViewOnTop)
            {
                setHandleToggleWhenScollViewIsOnTop();
            }

            // Actualiza el estado del ScrollView
            isScrollViewOnTop = false;
        }
        else
        {
            // El ScrollView no se est� desplazando hacia abajo
            // Aqu� puedes realizar acciones adicionales si es necesario

            // Actualiza el estado del ScrollView
            isScrollViewOnTop = true;
        }

        // Actualiza la posici�n anterior del ScrollView
        previousScrollViewPositionY = scrollViewPositionY;
    }

    public void setHandleToggleWhenScollViewIsOnTop()
    {
        if (scrollViewPositionY > 327 && contentInfoPositionY < 2)
        {
            RectTransform rectTransform = handle.GetComponent<RectTransform>();
            if (rectTransform != null)
            {
                rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x, 394.34f);
            }
        }
    }
}
