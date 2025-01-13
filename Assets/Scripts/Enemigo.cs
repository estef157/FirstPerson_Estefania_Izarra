using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemigo : MonoBehaviour
{
    private Animator anim;
    [SerializeField] private LayerMask queEsPlayer;
    [SerializeField] private float ataqueDano;
    private float danhoRecibido;
    [SerializeField] private float radioAtaque;
    [SerializeField] float stoppingDistance;
    [SerializeField] private Transform ataqueDistancia;
    private NavMeshAgent agent;
    private Firstperson player;
    private Rigidbody[] huesos;

    private bool ventanaAbierta = false;
    private bool danhoRealizado = false;


    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindObjectOfType<Firstperson>();
        GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update()
    {
        //Tengo que definir como destino la posicion del player.

        if (agent.enabled)
        {

            Perseguir();

        }
        if (ventanaAbierta && danhoRealizado == false && agent.enabled)
        {

            DetectarJugador();
        }



    }

    private void EnfocarPlayer()
    {
        //Calcular Vector que apunte al jugador
        Vector3 direccionAPlayer = (player.transform.position - this.gameObject.transform.position).normalized;

        //Me aseguro que no se vuelve al enemigo al ver al player 
        direccionAPlayer.y = 0;

        //Calculo la rotacion a la que tengo que girar para orientarme en esa direccion.
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
        anim.SetBool("walking", true);
        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            agent.isStopped = true;
            anim.SetBool("attacking", true);
        }
    }

    
    private void FinalizarAtaque()
    {
        danhoRealizado = false;
        agent.isStopped = false;
        anim.SetBool("attacking", false);
    }

}
