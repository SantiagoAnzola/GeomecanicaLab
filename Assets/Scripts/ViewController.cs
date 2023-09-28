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

    void Start()
    {
        GameManager.instance.onScan += ActiveScanView;
        GameManager.instance.onMenu += ActiveMenuView;
        GameManager.instance.onTeorico += ActiveTeoricoView;
    }

    public void ActiveScanView()
    {
        menuPrincipal.transform.DOScale(new Vector3(0, 0, 0), 0.2f);
        menuPrincipal.transform.DOMoveX(-Screen.width, 0.2f);

        scan.transform.DOScale(new Vector3(1, 1, 1),0.2f);
    }
    public void ActiveMenuView()
    {
        scan.transform.DOScale(new Vector3(0, 0, 0), 0.2f);

        Teorico.transform.DOScale(new Vector3(0, 0, 0), 0.2f);

        menuPrincipal.transform.DOScale(new Vector3(1,1,1), 0.2f);
        menuPrincipal.transform.DOMoveX(Screen.width/2, 0.2f);
    }
    private void ActiveTeoricoView()
    {
        menuPrincipal.transform.DOScale(new Vector3(0, 0, 0), 0.2f);
        menuPrincipal.transform.DOMoveX(-Screen.width / 2, 0.2f);

        Teorico.transform.DOScale(new Vector3(1, 1, 1), 0.2f);
    }

}