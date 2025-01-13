using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class EfectoAgua : MonoBehaviour
{
    [SerializeField] private float velocidad;
    private Volume efecto;

    private void Start()
    {
        efecto= GetComponent<Volume>();
    }

    private void Update()
    {
        if(efecto.profile.TryGet(out LensDistortion distortion))
        {
            FloatParameter xValue = new FloatParameter(1 + Mathf.Cos(velocidad * Time.time) / 2);
            FloatParameter yValue = new FloatParameter(1 + Mathf.Cos(velocidad * Time.time) / 2);
            distortion.xMultiplier.SetValue(xValue);
            distortion.yMultiplier.SetValue(yValue);
        }
    }
}
