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
    public event Action onPopUpAlertOpen;
    public event Action onPopUpAlertClose;
    public event Action onTeoricoMascota;


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
    public void TeoricoMascota()
    {
        onTeoricoMascota?.Invoke();
    }
    public void VentanaEmergenteOpen()
    {
        onVentanaEmergenteOpen?.Invoke();
    }
    public void VentanaEmergenteClose()
    {
       
        onVentanaEmergenteClose?.Invoke();
       
    }
    public void PopAlertOpen()
    {
        onPopUpAlertOpen?.Invoke();
    }
    public void PopAlertClose()
    {

        onPopUpAlertClose?.Invoke();
       
    }
    public void Close()
    {
        Debug.Log("Closing app");
        Application.Quit();
    }

}
