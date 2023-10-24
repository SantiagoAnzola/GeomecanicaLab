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


    public static string AgregarEspacioAntesDeMayuscula(string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return input;
        }

        StringBuilder output = new StringBuilder(input.Length * 2); // Usamos un StringBuilder para un rendimiento más eficiente

        output.Append(input[0]); // Agregamos la primera letra

        for (int i = 1; i < input.Length; i++)
        {
            // Si la letra actual es mayúscula y la anterior no lo es, agregamos un espacio
            if (char.IsUpper(input[i]) && !char.IsUpper(input[i - 1]))
            {
                output.Append(' ');
            }

            output.Append(input[i]); // Agregamos la letra actual
        }

        return output.ToString();
    }

}


