using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Vuforia;


public class ARController : MonoBehaviour
{
    //public ImageTargetBehaviour[] ImageTargets;
    public GameObject SlideMenu;
    public GameObject cardTemplate;
    public GameObject button;
    public Canvas canvas;
    private string lastDetectedTargetName;
    public GameObject OrientacionEscanear;
    public GameObject ExplicacionRotacion;
    public GameObject VentanaEmergente;

    public GameObject practicaTag;
    public GameObject ContainerTituloTag;
    private TextMeshProUGUI tituloTag;
    [SerializeField] public RawImage rawImageComponent;
    [SerializeField] public RenderTexture[] renderTextures;
    public  AnimatorControllerScript[] animatorControllers;

    private Transform ObjetoARotar;
    private float top;
    private float bottom;
    int index = -1;
    private void Start()

    {
        tituloTag = ContainerTituloTag.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        ContainerTituloTag.transform.localScale= Vector3.zero;
        lastDetectedTargetName = null;
        //top = -60f+ getCanvasHeight();
        //bottom = 60f;
        top = -40f + getCanvasHeight();
        bottom = 40f;

        cardTemplate = transform.GetChild(1).gameObject;
        SlideMenu.SetActive(false);

        RectTransform ventanaRect = VentanaEmergente.GetComponent<RectTransform>();
        float newHeight = ventanaRect.rect.height ;
        ventanaRect.anchoredPosition = new Vector2(ventanaRect.anchoredPosition.x, getCanvasHeight());
        ventanaRect.sizeDelta = new Vector2(ventanaRect.sizeDelta.x, newHeight);

    }
    private void Awake()
    {
        //buttonPosition = button.transform.position.y;
    }
    private void Update()
    {
    }
    public  void OcultarOrientacion()
    {
        OrientacionEscanear.transform.localScale = Vector3.zero;
    }
    public void OnImageTargetDetected(ObserverBehaviour mObserverBehaviour)
    {
        //Se muestra el nuevo tag par el titulo
        practicaTag.transform.localScale = Vector3.zero; 
        ContainerTituloTag.transform.localScale = Vector3.one;



        string targetName = mObserverBehaviour.TargetName;
        
        //Rotacion por defecto de cada maquina
        Transform targetTransform = mObserverBehaviour.transform.GetChild(0);
        targetTransform.transform.localRotation = Quaternion.Euler(Vector3.zero);
        targetTransform.transform.localScale = (Vector3.one);
        Debug.Log("----> MODELO A ROTAR: "+targetTransform+" --> rotacion: ("+$"({targetTransform.transform.rotation.x}, {targetTransform.transform.rotation.y}, {targetTransform.transform.rotation.z})"+")");
        //Orientacion
        OrientacionEscanear.transform.localScale = Vector3.zero;

        OrientacionRotacionController.instance.ExplicacionRotacionModelo();
        //RotateObjectOnImageTarget.instance.ResetRotationEuler();

        if (targetName != lastDetectedTargetName)
        {
            // Limpia las tarjetas y oculta el menú si se detectó un nuevo objetivo
            LimpiarCards(false);
            SlideMenu.SetActive(false);
            moverBoton(false);
            
        }

        lastDetectedTargetName = targetName;
        
        switch (targetName)
        {
           


            case "QR Target":
               
              
                Maquina maquina1 = new Maquina(
                   "Cámara",
                   "Contiene la muestra rodeada por agua a presión"
                   //"Medir la resistencia a la compresión de materiales geotécnicos",
                   //"Fabricante A",
                   //"Modelo 123",
                   //"S123456",
                   //"2022-01-15",
                   //"En funcionamiento",
                   //25000.0,
                   //"Laboratorio A"
                );

                SlideMenu.SetActive(true);
                moverBoton(true);

                SetMaquinaInfo(maquina1);
                AsignarTextura(renderTextures[0]);
                tituloTag.text = maquina1.Nombre;
                animatorControllers[0].StartAnimation();
                animatorControllers[0].ResumeAnimation();

                //Se muestra la pantalla de orientacion al detetctar
                //OrientacionEscanear.transform.localScale = Vector3.zero;
                //OrientacionRotacionController.instance.ExplicacionRotacionModelo();
                break;
            case "QR Target Maquina1":
                
                
                Maquina maquina2 = new Maquina(
                    "Prensa",
                    "Sostiene la cámara, aplica presión vertical ascendente a la muestra."
                    //"Medir la resistencia a la tracción de muestras geológicas.",
                    //"Fabricante B",
                    //"Modelo 456",
                    //"T789012",
                    //"2021-11-30",
                    //"En reparación",
                    //18000.0,
                    //"Laboratorio B"
                );
                
                //LimpiarCards(false);
                SlideMenu.SetActive(true);
                moverBoton(true);
                SetMaquinaInfo(maquina2);
                AsignarTextura(renderTextures[1]);
                tituloTag.text = maquina2.Nombre;
                animatorControllers[1].StartAnimation();
                animatorControllers[1].ResumeAnimation();

                //Se muestra la pantalla de orientacion al detetctar
                //OrientacionEscanear.transform.localScale = Vector3.zero;
                //OrientacionRotacionController.instance.ExplicacionRotacionModelo();
                break;
            case "QR Target Maquina2":
                
                
                Maquina maquina3 = new Maquina(
                    "Sensor de cambio volumetrico",
                    "Mide la cantidad de agua que entra o sale de la muestra."
                    //"asdasdas",
                    //"Fabricante C",
                    //"Modelo 12312",
                    //"Xwdswewr123",
                    //"2020-07-01",
                    //"En Funcionamiento",
                    //200000.0,
                    //"Laboratorio C"
                );
                
                //LimpiarCards(false);
                SlideMenu.SetActive(true);
                moverBoton(true);
                SetMaquinaInfo(maquina3);
                AsignarTextura(renderTextures[2]);
                tituloTag.text = maquina3.Nombre;
                animatorControllers[2].StartAnimation();
                animatorControllers[2].ResumeAnimation();

                //Se muestra la pantalla de orientacion al detetctar
                //OrientacionEscanear.transform.localScale = Vector3.zero;
                //OrientacionRotacionController.instance.ExplicacionRotacionModelo();
                break;
            case "QR Target Maquina3":
                
                
                Maquina maquina4 = new Maquina(
                    "Controlador de presión de agua de la cámara",
                    "Regula la presión del agua que rodea la muestra."
                    //"rerewrwe",
                    //"Fabricante D",
                    //"Modelo 3434",
                    //"423423423",
                    //"2010-07-03",
                    //"En Funcionamiento",
                    //100000.0,
                    //"Laboratorio D"
                );
                
                //LimpiarCards(false);
                SlideMenu.SetActive(true);
                moverBoton(true);
                SetMaquinaInfo(maquina4);
                AsignarTextura(renderTextures[3]);
                tituloTag.text = maquina4.Nombre;
                animatorControllers[3].StartAnimation();
                animatorControllers[3].ResumeAnimation();

                //Se muestra la pantalla de orientacion al detetctar
                //OrientacionEscanear.transform.localScale = Vector3.zero;
                //OrientacionRotacionController.instance.ExplicacionRotacionModelo();
                break;
            case "QR Target Maquina3_1":
                
               
                Maquina maquina7 = new Maquina(
                    "Controlador de contra-presión de agua de la cámara",
                    "Regula la presión interna a la que está sometida la muestra."
                    //"rerewrwe",
                    //"Fabricante D",
                    //"Modelo 3434",
                    //"423423423",
                    //"2010-07-03",
                    //"En Funcionamiento",
                    //100000.0,
                    //"Laboratorio D"
                );
                
                //LimpiarCards(false);
                SlideMenu.SetActive(true);
                moverBoton(true);
                SetMaquinaInfo(maquina7);
                AsignarTextura(renderTextures[4]);
                tituloTag.text = maquina7.Nombre;
                animatorControllers[4].StartAnimation();
                animatorControllers[4].ResumeAnimation();

                //Se muestra la pantalla de orientacion al detetctar
                //OrientacionEscanear.transform.localScale = Vector3.zero;
                //OrientacionRotacionController.instance.ExplicacionRotacionModelo();
                break;
            case "QR Target Maquina4":
                
               
                Maquina maquina5 = new Maquina(
                    "Sistema de válvulas",
                    "Regula la presión interna a la que está sometida la muestra."
                    //"edcgdfgtyt",
                    //"Fabricante E",
                    //"Modelo 2143432df",
                    //"gfgwe4543",
                    //"2015-01-03",
                    //"En Funcionamiento",
                    //178000.0,
                    //"Laboratorio E"
                );
                
                //LimpiarCards(false);
                SlideMenu.SetActive(true);
                moverBoton(true);
                SetMaquinaInfo(maquina5);
                AsignarTextura(renderTextures[5]);
                tituloTag.text = maquina5.Nombre;
                animatorControllers[5].StartAnimation();
                animatorControllers[5].ResumeAnimation();

                //Se muestra la pantalla de orientacion al detetctar
                //OrientacionEscanear.transform.localScale = Vector3.zero;
                //OrientacionRotacionController.instance.ExplicacionRotacionModelo();
                break;
            case "QR Target Maquina5":
                
                
                Maquina maquina6 = new Maquina(
                    "Emisor de actuadores y sensores",
                    "Envian señales para que se actue sobre la muestra y recoge los datos obtenidos por los sensores."
                    //"edcgdfgtyt",
                    //"Fabricante E",
                    //"Modelo 2143432df",
                    //"gfgwe4543",
                    //"2015-01-03",
                    //"En Funcionamiento",
                    //178000.0,
                    //"Laboratorio E"
                );
                
                //LimpiarCards(false);
                SlideMenu.SetActive(true);
                moverBoton(true);
                SetMaquinaInfo(maquina6);
                AsignarTextura(renderTextures[6]);
                tituloTag.text = maquina6.Nombre;
                animatorControllers[6].StartAnimation();
                animatorControllers[6].ResumeAnimation();

                //Se muestra la pantalla de orientacion al detetctar
                //OrientacionEscanear.transform.localScale = Vector3.zero;
                //OrientacionRotacionController.instance.ExplicacionRotacionModelo();
                break;
            case "QR Target Maquina6":
                
                
                Maquina maquina8 = new Maquina(
                    "Laboratorio Geomecánica",
                    "Se estudia cómo se deforman los suelos y las rocas, hasta terminar a veces en su falla, en respuesta a los cambios de esfuerzos, presión, temperatura y otros parámetros ambientales."                   //"edcgdfgtyt",
                    //"Fabricante E",
                    //"Modelo 2143432df",
                    //"gfgwe4543",
                    //"2015-01-03",
                    //"En Funcionamiento",
                    //178000.0,
                    //"Laboratorio E"
                );
                
                //LimpiarCards(false);
                SlideMenu.SetActive(true);
                moverBoton(true);
                SetMaquinaInfo(maquina8);
                tituloTag.text = maquina8.Nombre;
                rawImageComponent.transform.parent.localScale = Vector3.zero;
                //Se muestra la pantalla de orientacion al detetctar
                OrientacionRotacionController.instance.setMostrarOprimir(true);
                
                break;
            default:
                Debug.Log("ERROR: ----> No se identifico ningun iMAGEtrack, targetname: " + targetName);
                break;
        }
    }

    public void OnImageTargetLost(ObserverBehaviour mObserverBehaviour)
    {
        string targetName = mObserverBehaviour.TargetName;

        // Verifica si el objetivo que se ha perdido es el mismo que el último detectado
        if (targetName == lastDetectedTargetName)
        {
            // Limpia las tarjetas y oculta el menú cuando se pierde el seguimiento
            LimpiarCards(true);
        }
    }
    public float  getCanvasHeight()
    {
        RectTransform canvasRect = canvas.GetComponent<RectTransform>();
        Vector2 canvasSize = canvasRect.rect.size;

        // Obtén el ancho y alto del Canvas
        float canvasWidth = canvasSize.x;
        float canvasHeight = canvasSize.y;

        return canvasHeight;
    }
    public void moverBoton(bool moverHaciaArriba)
    {

        Debug.Log($"Top {top}, Bottom: {bottom}");
        RectTransform buttonRect = button.GetComponent<RectTransform>();

        float nuevaPosicionY = moverHaciaArriba ? top : bottom;
        buttonRect.anchoredPosition = new Vector2(buttonRect.anchoredPosition.x, nuevaPosicionY);
        //button.transform.DOMoveY(nuevaPosicionY, 0f);
    }

    public void SetMaquinaInfo(Maquina maquina)
    {
        Debug.Log("Llega a -->  SetMaquinaInfo  <---");
        PropertyInfo[] propiedades = typeof(Maquina).GetProperties();

        // Recorrer las propiedades y mostrar sus nombres y valores
        foreach (PropertyInfo propiedad in propiedades)
        {
            SlideMenu.SetActive(true);
            GameObject card = Instantiate(cardTemplate, transform);

            string titulo = propiedad.Name; // Nombre de la propiedad
            string valor = propiedad.GetValue(maquina, null).ToString(); // Valor de la propiedad
            TextMeshProUGUI[] textComponents = card.GetComponentsInChildren<TextMeshProUGUI>();


            if (textComponents.Length >= 2)
            {
                textComponents[0].text = AgregarEspacioAntesDeMayuscula(titulo) + ":";
                textComponents[1].text = valor;
            }
            else
            {

                Debug.LogError("No se encontraron suficientes componentes de Text en card.");
            }
           

            Debug.Log($"{titulo}: {valor}");
        }
        cardTemplate.SetActive(false);
    }

    public void LimpiarCards(bool lostTrak)
    {
        SlideMenu.SetActive(true);
        int childCount = transform.childCount;
        rawImageComponent.transform.parent.localScale = Vector3.one;
        //Se quita la orientacion de oprimir 
        OrientacionRotacionController.instance.setMostrarOprimir(false);

        StopAnimation();


        for (int i = 2; i < childCount; i++)
        {
            
                GameObject child = transform.GetChild(i).gameObject;
                Destroy(child);
           
        }
        cardTemplate.SetActive(true);
        if (lostTrak)
        {
            Debug.Log("limpiar cards true, se mueve boton y se esconde el menu inferior");
           
            SlideMenu.SetActive(false);
            moverBoton(false);
            //Se muestra pantalla de escanear
            OrientacionEscanear.transform.localScale = Vector3.one;
            //Se muestra el nuevo tag par el titulo por defecto
            practicaTag.transform.localScale = Vector3.one;
            ContainerTituloTag.transform.localScale = Vector3.zero;

        }
        else
        {
            Debug.Log("limpiar cards false, sin mover boton y sin esconder el menu inferior");
        }
        
    }
    public void AsignarTextura(RenderTexture renderTexture)
    {

        rawImageComponent.texture = renderTexture;
        
    }
    public void StopAnimation()
    {
        foreach (var controller in animatorControllers)
        {
            controller.PauseAnimation();
        }
    }

    public static string AgregarEspacioAntesDeMayuscula(string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return input;
        }

        StringBuilder output = new StringBuilder(input.Length * 2); 

        output.Append(input[0]); 

        for (int i = 1; i < input.Length; i++)
        {

            if (char.IsUpper(input[i]) && !char.IsUpper(input[i - 1]))
            {
                output.Append(' ');
            }

            output.Append(input[i]);
        }

        return output.ToString();
    }
}



