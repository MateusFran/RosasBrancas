using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Choices : MonoBehaviour {

    [SerializeField] private RectTransform butaoEsquerda;
    [SerializeField] private RectTransform butaoDireita;
    [SerializeField] private Text textoButaoEsquerda;
    [SerializeField] private Text textoButaoDireita;
    [SerializeField] private GameObject hud;

    [SerializeField] private GameObject hud_TelaPreta;

    //Capítulos:
    [SerializeField] private Capitulo_1 capitulo1;
    [SerializeField] private SaveData saveData;
    public void SetarEscolhas(string escolhaEsquerda, string escolhaDireita)
    {
        hud_TelaPreta.SetActive(false);
        textoButaoEsquerda.text = escolhaEsquerda;
        textoButaoDireita.text = escolhaDireita;
    }
    public void SetarEscolhas(string escolhaEsquerda, int fonteEsquerda, string escolhaDireita, int fontDireita, float tamEsquerdaW, float tamEsquerdaH, float tamDireitaW, float tamDireitaH)
    {
        hud_TelaPreta.SetActive(false);

        textoButaoEsquerda.text = escolhaEsquerda;
        textoButaoDireita.text = escolhaDireita;

        textoButaoEsquerda.fontSize = fonteEsquerda;
        textoButaoDireita.fontSize = fontDireita;
        
        //Lembrar de setar tamanho do botão tambem;
        butaoDireita.sizeDelta = new Vector2(tamDireitaW, tamDireitaH);
        butaoEsquerda.sizeDelta = new Vector2(tamEsquerdaW, tamEsquerdaH);
    }

	public void EscolhaEsquerda(){

		PlayerPrefs.SetInt ("escolha", 1);

        hud.SetActive(false);
        hud_TelaPreta.SetActive(true);

        saveData.SalvarEscolhas();

        capitulo1.RodarEvento = true;
        capitulo1.RodarParte = true;
	}
	public void EscolhaDireita(){
	
		PlayerPrefs.SetInt ("escolha", 2);

        hud.SetActive(false);
        hud_TelaPreta.SetActive(true);

        saveData.SalvarEscolhas();

        capitulo1.RodarEvento = true;
        capitulo1.RodarParte = true;
    }
}
