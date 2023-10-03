using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Vuforia;


public class ARController : MonoBehaviour
{
    //public ImageTargetBehaviour[] ImageTargets;
    public GameObject SlideMenu;
    GameObject cardTemplate;
    public GameObject button;
    public Canvas canvas;
    private string lastDetectedTargetName;

    private float top;
    private float bottom;

    private void Start()

    {
        lastDetectedTargetName = null;
        top = -60f+ getCanvasHeight();
        bottom = 60f;

        cardTemplate = transform.GetChild(0).gameObject;
        SlideMenu.SetActive(false);
    }
    private void Awake()
    {
        //buttonPosition = button.transform.position.y;
    }
    private void Update()
    {
    }
    public void OnImageTargetDetected(ObserverBehaviour mObserverBehaviour)
    {

       
        var im = new InfoMaquinaController();

        string targetName = mObserverBehaviour.TargetName;

        if (targetName != lastDetectedTargetName)
        {
            // Limpia las tarjetas y oculta el men� si se detect� un nuevo objetivo
            LimpiarCards(false);
            SlideMenu.SetActive(false);
            moverBoton(false);
        }

        lastDetectedTargetName = targetName;

        switch (targetName)
        {
            


            case "QR Target":
               
                Debug.Log("Bien: ----> Se identifico  Maquina1");
                Maquina maquina1 = new Maquina(
                   "M�quina de Ensayo de Compresi�n",
                   "Esta m�quina se utiliza para realizar ensayos de compresi�n en muestras de suelo.",
                   "Medir la resistencia a la compresi�n de materiales geot�cnicos",
                   "Fabricante A",
                   "Modelo 123",
                   "S123456",
                   "2022-01-15",
                   "En funcionamiento",
                   25000.0,
                   "Laboratorio A"
                );
                
                //LimpiarCards(false);
                SlideMenu.SetActive(true);
                //moverBoton();
                moverBoton(true);

                SetMaquinaInfo(maquina1);
                break;
            case "QR Target Maquina2":
                
                Debug.Log("Bien: ----> Se identifico  Maquina2");
                Maquina maquina2 = new Maquina(
                    "M�quina de Ensayo de Tracci�n",
                    "Esta m�quina se utiliza para realizar ensayos de tracci�n en probetas de roca.",
                    "Medir la resistencia a la tracci�n de muestras geol�gicas.",
                    "Fabricante B",
                    "Modelo 456",
                    "T789012",
                    "2021-11-30",
                    "En reparaci�n",
                    18000.0,
                    "Laboratorio B"
                );
                
                //LimpiarCards(false);
                SlideMenu.SetActive(true);
                moverBoton(true);
                SetMaquinaInfo(maquina2);

                break;
            default:
                Debug.Log("ERROR: ----> No se identifico ningun iMAGEtrack, targetname: " + targetName);
                break;
        }
    }

    public void OnImageTargetLost(ObserverBehaviour mObserverBehaviour)
    {
        string targetName = mObserverBehaviour.TargetName;

        // Verifica si el objetivo que se ha perdido es el mismo que el �ltimo detectado
        if (targetName == lastDetectedTargetName)
        {
            // Limpia las tarjetas y oculta el men� cuando se pierde el seguimiento
            LimpiarCards(true);
        }
    }
    public float  getCanvasHeight()
    {
        RectTransform canvasRect = canvas.GetComponent<RectTransform>();
        Vector2 canvasSize = canvasRect.rect.size;

        // Obt�n el ancho y alto del Canvas
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


        for (int i = 1; i < childCount; i++)
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
        }
        else
        {
            Debug.Log("limpiar cards false, sin mover boton y sin esconder el menu inferior");
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



