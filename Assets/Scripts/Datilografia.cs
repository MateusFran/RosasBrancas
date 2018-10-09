using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityStandardAssets.CrossPlatformInput;

public class Datilografia : MonoBehaviour {

	//variaveis importantes;
	private string texto; 
	private char[] letras;
	private string[] falas;
	public Text texto_hud, 
				nomepersonagem_hud, 
				space_hud;

	[SerializeField]
	private float delay;
	public GameObject hud;
	public Image imagem_Personagem;
	public Image imagem_Dialogo;
	public bool nomepersonagem = true, 
				pulardelay = false, 
				controle_space = false, 
				acabouFala;

    //outros Scripsts;
    public Player player;

	//capitulos;
    public Capitulo_1 capitulo1;

	void Start(){

	}

	void Update () {

		if (Input.GetKeyDown(KeyCode.Space)) {
			if (controle_space) {
				pulardelay = true;
			}
		}
		switch(capitulo1.cenarioAtual){
			case "Bedroom":
				imagem_Dialogo.color = new Vector4(0.1041296f, 0.1047862f, 0.3396226f, 1f);
				imagem_Personagem.color = new Vector4(0.1041296f, 0.1047862f, 0.3396226f, 1f);
				break;

			case "Redroom":
				imagem_Dialogo.color = new Vector4(0.3679245f, 0.116278f, 0.116278f, 1f);
				imagem_Personagem.color = new Vector4(0.3679245f, 0.116278f, 0.116278f, 1f);
				break;

			case "School":
				imagem_Dialogo.color = new Vector4(0.6313726f, 0.6313726f, 0.6313726f, 1f);
				imagem_Personagem.color = new Vector4(0.6313726f, 0.6313726f, 0.6313726f, 1f);
				break;

			default:
			//Sem Cenário
				break;
		}
	}

    public void Digitando(string nomeArquivo){
        //ler arquivo .txt
        string filePath = Path.Combine(Application.streamingAssetsPath, nomeArquivo);
        texto = File.ReadAllText (filePath);

		texto_hud.text = "";

		//começar rotina;
		StartCoroutine (Typerwrite());
	}


	private IEnumerator Typerwrite(){

		texto.Replace ("\r\n", "");
		falas = texto.Split ('@');

		acabouFala = false;
        player.podeApertarE = false;

		for (int l = 0; l < falas.Length; l++) {

			string[] subFala = falas [l].Split ('/');
			string nome = subFala [0].Replace ("\r\n", "");
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
		hud.SetActive (false);
		PlayerPrefs.SetInt ("objetoDialogo", 1);

        //capitulos;
        capitulo1.RodarEvento = true;
		capitulo1.RodarParte = true;

        player.podeApertarE = true;
		acabouFala = true;
		letras = texto.ToCharArray ();
	}
}//fimTyperwriter;