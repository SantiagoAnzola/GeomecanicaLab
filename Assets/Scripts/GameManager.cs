using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public event Action onMenu;
    public event Action onScan;
    public event Action onTeorico;
    public event Action onVentanaEmergenteOpen;
    public event Action onVentanaEmergenteClose;


    public static GameManager instance;

    private Animator animatorController;
    //[SerializeField] public string modelo;
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance= this;
        }
    }
    void Start()
    {
        animatorController = GetComponent<Animator>();
        MenuPrincipal();
    }

    public void MenuPrincipal()
    {
        onMenu?.Invoke();
        Debug.Log("Menu principal");
    }
    public void Scan()
    {
        onScan?.Invoke();
        Debug.Log("Scan");
    }
    public void Teorico()
    {
        onTeorico?.Invoke();
    }
    public void VentanaEmergenteOpen()
    {
        onVentanaEmergenteOpen?.Invoke();
    }
    public void VentanaEmergenteClose()
    {
       
        onVentanaEmergenteClose?.Invoke();
       
    }
    public void Close()
    {
        Application.Quit();
    }

}
