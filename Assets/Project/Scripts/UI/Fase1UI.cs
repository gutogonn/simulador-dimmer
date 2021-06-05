using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Fase1UI : MonoBehaviour
{
    [SerializeField] private Animator menuLateralAnim;
    [SerializeField] private List<Recipe> recipes;
    protected List<string> filaSelecionados;
    protected List<Button> filaSelecionadoButtons;

    [Header("Seleção de Fio")]
    [SerializeField] private Button caboAzulButton;
    [SerializeField] private Button caboPretoButton;
    [SerializeField] private Button caboVermelhoButton;
    protected string fioSelecionado;

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

    [Header("Telas")]
    [SerializeField] private Transform informacoesTela;
    [SerializeField] private Button fecharInformacoes;
    [SerializeField] private Transform menuOpcoes;

    private void Start()
    {
        menuLateralAnim.Play("Base Layer.MENU_MOSTRAR", 0, 0f);

        fecharInformacoes.onClick.AddListener(() => FecharTelaInformacoes());

        fioSelecionado = "f1";
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

    private void LateUpdate()
    {
        ValidarSequencia();
        VerificarAtivos();
    }

    private void ValidarSequencia()
    {
        if (filaSelecionados.Count < 2) return;

        Recipe recipe = recipes.Find(f => f.fio.Equals(fioSelecionado) && (f.mid.Equals(filaSelecionados[0]) && f.end.Equals(filaSelecionados[1]) || f.mid.Equals(filaSelecionados[1]) && f.end.Equals(filaSelecionados[0])));

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

    private void VerificarAtivos()
    {
        bool proximoNivel = true;
        foreach (Transform t in menuOpcoes)
        {
            if (t.GetComponent<CanvasGroup>().interactable) proximoNivel = false;
        }

        if (proximoNivel && !menuLateralAnim.GetCurrentAnimatorStateInfo(0).IsName("MENU_ESCONDER"))
        {
            menuLateralAnim.Play("Base Layer.MENU_ESCONDER", 0, 0f);
        }

        if (proximoNivel && AnimationTime.TempoAnimacaoAtual(menuLateralAnim) > 0.9f) SceneManager.LoadScene("Fase2");
    }

    private void FecharTelaInformacoes() => Destroy(informacoesTela.gameObject);
}
