using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] public GameObject menuPrincipal;
    [SerializeField] public GameObject scan;
    [SerializeField] public GameObject Teorico;
    [SerializeField] public GameObject ventanaEmergente;
    [SerializeField] public GameObject popUpAlert;
    [SerializeField] public GameObject Canvas;
    [SerializeField] public GameObject TeoricoMascota;
    private CanvasGroup canvasGroup;


    private float canvasHeight;
    void Start()
    {
        canvasGroup = popUpAlert.GetComponentInParent<CanvasGroup>();
        GameManager.instance.onScan += ActiveScanView;
        GameManager.instance.onMenu += ActiveMenuView;
        GameManager.instance.onTeorico += ActiveTeoricoView;
        GameManager.instance.onVentanaEmergenteOpen += ActiveVentanaEmergenteView;
        GameManager.instance.onVentanaEmergenteClose += DesActiveVentanaEmergenteView;
        GameManager.instance.onPopUpAlertOpen += ActivePopUpAlertView;
        GameManager.instance.onPopUpAlertClose += DesActivePopUpAlertView;
        GameManager.instance.onTeoricoMascota += ActiveTeoricoMascotaView;
    }

    public void ActiveScanView()
    {
        menuPrincipal.transform.DOScale(new Vector3(0, 0, 0), 0.2f);
        menuPrincipal.transform.DOMoveX(-Screen.width, 0.2f);

        scan.transform.DOScale(new Vector3(1, 1, 1),0.2f);

        VuforiaCamaraController.Instance.ActivarCamaraVuforia();
    }
    public void ActiveMenuView()
    {
        scan.transform.DOScale(new Vector3(0, 0, 0), 0.2f);

        Teorico.transform.DOScale(new Vector3(0, 0, 0), 0.2f);

        menuPrincipal.transform.DOScale(new Vector3(1,1,1), 0.2f);
        menuPrincipal.transform.DOMoveX(Screen.width/2, 0.2f);

        VuforiaCamaraController.Instance.DesactivarCamaraVuforia();
    }
    private void ActiveTeoricoView()
    {
        VuforiaCamaraController.Instance.DesactivarCamaraVuforia();
        menuPrincipal.transform.DOScale(new Vector3(0, 0, 0), 0.2f);
        menuPrincipal.transform.DOMoveX(-Screen.width / 2, 0.2f);
        Teorico.transform.DOScale(new Vector3(1, 1, 1), 0.2f);
        TeoricoMascota.transform.DOScale(new Vector3(0, 0, 0),0.2f);
    }
    private void ActiveTeoricoMascotaView()
    {
        scan.transform.DOScale(new Vector3(0, 0, 0), 0.2f);

        TeoricoMascota.transform.DOScale(new Vector3(1, 1, 1), 0.2f);
    }
    private void ActiveVentanaEmergenteView()
    {
        GameObject child0 = ventanaEmergente.transform.GetChild(0).gameObject;
        child0.transform.DOMoveY(Screen.height/2, 0.0f);

        GameObject child = ventanaEmergente.transform.GetChild(1).gameObject;
        child.transform.DOMoveY(Screen.height/2, 0.2f).SetEase(Ease.OutQuad); ;
        child.transform.DOScale(new Vector3(1,1,1),0.2f).SetEase(Ease.OutQuad); ;
    }
    private void DesActiveVentanaEmergenteView()
    {
        GameObject child0 = ventanaEmergente.transform.GetChild(0).gameObject;
        child0.transform.DOMoveY(-Screen.height, 0.0f);

        GameObject child = ventanaEmergente.transform.GetChild(1).gameObject;
        child.transform.DOMoveY(-Screen.height, 0.2f).SetEase(Ease.InQuad); ;
        child.transform.DOScale(new Vector3(0,0,0),0.2f).SetEase(Ease.InQuad); ;
    }
    private void ActivePopUpAlertView()
    {

        //canvasGroup.alpha = 98 / 255.0f;
        
        popUpAlert.transform.DOScale(new Vector3(1, 1, 1), 0.0f);
        GameObject child = popUpAlert.transform.GetChild(1).gameObject;
        child.transform.DOMoveY(+Screen.height/2, 0.2f).SetEase(Ease.OutQuad); 
        child.transform.DOScale(new Vector3(1,1,1),0.2f).SetEase(Ease.OutQuad); 

        GameObject child0 = popUpAlert.transform.GetChild(0).gameObject;
        child0.transform.DOMoveY(+Screen.height / 2, 0.0f);


    }
    private void DesActivePopUpAlertView()
    {
        //popUpAlert.transform.DOScale(new Vector3(1, 1, 1), 0.0f);
        //canvasGroup.alpha = 0.0f;
        GameObject child0 = popUpAlert.transform.GetChild(0).gameObject;
        child0.transform.DOMoveY(-Screen.height, 0.0f);
        GameObject child = popUpAlert.transform.GetChild(1).gameObject;
        child.transform.DOMoveY(-Screen.height, 0.2f).SetEase(Ease.InQuad); ;
        child.transform.DOScale(new Vector3(0,0,0),0.2f).SetEase(Ease.InQuad); ;
    }

}
