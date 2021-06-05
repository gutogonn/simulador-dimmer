using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpcaoUI : MonoBehaviour
{   
    [SerializeField] private Animator animator;
    [SerializeField] private List<Button> buttons;

    void LateUpdate()
    {
       if (buttons.Find(f => f.interactable) == null) return;
       animator.Play("Base Layer.OP_SUMIR", 0, 0f);
    }
}
