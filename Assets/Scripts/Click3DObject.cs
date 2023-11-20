using DanielLochner.Assets.SimpleSideMenu;

using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Click3DObject : MonoBehaviour
{

    [SerializeField] public GameObject sideMenu;
    [SerializeField] public RawImage rawImageComponent;
    [SerializeField] public TextMeshProUGUI textTitulo;
    [SerializeField] public TextMeshProUGUI textComponent;
    [SerializeField] public string titleRawImageComponent;
    [SerializeField] public string textRawImageComponent;
    [SerializeField] public RenderTexture renderTextures;
    [SerializeField] public GameObject[] animatorObjects;
    [SerializeField] public GameObject ventanaEmergente;
    float ventaEmegernteTopValue;
    private AnimatorControllerScript[] animatorControllers;
    GameObject pantallaOscura;
    //Cargar indicador
    [SerializeField] private float indicadorTiempo = 0.0f;
    [SerializeField] private float maxIndicadorTiempo = 0.0f;
    [SerializeField] private Image cargarImagen = null;
    private bool actualizar=false;
    private bool mostarCarga = false;
    private bool esCargado = false;
    private AudioSource sound;
    private void Start()
    {
        sound = GetComponent<AudioSource>();
        pantallaOscura = GameObject.Find("PantallaOscura");
        cargarImagen.enabled = false;
        animatorControllers = new AnimatorControllerScript[animatorObjects.Length];
        for (int i = 0; i < animatorObjects.Length; i++)
        {
            animatorControllers[i] = animatorObjects[i].GetComponent<AnimatorControllerScript>();
        }
       
        
    }
    private void Update()
    {
        RectTransform rectTransform = ventanaEmergente.GetComponent<RectTransform>();
        ventaEmegernteTopValue = rectTransform.offsetMax.y;
       
        if (Input.touchCount > 0 && Input.touchCount<2)
        {
            Touch touch = Input.GetTouch(0);

            if (IsTouchingObject(touch))
            {
                if ((touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Stationary)&& !esCargado && 
                    sideMenu.transform.position.y < 327 && ventaEmegernteTopValue < 650)
                {
                    // El botón táctil se ha presionado mientras el puntero está sobre el objeto por primera vez
                    
                    Debug.Log("Touch Down!");

                     cargarImagen.enabled = true;
                     pantallaOscura.transform.localScale = Vector3.one;


                    actualizar = false;
                    indicadorTiempo += Time.deltaTime;
                    cargarImagen.fillAmount = indicadorTiempo;
                    if (indicadorTiempo >= maxIndicadorTiempo )
                    {
                        indicadorTiempo = maxIndicadorTiempo;
                        cargarImagen.fillAmount = maxIndicadorTiempo;
                        cargarImagen.enabled = false;

                        mostarCarga = false;
                        pantallaOscura.transform.localScale = Vector3.zero;
                        esCargado = true;
                        OnMouseDown1();
                    }
                }
                if (touch.phase == TouchPhase.Ended|| touch.phase == TouchPhase.Moved)
                {
                    // El botón táctil se ha levantado después de mantenerlo presionado o se desliza
                    
                    mostarCarga = true;
                    pantallaOscura.transform.localScale = Vector3.zero;
                    Debug.Log("Touch Up!");
                    actualizar = true;
                    esCargado = false;
                }

            }
            else
            {
                actualizar = true;
            }
        }
        else if (actualizar || Input.touchCount ==2|| Input.touchCount <= 0)
        {
            indicadorTiempo -= Time.deltaTime;
            cargarImagen.fillAmount = indicadorTiempo;
            if (indicadorTiempo <=0 )
            {
                indicadorTiempo = 0.0f;
                cargarImagen.fillAmount = 0.0f;
                actualizar = false;
                cargarImagen.enabled = false;
                mostarCarga = false;
                pantallaOscura.transform.localScale = Vector3.zero;
            }
        }

    }
    bool IsTouchingObject(Touch touch)
    {
        Ray ray = Camera.main.ScreenPointToRay(touch.position);
        RaycastHit hit;
        return Physics.Raycast(ray, out hit) && hit.collider.gameObject == gameObject;
    }

    void OnMouseDown1()
    {
        if (sideMenu.transform.position.y < 327)
        {
            pantallaOscura.transform.localScale = Vector3.zero;
            print(">>>>>>>>>click");
            AsignarTextura();
            animatorControllers[0].StartAnimation();
            animatorControllers[0].ResumeAnimation();
            sound.Play();
            GameManager.instance.VentanaEmergenteOpen();
        }
    }

    public void StopAnimation()
    {
        foreach (var controller in animatorControllers)
        {
            controller.PauseAnimation();
        }
    }

    public void AsignarTextura()
    {

        rawImageComponent.texture = renderTextures;
        textComponent.text = textRawImageComponent;
        textTitulo.text = titleRawImageComponent;
    }
}
