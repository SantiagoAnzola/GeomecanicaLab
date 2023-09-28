using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System.Text;

public class InfoMaquinaController : MonoBehaviour
{


    ////Maquinas
    //Maquina maquina1 = new Maquina(
    //      "M�quina de Ensayo de Compresi�n",
    //      "Esta m�quina se utiliza para realizar ensayos de compresi�n en muestras de suelo.",
    //      "Medir la resistencia a la compresi�n de materiales geot�cnicos.",
    //      "Fabricante A",
    //      "Modelo 123",
    //      "S123456",
    //      "2022-01-15",
    //      "En funcionamiento",
    //      25000.0,
    //      "Laboratorio A"
    //  );

    //Maquina maquina2 = new Maquina(
    //    "M�quina de Ensayo de Tracci�n",
    //    "Esta m�quina se utiliza para realizar ensayos de tracci�n en probetas de roca.",
    //    "Medir la resistencia a la tracci�n de muestras geol�gicas.",
    //    "Fabricante B",
    //    "Modelo 456",
    //    "T789012",
    //    "2021-11-30",
    //    "En reparaci�n",
    //    18000.0,
    //    "Laboratorio B"
    //);

    //Maquina maquina3 = new Maquina(
    //    "M�quina de Ensayo de Penetraci�n Est�ndar",
    //    "Esta m�quina se utiliza para realizar ensayos de penetraci�n est�ndar en suelos.",
    //    "Evaluar la resistencia y densidad del suelo en investigaciones geot�cnicas.",
    //    "Fabricante C",
    //    "Modelo 789",
    //    "P345678",
    //    "2023-02-10",
    //    "Disponible",
    //    32000.0,
    //    "Laboratorio C"
    //);
   
    //public static GameObject cardTemplate;
    //public void setInfo(Maquina maquina, GameObject cardTemplate)
    //{
    //    SetMaquinaInfo(maquina,cardTemplate);
    //}

    public void SetMaquinaInfo(Maquina maquina, GameObject cardTemplate)
    {
        Debug.Log("Llega a -->  SetMaquinaInfo  <---");
        PropertyInfo[] propiedades = typeof(Maquina).GetProperties();
        
        // Recorrer las propiedades y mostrar sus nombres y valores
        foreach (PropertyInfo propiedad in propiedades)
        {
            GameObject card = Instantiate(cardTemplate, transform);
            
            string titulo = propiedad.Name; // Nombre de la propiedad
            string valor = propiedad.GetValue(maquina, null).ToString(); // Valor de la propiedad
            TextMeshProUGUI[] textComponents = card.GetComponentsInChildren<TextMeshProUGUI>();
            //card.transform.GetChild(0).GetComponent<Text>().text=titulo;

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
    }
    //private void Start()
    //{

    //    Maquina maquina1 = new Maquina(
    //       "M�quina de Ensayo de Compresi�n",
    //       "Esta m�quina se utiliza para realizar ensayos de compresi�n en muestras de suelo.",
    //       "Medir la resistencia a la compresi�n de materiales geot�cnicos",
    //       "Fabricante A",
    //       "Modelo 123",
    //       "S123456",
    //       "2022-01-15",
    //       "En funcionamiento",
    //       25000.0,
    //       "Laboratorio A"
    //       );
    //    if (maquina1 != null)
    //    {
    //        // Crear una instancia de MaquinaGeomecanica
    //        GameObject cardTemplate = transform.GetChild(0).gameObject;

    //        PropertyInfo[] propiedades = typeof(Maquina).GetProperties();

    //        // Recorrer las propiedades y mostrar sus nombres y valores
    //        foreach (PropertyInfo propiedad in propiedades)
    //        {
    //            GameObject card = Instantiate(cardTemplate, transform);
    //            string titulo = propiedad.Name; // Nombre de la propiedad
    //            string valor = propiedad.GetValue(maquina1, null).ToString(); // Valor de la propiedad
    //            TextMeshProUGUI[] textComponents = card.GetComponentsInChildren<TextMeshProUGUI>();
    //            //card.transform.GetChild(0).GetComponent<Text>().text=titulo;

    //            if (textComponents.Length >= 2)
    //            {
    //                textComponents[0].text = AgregarEspacioAntesDeMayuscula(titulo)+":";
    //                textComponents[1].text = valor;
    //            }
    //            else
    //            {
    //                Debug.Log("----------> Cantidad de hijos:  "+textComponents.Length);
    //                Debug.LogError("No se encontraron suficientes componentes de Text en card.");
    //            }

    //            Debug.Log($"{titulo}: {valor}");
    //        }
    //        Destroy( cardTemplate );

    //    }
    //    else
    //    {
    //        Debug.LogError("maquina no ha sido inicializada correctamente.");
    //    }
    //}

    public static string AgregarEspacioAntesDeMayuscula(string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return input;
        }

        StringBuilder output = new StringBuilder(input.Length * 2); // Usamos un StringBuilder para un rendimiento m�s eficiente

        output.Append(input[0]); // Agregamos la primera letra

        for (int i = 1; i < input.Length; i++)
        {
            // Si la letra actual es may�scula y la anterior no lo es, agregamos un espacio
            if (char.IsUpper(input[i]) && !char.IsUpper(input[i - 1]))
            {
                output.Append(' ');
            }

            output.Append(input[i]); // Agregamos la letra actual
        }

        return output.ToString();
    }

}


