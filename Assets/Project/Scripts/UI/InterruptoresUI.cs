using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InterruptoresUI : MonoBehaviour
{
    [SerializeField] private Animator menuLateralAnim;

    [SerializeField] private Animator interruptorAnim;
    public int releAtivos;

    void Start()
    {
        menuLateralAnim.Play("Base Layer.MENU_MOSTRAR", 0, 0f);
    }
    void LateUpdate()
    {
        RaycastHit hitInfo = new RaycastHit();
        bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);

        if (hit && Input.GetButton("Fire1"))
        {
            if (hitInfo.transform.gameObject.name.Contains("Rele"))
            {
                hitInfo.transform.GetComponent<Animator>().Play("Base Layer.RELE_ATIVAR", 0, 0f);
                hitInfo.transform.gameObject.name = "Ativo";
                releAtivos++;
            }
        }

        if (releAtivos < 2) return;

        if (!menuLateralAnim.GetCurrentAnimatorStateInfo(0).IsName("MENU_ESCONDER")) menuLateralAnim.Play("Base Layer.MENU_ESCONDER", 0, 0f);

        if (releAtivos >= 2 && AnimationTime.TempoAnimacaoAtual(menuLateralAnim) > 0.9f) SceneManager.LoadScene("Fase3");
    }
}
