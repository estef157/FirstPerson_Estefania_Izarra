using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemigo : MonoBehaviour
{
    private Firstperson player;
    [SerializeField] private float vidas;
    [SerializeField] float stoppingDistance;
    [SerializeField] private Transform ataqueDistancia;
    private Animator anim;
    [SerializeField] private float radioAtaque;
    [SerializeField] private float ataqueDano;
    private float danhoRecibido;
    public float Vidas { get => vidas; set => vidas = value; }
    [SerializeField] private AudioSource audioSource;
    private NavMeshAgent agent;
    private Rigidbody[] huesos;
    
    [SerializeField] private LayerMask queEsPlayer;

    private bool ventanaAbierta = false;
    private bool danhoRealizado = false;



    
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindObjectOfType<Firstperson>();
        anim = GetComponent<Animator>();
        huesos = GetComponentsInChildren<Rigidbody>();
        CambiarHuesos(true);
    }


    
    void Update()
    {
        

        if (agent.enabled)
        {

            Perseguir();

        }
        if (ventanaAbierta && danhoRealizado == false && agent.enabled)
        {

            DetectarJugador();
        }



    }

    private void RecibirDanho()
    {

    }

    private void EnfocarPlayer()
    {
        
        Vector3 direccionAPlayer = (player.transform.position - this.gameObject.transform.position).normalized;

       
        direccionAPlayer.y = 0;

        
        transform.rotation = Quaternion.LookRotation(direccionAPlayer);
    }

    private void DetectarJugador()
    {
        Collider[] collsDetects = Physics.OverlapSphere(ataqueDistancia.position, radioAtaque, queEsPlayer);
        if (collsDetects.Length > 0)
        {
            for (int i = 0; i < collsDetects.Length; i++)
            {
                collsDetects[i].GetComponent<Firstperson>().RecibirDanho(ataqueDano);

            }
            danhoRealizado = true;
        }
    }
    private void Perseguir()
    {
        agent.SetDestination(player.transform.position);
        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            agent.isStopped = true;
            anim.SetBool("Attacking", true);
        }
    }

    private void CambiarHuesos(bool estado)
    {
        for (int i = 0; i < huesos.Length; i++)
        {
            huesos[i].isKinematic = estado;
        }
    }
    
    private void FinalizarAtaque()
    {
        danhoRealizado = false;
        agent.isStopped = false;
        anim.SetBool("attacking", false);
    }

    public void Morir()
    {
        anim.enabled = false;
        audioSource.enabled = false;
        agent.enabled = false;
        CambiarHuesos(false);
        Destroy(gameObject, 5);
    }
}
