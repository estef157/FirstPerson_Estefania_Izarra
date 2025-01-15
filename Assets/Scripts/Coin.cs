using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] Vector3 vectorMov;
    [SerializeField] float velocidadmov;
    float timer = 0;
    [SerializeField] int velocidadRot;
    [SerializeField] Vector3 direccionRot;

   

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        transform.Rotate(direccionRot * velocidadRot * Time.deltaTime);
        transform.Translate(vectorMov * velocidadmov * Time.deltaTime, Space.World);
        if (timer >= 1f)
        {
            vectorMov = vectorMov * -1;
            timer = 0;
        }

    }
    
}
