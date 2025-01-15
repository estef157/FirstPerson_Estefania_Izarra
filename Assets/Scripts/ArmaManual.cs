using Cinemachine.Utility;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;

public class ArmaManual : MonoBehaviour
{
    [SerializeField] private ParticleSystem system;
    [SerializeField] private ArmaSo misDatos;
    private Camera cam;
    [SerializeField] int balas;
    [SerializeField] TMP_Text balastext;
    Animator anim;
    private bool preparado;

   
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    void Start()
    {

        cam = Camera.main;
        balas = misDatos.balasCargador;
    }

   
    void Update()
    {
        balastext.SetText("balas: " + balas);
        if (preparado)
        {


            if (balas > 0)
            {
                anim.SetBool("Recargar", false);

                if (Input.GetMouseButtonDown(0))
                {
                    balas -= 1;
                    system.Play();
                    Debug.Log("pium");
                    if (Physics.Raycast(cam.transform.position, cam.transform.forward, out RaycastHit hitinfo, misDatos.distanciaAtaque))
                    {
                        if (hitinfo.transform.CompareTag("ParteEnemigo"))
                        {
                            Debug.Log(hitinfo.transform.name);
                            hitinfo.transform.GetComponent<ParteDeEnemigo>().RecibirDanho(misDatos.danhoAtaque);
                        }

                    }
                }
            }
            else
            {
                anim.SetBool("Recargar", true);

            }
        }

    }
    public void Recargar()
    {
        balas = 7;
    }
    public void Preparado()
    {
        preparado = true;
    }

}
