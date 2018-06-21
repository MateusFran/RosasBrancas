using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Choices : MonoBehaviour {

    [SerializeField] private Button butaoEsquerda;
    [SerializeField] private Button butaoDireita;

    [SerializeField] private Text textoButaoEsquerda;
    [SerializeField] private Text textoButaoDireita;

    [SerializeField] private GameObject hud;

    [SerializeField] private GameObject hudTelaPreta;

    public void SetarEscolhas(string escolhaEsquerda, string escolhaDireita)
    {
        textoButaoEsquerda.text = escolhaEsquerda;
        textoButaoDireita.text = escolhaDireita;
    }
    public void SetarEscolhas(string escolhaEsquerda, string escolhaDireita, float tamEsquerda, float tamDireita)
    {
        textoButaoEsquerda.text = escolhaEsquerda;
        textoButaoDireita.text = escolhaDireita;
    }

	public void EscolhaEsquerda(){

		PlayerPrefs.SetInt ("escolha", 1);
        PlayerPrefs.SetInt("rodarParte", 1);
        hud.SetActive(false);
        hudTelaPreta.SetActive(true);
        print("escolheu SIM");
	}
	public void EscolhaDireita(){
	
		PlayerPrefs.SetInt ("escolha", 2);
        PlayerPrefs.SetInt("rodarParte", 1);
        hud.SetActive(false);
        hudTelaPreta.SetActive(true);
        print("escolheu NÃO");
    }
}
