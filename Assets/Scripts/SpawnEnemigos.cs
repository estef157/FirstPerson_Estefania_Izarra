using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SpawnEnemigos : MonoBehaviour
{
    [SerializeField] private Transform[] aparicionPuntos;
    [SerializeField] private Enemigo enemigo;
    void Start()
    {
        StartCoroutine (SpawnDeEnemigos());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator SpawnDeEnemigos()
    {
        while (true)
        {
            Enemigo copiaEnemigo = Instantiate(enemigo, aparicionPuntos[Random.Range(0, aparicionPuntos.Length)].position,Quaternion.identity);
            yield return new WaitForSeconds(3);
        }
    }


}
