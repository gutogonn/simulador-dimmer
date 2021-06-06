using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class AvaliacaoUI : MonoBehaviour
{
    private IAvaliacaoController avaliacaoController;
    [SerializeField] private Button abrirAvaliacaoButton;
    [SerializeField] private Button avaliarButton;
    [SerializeField] private TMP_InputField digiteNomeInput;
    [SerializeField] private Transform janela;
    void Start()
    {
        avaliacaoController = new AvaliacaoControllerImpl();
        abrirAvaliacaoButton.onClick.AddListener(() => MostrarJanela(janela));
        avaliarButton.onClick.AddListener(() => Avaliar());
    }

    private void Avaliar()
    {
        avaliacaoController.Salvar(AvaliacaoData.Instance().FinalizarAvaliacao(digiteNomeInput.text));
        SceneManager.LoadScene("Fase1");
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

}
