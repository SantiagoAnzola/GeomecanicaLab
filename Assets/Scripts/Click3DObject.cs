using DanielLochner.Assets.SimpleSideMenu;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Click3DObject : MonoBehaviour
{

    [SerializeField] public GameObject sideMenu;

    [SerializeField] public RawImage rawImageComponent; // Arrastra el componente Raw Image al Inspector
    [SerializeField] public RenderTexture renderTextures; // Arrastra el Render Texture al Inspector
    public GameObject[] animatorObjects; // Assign the GameObjects with Animators in the Inspector

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
            //foreach (var controller in animatorControllers)
            //{
            //    controller.StartAnimation();
            //}
            //foreach (var controller in animatorControllers)
            //{
            //    controller.ResumeAnimation();
            //}

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
    }
}
