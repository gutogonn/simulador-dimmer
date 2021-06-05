using UnityEngine;

[System.Serializable]
public class Recipe
{
    public string fio;
    public string mid;
    public string end;

    public Recipe(string _fio, string _mid, string _end)
    {
        this.fio = _fio;
        this.mid = _mid;
        this.end = _end;
    }
}