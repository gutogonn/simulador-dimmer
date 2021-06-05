using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OpcoesUI : MonoBehaviour
{
    [SerializeField] private Button esquemaButton;
    [SerializeField] private Button refazerButton;
    [SerializeField] private Button confirmaButton;

    [Header("Janelas")]
    [SerializeField] private Transform esquemaJanela;
    [SerializeField] private Transform confirmaRefazerJanela;

    // Start is called before the first frame update
    void Start()
    {
        esquemaButton.onClick.AddListener(() => MostrarJanela(esquemaJanela));
        refazerButton.onClick.AddListener(() => MostrarJanela(confirmaRefazerJanela));
        confirmaButton.onClick.AddListener(() => Recarregar());
    }

    public void MostrarJanela(Transform janela)
    {
        janela.GetComponent<CanvasGroup>().alpha = 1;
        janela.GetComponent<CanvasGroup>().interactable = true;
        janela.GetComponent<CanvasGroup>().blocksRaycasts = true;
    }
    public void EsconderJanela(Transform janela)
    {
        janela.GetComponent<CanvasGroup>().alpha = 0;
        janela.GetComponent<CanvasGroup>().interactable = false;
        janela.GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    private void Recarregar() => SceneManager.LoadScene("Fase1");

}
