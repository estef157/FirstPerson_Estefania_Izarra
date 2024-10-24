using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firstperson : MonoBehaviour

{
    [SerializeField] private float velocidadMovimiento;
    CharacterController characterController;
    private Camera cam;
    [SerializeField] private float smoothing;
    private float velocidadRotacion;




    // Start is called before the first frame update
    void Start()
    {
        GetComponent<CharacterController>();
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        //Vector3 movimiento  = new Vector3 (h, 0, v);
        Vector2 input  = new Vector2 (h, v).normalized;

        if  (input.sqrMagnitude > 0)
        {
            float anguloRotacion = Mathf.Atan2(input.x, input.y) * Mathf.Rad2Deg + cam.transform.eulerAngles.y;
            float anguloSuave = Mathf.SmoothDampAngle(transform.eulerAngles.y, anguloRotacion, ref velocidadRotacion, smoothing);
         transform.eulerAngles = new Vector3(0, anguloSuave, 0);

            Vector3 movimiento = Quaternion.Euler(0, anguloRotacion, 0) * Vector3.forward;
            characterController.Move(movimiento * 5 * Time.deltaTime);
            
        }








        characterController.Move(input * velocidadMovimiento * Time.deltaTime);
    }
}
