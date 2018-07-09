using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class InicioDatilografia : MonoBehaviour {
	
	//variaveis importantes;
	private string texto;
	private char[] letras;
	private string[] falas;

	public GameObject hud;

	public Text texto_hud, 
				nomepersonagem_hud, 
				space_hud;

	public float delay;

	public bool nomepersonagem = true, 
				pulardelay = false, 
	            controle_space = false, 
				acabouFala = true;

    public Capitulo_1 capitulo1;

	void Start()
	{

	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.Space)) {
			if (controle_space) {
				pulardelay = true;
			}
		}
	}
	public void Digitando(string nomeArquivo){
        //ler arquivo .txt
        string filePath = Path.Combine(Application.streamingAssetsPath, nomeArquivo);
        texto = File.ReadAllText(filePath);
        texto.Replace ("\r\n", "");

		texto_hud.text = "";

		//começar rotina;
		StartCoroutine (Typerwrite());
	}


	IEnumerator Typerwrite(){

		falas = texto.Split ('@'); 

		acabouFala = false;

		texto_hud.text = "";

		for (int l = 0; l < falas.Length; l++) {

			letras = falas [l].ToCharArray();

			for (int i = 0; i < letras.Length; i++) {
				controle_space = true;
				if (letras [i] == '\n') {
					letras[i] = ' ';
				}
				texto_hud.text += letras [i];

				if (pulardelay != true) {
					yield return new WaitForSeconds (delay);	
				}
			}
			yield return new WaitForSeconds (0.1f);

			while (Input.GetKeyDown (KeyCode.Space) == false) {
				controle_space = false;
				yield return new WaitForSeconds (0.005f);
				space_hud.text = "Aperte Espaço";
			}

			texto_hud.text = "";
			space_hud.text = "";
			pulardelay = false;

		}

		PlayerPrefs.SetInt ("objetoDialogo", 1);

        capitulo1.RodarEvento = true;
		capitulo1.RodarParte = true;

		hud.SetActive (false);
		acabouFala = true;
	}
}
