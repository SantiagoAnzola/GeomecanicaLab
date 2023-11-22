using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public Sprite[] imagenes;
    public RuntimeAnimatorController[] giftsMaquinas;
    public Image espacioImagen;
    public GameObject contenedorImagen;
    public GameObject boton;
    public GameObject check;
    public void TriggerDialogue ()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue, imagenes, espacioImagen, contenedorImagen, boton, check, giftsMaquinas);
    }
}
