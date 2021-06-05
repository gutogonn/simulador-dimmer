using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DimmerUI : MonoBehaviour
{
    [SerializeField] private List<Recipe> recipes;
    private List<string> filaSelecionados;
    private List<Button> filaSelecionadoButtons;

    [Header("Seleção de Fio")]
    [SerializeField] private Button caboAzulButton;
    [SerializeField] private Button caboPretoButton;
    [SerializeField] private Button caboVermelhoButton;
    private string fioSelecionado;

    [Header("Opções")]
    [SerializeField] private Button esquemaButton;
    [SerializeField] private Button refazerButton;

    [Header("Infos")]
    [SerializeField] private List<Transform> infos;

    [Header("Seleção do Borne")]
    [SerializeField] private Button borneOpcao1Button;
    [SerializeField] private Button borneOpcao2Button;
    [SerializeField] private Button borneOpcao3Button;

    [Header("Seleção do Dimmer")]
    [SerializeField] private Button dimmerOpcao1Button;
    [SerializeField] private Button dimmerOpcao2Button;
    [SerializeField] private Button dimmerOpcao3Button;
    [SerializeField] private Button dimmerOpcao4Button;

    [Header("Seleção do Rele")]
    [SerializeField] private Button releOpcaoButton;

    [Header("Seleção do Lampada")]
    [SerializeField] private Button lampOpcao1Button;
    [SerializeField] private Button lampOpcao2Button;

    [Header("Seleção do Interruptor")]
    [SerializeField] private Button interruptorOpcao1Button;
    [SerializeField] private Button interruptorOpcao2Button;

    void Start()
    {
        caboAzulButton.GetComponent<Animator>().Play("Base Layer.COR_SELECIONAR", 0, 0f);
        caboPretoButton.GetComponent<Animator>().Play("Base Layer.COR_ESCONDER", 0, 0f);
        caboVermelhoButton.GetComponent<Animator>().Play("Base Layer.COR_ESCONDER", 0, 0f);

        caboAzulButton.onClick.AddListener(() => SelecionarFio("f1", caboAzulButton));
        caboPretoButton.onClick.AddListener(() => SelecionarFio("f2", caboPretoButton));
        caboVermelhoButton.onClick.AddListener(() => SelecionarFio("f3", caboVermelhoButton));

        borneOpcao1Button.onClick.AddListener(() => AdicionarAfila("b1", borneOpcao1Button));
        borneOpcao2Button.onClick.AddListener(() => AdicionarAfila("b2", borneOpcao2Button));
        borneOpcao3Button.onClick.AddListener(() => AdicionarAfila("b3", borneOpcao3Button));

        dimmerOpcao1Button.onClick.AddListener(() => AdicionarAfila("d1", dimmerOpcao1Button));
        dimmerOpcao2Button.onClick.AddListener(() => AdicionarAfila("d2", dimmerOpcao2Button));
        dimmerOpcao3Button.onClick.AddListener(() => AdicionarAfila("d3", dimmerOpcao3Button));
        dimmerOpcao4Button.onClick.AddListener(() => AdicionarAfila("d4", dimmerOpcao4Button));

        releOpcaoButton.onClick.AddListener(() => AdicionarAfila("r1", releOpcaoButton));

        lampOpcao1Button.onClick.AddListener(() => AdicionarAfila("l1", lampOpcao1Button));
        lampOpcao2Button.onClick.AddListener(() => AdicionarAfila("l2", lampOpcao2Button));

        interruptorOpcao1Button.onClick.AddListener(() => AdicionarAfila("i1", interruptorOpcao1Button));
        interruptorOpcao2Button.onClick.AddListener(() => AdicionarAfila("i2", interruptorOpcao2Button));

        filaSelecionadoButtons = new List<Button>();
        filaSelecionados = new List<string>();

    }

    void LateUpdate()
    {
        ValidarSequencia();
    }

    private void ValidarSequencia()
    {
        if (filaSelecionados.Count < 2) return;

        Recipe recipe = recipes.Find(f => f.fio.Equals(fioSelecionado) && f.mid.Equals(filaSelecionados[0]) && f.end.Equals(filaSelecionados[1]));

        if (recipe != null)
        {
            filaSelecionadoButtons[0].GetComponent<Animator>().Play("Base Layer.BTN_ACERTO", 0, 0f);
            filaSelecionadoButtons[1].GetComponent<Animator>().Play("Base Layer.BTN_ACERTO", 0, 0f);
            recipe.obj.GetComponent<MeshRenderer>().enabled = true;
        }
        else
        {
            filaSelecionadoButtons[0].GetComponent<Animator>().Play("Base Layer.BTN_ERRO", 0, 0f);
            filaSelecionadoButtons[1].GetComponent<Animator>().Play("Base Layer.BTN_ERRO", 0, 0f);
        }

        filaSelecionados = new List<string>();
        filaSelecionadoButtons = new List<Button>();
    }

    private void SelecionarFio(string valor, Button button)
    {
        fioSelecionado = valor;
        if (!caboAzulButton.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("COR_ESCONDER")) caboAzulButton.GetComponent<Animator>().Play("Base Layer.COR_ESCONDER", 0, 0f);
        if (!caboPretoButton.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("COR_ESCONDER")) caboPretoButton.GetComponent<Animator>().Play("Base Layer.COR_ESCONDER", 0, 0f);
        if (!caboVermelhoButton.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("COR_ESCONDER")) caboVermelhoButton.GetComponent<Animator>().Play("Base Layer.COR_ESCONDER", 0, 0f);

        button.GetComponent<Animator>().Play("Base Layer.COR_SELECIONAR", 0, 0f);
    }
    private void AdicionarAfila(string valor, Button button)
    {
        filaSelecionados.Add(valor);
        filaSelecionadoButtons.Add(button);
    }
}
