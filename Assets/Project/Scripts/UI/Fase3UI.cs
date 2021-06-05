using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fase3UI : MonoBehaviour
{
    [SerializeField] private Animator menuLateralAnim;

    [SerializeField] private Transform globalLight;
    void Start()
    {
        menuLateralAnim.Play("Base Layer.MENU_MOSTRAR", 0, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        globalLight.GetComponent<Light>().intensity -= 0.5f * Time.deltaTime;
    }
}
