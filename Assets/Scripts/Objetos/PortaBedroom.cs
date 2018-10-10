using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortaBedroom : ClasseObjeto {
	
	void Start() {
		player = Singleton.GetInstance.player;
	}

	void OnTriggerStay2D(Collider2D other) {
		if(other.gameObject.tag == "Player"){
			if(player.apertarTeclaE && player.vasculhando){
				if((vez == 0 || vez == 1) && cenaObjetos == 0 && PlayerPrefs.GetInt("chave") == 1){
					hudDialogo.SetActive(true);

					objetoDatilografia.Digitando("Dialogo\\Objetos\\PortaBedroom\\1_VezChave.txt");
					vez++;

					capitulo1.Evento = 4;

					PlayerPrefs.SetInt("chave", 0);
				}
				else if(vez == 0 && cenaObjetos == 0 && PlayerPrefs.GetInt("chave") == 0){
					hudDialogo.SetActive(true);
					objetoDatilografia.Digitando("Dialogo\\Objetos\\PortaBedroom\\1_Vez.txt");
					vez++;
				}
				else{
					hudDialogo.SetActive(true);
					objetoDatilografia.Digitando("Dialogo\\Objetos\\Vasculhou.txt");
				}
				player.podeApertarE = false;
			}
		}//fim verificação da tecla;	
	}
}
