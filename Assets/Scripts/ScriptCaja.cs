using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptCaja : MonoBehaviour
{
     [SerializeField] Animator anim;
    
    // Start is called before the first frame update
    void Start()
    {
        anim.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Abrir()
    {
        anim.SetBool("caja_abrir", true);
    }
}
