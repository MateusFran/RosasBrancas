using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class ObjetoDatilografia : MonoBehaviour {

    //variaveis importantes;
    private string texto;

	private char[] letras;
	private string[] falas;


	public Text texto_hud, 
				nomepersonagem_hud, 
				space_hud;

	public float delay;

    public bool nomepersonagem = true,
                pulardelay = false,
                controle_space = false,
                acabouFala;

	//outros objetos
	public GameObject hud;

	public Player scriptPlayer;
    public Capitulo_1 capitulo1;

	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.Space)) {
			if (controle_space) {
				pulardelay = true;
			}
		}
	}
	public void Digitando(string nomeArquivo){

        //valor inicial;

        //ler arquivo .txt
        string filePath = Path.Combine(Application.streamingAssetsPath, nomeArquivo);
        texto = File.ReadAllText(filePath);
        texto_hud.text = "";

		//começar rotina;
		StartCoroutine (Typerwrite());
	}


	IEnumerator Typerwrite(){

		texto.Replace ("\r\n", " ");
		falas = texto.Split ('@'); 

		acabouFala = false;
		scriptPlayer.podeApertarE = false;

		for (int l = 0; l < falas.Length; l++) {


			string[] subFala = falas [l].Split ('/');
            string nome = subFala[0].Replace("\r\n", "");
            nomepersonagem_hud.text = nome;

			letras = subFala [1].ToCharArray();

			for (int i = 0; i < letras.Length; i++) {
				controle_space = true;
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
			nomepersonagem_hud.text = "";
			space_hud.text = "";
			pulardelay = false;

		}

		PlayerPrefs.SetInt ("objetoDialogo", 1);
        capitulo1.RodarEvento = true;

		hud.SetActive (false);
		acabouFala = true;

		scriptPlayer.podeApertarE = true;
	}
}
