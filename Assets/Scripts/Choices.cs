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

    [SerializeField] private GameObject hud_TelaPreta;

    //Capítulos:
    [SerializeField] private Capitulo_1 capitulo1;
    public void SetarEscolhas(string escolhaEsquerda, string escolhaDireita)
    {
        hud_TelaPreta.SetActive(false);
        textoButaoEsquerda.text = escolhaEsquerda;
        textoButaoDireita.text = escolhaDireita;
    }
    public void SetarEscolhas(string escolhaEsquerda, string escolhaDireita, float tamEsquerda, float tamDireita)
    {
        hud_TelaPreta.SetActive(false);

        textoButaoEsquerda.text = escolhaEsquerda;
        textoButaoDireita.text = escolhaDireita;
        
        //Lembrar de setar tamanho do botão tambem;
    }

	public void EscolhaEsquerda(){

		PlayerPrefs.SetInt ("escolha", 1);

        hud.SetActive(false);
        hud_TelaPreta.SetActive(true);
        print("Escolheu SIM");

        capitulo1.RodarEvento = true;
	}
	public void EscolhaDireita(){
	
		PlayerPrefs.SetInt ("escolha", 2);

        hud.SetActive(false);
        hud_TelaPreta.SetActive(true);
        print("Escolheu NÃO");

        capitulo1.RodarEvento = true;
    }
}
