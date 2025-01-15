using Cinemachine.Utility;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;

public class ArmaManual : MonoBehaviour
{
    [SerializeField] private ParticleSystem system;
    [SerializeField] private armaSo datitos;
    private Camera cam;
    
    
    Animator anim;
    private bool preparado;

   
    private void Awake()
    {
        anim = GetComponent<Animator>();
        anim = GetComponent<Animator>();
        anim = GetComponent<Animator>();
    }
    void Start()
    {

        cam = Camera.main;
       
    }

   
    void Update()
    {
                if (Input.GetMouseButtonDown(0))
                {
                    
                    system.Play();
                    if (Physics.Raycast(cam.transform.position, cam.transform.forward, out RaycastHit hitinfo, datitos.ataqueDistancia))
                    {
                        if (hitinfo.transform.CompareTag("ParteEnemigo"))
                        {
                            Debug.Log(hitinfo.transform.name);
                            hitinfo.transform.GetComponent<ParteDeEnemigo>().RecibirDanho(datitos.danhoAtaque);
                        }

                    }
                }
          

    }
   

}
