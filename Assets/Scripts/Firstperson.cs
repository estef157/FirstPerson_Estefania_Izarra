using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firstperson : MonoBehaviour

{
    [SerializeField] private float velocidadMovimiento;
    CharacterController characterController;
   
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        //Vector3 movimiento  = new Vector3 (h, 0, v);
        Vector2 input  = new Vector2 (h, v).normalized;

        characterController.Move(input * velocidadMovimiento * Time.deltaTime);
    }
}
