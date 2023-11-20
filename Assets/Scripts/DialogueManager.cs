using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

using System;
using Random = UnityEngine.Random;
using System.Reflection;

public class DialogueManager : MonoBehaviour
{
    public Animator Mascota;
    public AudioSource audioSource;

    public RuntimeAnimatorController[] AnimatorController;
    public AudioClip [] mascotaSoundList;
    public RectTransform textArea;

    private int x,y;
    private int count=0;
    private List<Sprite> imagenesLocales=null;
    Image lugarParaImagen=null;
    GameObject ContenedorLugarParaImagen = null;

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public GameManager gameManager;
    public Button anterior;
    private LinkedList<string> sentences;
    private LinkedListNode<string> currentSentence;

    private GameObject boton;
    private GameObject check;
    // Start is called before the first frame update
    void Start()
    {
        
        sentences = new LinkedList<string>();
        
    }

    public void StartDialogue(Dialogue dialogue, Sprite[] imagenes, Image espacioImagen, GameObject contenedorEspacioImagen, GameObject botonn, GameObject checkk)
    {
        nameText.text = dialogue.name;
        boton = botonn;
        check=checkk;
        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.AddLast(sentence);
        }
        imagenesLocales = new List<Sprite>((IEnumerable<Sprite>)imagenes);
        lugarParaImagen = espacioImagen;
        ContenedorLugarParaImagen = contenedorEspacioImagen;

        Vector2 newPosition = new Vector2(textArea.anchoredPosition.x, 0f);
        textArea.anchoredPosition = newPosition;

        currentSentence = sentences.First;
        dialogueText.text = currentSentence.Value;
        anterior.interactable = false;
        count=1;
        ChangeImageOnClick();
    }

    public void DisplayNextSentence()
    {
        Vector2 newPosition = new Vector2(textArea.anchoredPosition.x, 0f);
        textArea.anchoredPosition = newPosition;
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        if (currentSentence == null)
        {
            currentSentence = sentences.First;
        }
        else
        {
            
            currentSentence = currentSentence.Next;
            if (currentSentence == null)
            {
                //currentSentence = sentences.First;
                EndDialogue();
                return;
            }
            else
            {
                dialogueText.text = currentSentence.Value;
                ChangeImageOnClick();
                anterior.interactable = true;
                count++;
                ShowImage(count);
            }
        }

       
    }

    public void DisplayPreviousSentence()
    {
        Vector2 newPosition = new Vector2(textArea.anchoredPosition.x, 0f);
        textArea.anchoredPosition = newPosition;

        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        if (currentSentence == null || currentSentence == sentences.First)
        {
            currentSentence = sentences.First;
            anterior.interactable = false;
        }
        else
        {
            currentSentence = currentSentence.Previous;
            if (currentSentence == null || currentSentence == sentences.First)

            {
                //currentSentence = sentences.Last;
                
                currentSentence = sentences.First;
                Debug.Log("Reached the beginning of the dialogue.");
                anterior.interactable = false;
                
            }
            else
            {
                anterior.interactable = true;
                
            }
            ChangeImageOnClick();
            dialogueText.text = currentSentence.Value;
            count--;
            ShowImage(count);
        }

        //dialogueText.text = currentSentence.Value;
    }


    private void ShowImage(int index)
    {
        
        if (index > 0 && index <= imagenesLocales.Count && imagenesLocales[index-1] != null && lugarParaImagen!=null)
        {

            ContenedorLugarParaImagen.transform.localScale = Vector3.one;
            lugarParaImagen.sprite = imagenesLocales[index-1];
            Debug.Log("index: " + index);
        }
        else
        {
            if (lugarParaImagen != null)
            {
                ContenedorLugarParaImagen.transform.localScale= Vector3.zero;
                
            }
            
            return;
        }
       
    }
    void EndDialogue()
    {
        if(lugarParaImagen!=null) {
            ContenedorLugarParaImagen.transform.localScale = Vector3.zero;
        }
        if(check!=null&& boton!=null)
        {
            check.transform.localScale = Vector3.one;
            boton.GetComponent<Image>().color = new Color32(90, 167, 219, 255);
        }
        
        
        currentSentence =sentences.First;
        gameManager.Teorico();
        Debug.Log("End of Conversation.");
    }
    public void ChangeImageOnClick()
    {
        x = Random.Range(0, AnimatorController.Length);
        Mascota.runtimeAnimatorController = AnimatorController[x];

        y = Random.Range(0, mascotaSoundList.Length);
        audioSource.clip = mascotaSoundList[y];
        audioSource.Play();
    }

}
