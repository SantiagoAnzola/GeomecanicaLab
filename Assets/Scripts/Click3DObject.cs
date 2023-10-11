using DanielLochner.Assets.SimpleSideMenu;

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Click3DObject : MonoBehaviour
{

    [SerializeField] public GameObject sideMenu;

    [SerializeField] public RawImage rawImageComponent;
    [SerializeField] public TextMeshProUGUI textComponent;
    [SerializeField] public string textRawImageComponent;

    [SerializeField] public RenderTexture renderTextures; 
    public GameObject[] animatorObjects; 

    private AnimatorControllerScript[] animatorControllers;
    private void Start()
    {
        animatorControllers = new AnimatorControllerScript[animatorObjects.Length];
        for (int i = 0; i < animatorObjects.Length; i++)
        {
            animatorControllers[i] = animatorObjects[i].GetComponent<AnimatorControllerScript>();
        }
    }
    void OnMouseDown()
    {

        if (sideMenu.transform.position.y < 327)
        {
            print(">>>>>>>>>click");
            AsignarTextura();
            animatorControllers[0].StartAnimation();
            animatorControllers[0].ResumeAnimation();

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
    }
}
