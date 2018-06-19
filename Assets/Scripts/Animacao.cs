using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animacao : MonoBehaviour {

    [SerializeField] private GameObject objeto;
    [SerializeField] private Animator animator;

    public void FadeIn()
    {
        animator.SetTrigger("fadeIn");
    }
    public void FadeOut()
    {
        animator.SetTrigger("fadeOut");
    }
}
