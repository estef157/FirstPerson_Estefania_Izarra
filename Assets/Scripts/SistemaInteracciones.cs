using Digger;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SistemaInteracciones : MonoBehaviour
{
    [SerializeField] private Transform interactuableActual;
    private Camera cam;
    [SerializeField] private float distanciaInteraccion;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
       

        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out RaycastHit hit, distanciaInteraccion))
        {
            if (hit.transform.CompareTag("ObjetoInterac"))
            {
                interactuableActual = hit.transform;
                interactuableActual.GetComponent<Outline>().enabled = true;
                if (Input.GetKeyDown(KeyCode.E))
                {



                    


                }

            }

        }
        else if (interactuableActual)
        {
            interactuableActual.GetComponent<Outline>().enabled = false;
            interactuableActual = null;
        }
    }
}
