using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personagem : MonoBehaviour {

    public GameObject mae,
                      pai;

	// Use this for initialization
	void Start () {

        //SetActives;
        mae.SetActive(false);
        pai.SetActive(false);

	}
    public void Chamar(string nome, float posX, float posY)
    {
        if (nome == "Pai")
        {
            pai.SetActive(true);
            SetarPosicao(pai, posX, posY);
        }
        else if(nome == "Mãe")
        {
            mae.SetActive(true);
            SetarPosicao(mae, posX, posY);
        }
        else
        {
            print("Nome do personagem não corresponde...");
        }
    }
    private void SetarPosicao(GameObject objeto, float posX, float posY)
    {
        Vector3 posicaoCena = objeto.transform.position;
        posicaoCena.x = posX;
        posicaoCena.y = posY;
        objeto.transform.position = posicaoCena;
    }
	// Update is called once per frame
	void Update () {
		
	}
}
