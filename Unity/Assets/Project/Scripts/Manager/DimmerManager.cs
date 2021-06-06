using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DimmerManager : MonoBehaviour
{
    [SerializeField] private List<Transform> fases;

    private static DimmerManager instance = null;
    public static DimmerManager Instance() { return instance; }
    private void Awake() => instance = this;

    public void SelecionarFase(int valor)
    {
        foreach (Transform t in fases)
        {
            t.gameObject.SetActive(false);
        }
        fases[valor].gameObject.SetActive(true);
    }
}
