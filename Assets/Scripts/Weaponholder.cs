using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weaponholder : MonoBehaviour
{
    [SerializeField] private int armaActual = 0;
    [SerializeField] private GameObject[] armas;
    
    
    void Start()
    {
        
    }

  
    void Update()
    {
        CambiarArmaKey();
    }
    private void CambiarArmaKey()
    { 
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            CambioDeArma(0);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            CambioDeArma(1);
        }
    }
    //metodo para cambiar de arma
    private void CambioDeArma(int nuevoIndice)
    {
        if (nuevoIndice >= 0 && nuevoIndice < armas.Length )
        {
            armas[armaActual].SetActive(false);//quitar el arma
            armaActual = nuevoIndice; //cambiar el indice actual
            armas[armaActual].SetActive(true);//pon el arma
        }

    }
}
