using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvaliacaoData : MonoBehaviour
{
    [SerializeField] private Avaliacao avaliacao;
    private float tempoAvaliacao;

    private static AvaliacaoData instance = null;
    public static AvaliacaoData Instance() { return instance; }
    void Awake() => instance = this;

    private void Start()
    {
        avaliacao = new Avaliacao();
    }

    private void Update()
    {
        tempoAvaliacao += 1 * Time.deltaTime;
    }

    public void AdicionarErro()
    {
        avaliacao.erros++;
    }

    public Avaliacao FinalizarAvaliacao(string nome)
    {
        avaliacao.nome = nome;
        avaliacao.tempo = tempoAvaliacao;
        return avaliacao;
    }

    public void SetNome(string nome)
    {
        avaliacao.nome = nome;
    }

    public Avaliacao GetAvaliacao()
    {
        return avaliacao;
    }

    public void ResetarAvaliacao()
    {
        avaliacao = new Avaliacao();
        tempoAvaliacao = 0;
    }
}
