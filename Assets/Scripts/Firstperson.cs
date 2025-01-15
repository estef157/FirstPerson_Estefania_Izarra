using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Firstperson : MonoBehaviour

{
    private int puntuacion;
    [SerializeField] public Slider slider;
    [SerializeField] TMP_Text textoPuntos;
    [SerializeField] private float velocidadMovimiento;
    [SerializeField] private Vector3 movimientoVertical;
    [SerializeField] private float vidas;
    private float vidasActual;
    private CharacterController cc;
    private Camera cam;
    [SerializeField] private float radioDeteccion = 0.3f;
    [SerializeField] private float escalaGravedad;
    [SerializeField] private float alturaSalto = 3f;
    [SerializeField] private Transform pies;
    [SerializeField] private LayerMask layerSuelo;


 
   

    // Start is called before the first frame update
    void Start()
    {
        vidasActual = vidas;
        Cursor.lockState = CursorLockMode.Locked;
        cc = GetComponent<CharacterController>();
        cam = Camera.main;

    }

    // Update is called once per frame
    void Update()
    {

        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Vector2 input = new Vector2(h, v).normalized;
        transform.rotation = Quaternion.Euler(0, cam.transform.eulerAngles.y, 0);

        if (input.sqrMagnitude > 0)
        {
            float anguloRotacion = Mathf.Atan2(input.x, input.y) * Mathf.Rad2Deg + cam.transform.eulerAngles.y;
            transform.eulerAngles = new Vector3(0, anguloRotacion, 0);
            Vector3 movimiento = Quaternion.Euler(0, anguloRotacion, 0) * Vector3.forward;
            cc.Move((movimiento * velocidadMovimiento) * Time.deltaTime);
        }

        AplicarGravedad();
        DeteccionSuelo();

    }
    private void AplicarGravedad()
    {
        movimientoVertical.y += escalaGravedad * Time.deltaTime;
        cc.Move(movimientoVertical * Time.deltaTime);
    }

    private void BarraVidaMaxima()
    {
        slider.maxValue = vidas;
        slider.value = vidas;
    }
    private void BarraVida()
    {
        slider.value = vidas;
    }


    private void DeteccionSuelo()
    {
        Collider[] collsDetectados = Physics.OverlapSphere(pies.position, radioDeteccion, layerSuelo);
        if (collsDetectados.Length > 0)
        {
            movimientoVertical.y = 0;
            Saltar();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawSphere(pies.position, radioDeteccion);
    }
    public void RecibirDanho(float danhoRecibido)
    {
        vidasActual -= danhoRecibido;
        if (vidasActual < 0)
        {
            SceneManager.LoadScene(2);

        }
    }


    private void Saltar()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            movimientoVertical.y = Mathf.Sqrt(-2 * escalaGravedad * alturaSalto);
        }
    }

    private void OnTriggerEnter(Collider other)
    {


        if (other.gameObject.CompareTag("Coleccionable"))
        {
            Debug.Log("hola choco");
            puntuacion += 1;
            textoPuntos.SetText("x" + puntuacion);
            
            Destroy(other.gameObject);
        }

        if (gameObject.CompareTag("Victoria"))
        {
            SceneManager.LoadScene(3);

        }
    }

    
    
          

   
    

}
