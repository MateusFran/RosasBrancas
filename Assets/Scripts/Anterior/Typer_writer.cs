using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class Typer_writer : MonoBehaviour {

	public string texto_txt, texto_mostrar, personagem_mostrar, texto_nomepersonagem;
	public char[] letras_texto;
	public Text texto_hud, nomepersonagem_hud, space_hud;
	public GameObject hudDialogo;
	public float delay;
	public bool nomepersonagem = true, pulardelay = false, controle_space = false, acabouFala = true;

	void Update(){
		
		if (Input.GetKeyDown(KeyCode.Space)) {
			if(controle_space){
				pulardelay = true;
			}
		}
		
	}//fimUpdate

	public void digitando(string nomeArquivo){
		//ler arquivo .txt
		Debug.Log("Entrou no typer...");
		texto_txt = File.ReadAllText (nomeArquivo);
		texto_hud.text = "";
		StartCoroutine (typerwrite());
	}

	IEnumerator typerwrite(){
		letras_texto = texto_txt.ToCharArray ();
		//Debug.Log ("Não entendi");
		for (int l = 0; l < letras_texto.Length; l++) {
			
			acabouFala = false;

			//if para verificar o nome do personagem;
			if(letras_texto[l] == '/'){
				nomepersonagem = false;
				letras_texto[l] = ' ';
			}

			if (letras_texto [l] == '@') {
				yield return new WaitForSeconds (0.05f);
				nomepersonagem = true;
				letras_texto[l] = ' ';
				controle_space = false;

				//while do apertar espaço...
				while (Input.GetKeyDown (KeyCode.Space) == false) {
					yield return new WaitForSeconds (0.01f);
					space_hud.text = "Aperte Espaço...";
				}

				space_hud.text = "";
				texto_mostrar = "";
			}
			//if do nome do personagem;
			if (nomepersonagem == true) {
				pulardelay = false;
				controle_space = false;
				if (letras_texto [l] == '-') {
					personagem_mostrar = "";
					letras_texto[l] = ' ';
				}
				personagem_mostrar += letras_texto [l];
				nomepersonagem_hud.text = personagem_mostrar;
			} 

			//if do texto;
			else if (nomepersonagem == false && pulardelay == false) {
				if (letras_texto [l] != ' ') {
					yield return new WaitForSeconds (delay);
				}
				texto_mostrar += letras_texto [l];
				texto_hud.text = texto_mostrar;
				texto_mostrar.Replace("\r\n", "");
				controle_space = true;
			} 

			//if do pular o delay;
			else if (nomepersonagem == false && pulardelay == true) {
				controle_space = false;
				texto_mostrar += letras_texto [l];
				texto_hud.text = texto_mostrar;
				texto_mostrar.Replace("\r\n", "");
			}
				
		}//fimFor;
		acabouFala = true;
		texto_hud.text = "";
		nomepersonagem_hud.text = "";
		hudDialogo.SetActive (false);

		PlayerPrefs.SetInt ("objetoDialogo", 1);
		PlayerPrefs.SetInt ("rodarParte", 1);
	}//fimtyperwrite;

}
