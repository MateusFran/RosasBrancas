using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personagem : MonoBehaviour {

    public GameObject mae,
                      pai;

    public Rigidbody2D maeRb,
                       paiRb;

    private Rigidbody2D rb;
    [SerializeField] private float velocidade;
    [SerializeField] private int tempo;
    private bool podeMover;
	// Use this for initialization
	void Start () {
        
        podeMover = false;
        velocidade = 0f;

        //SetActives;
        mae.SetActive(false);
        pai.SetActive(false);

	}
    void FixedUpdate() {
        Movimentacao();
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
    private void Movimentacao(){
        if(podeMover){
            rb.velocity = new Vector2(1 * velocidade, rb.velocity.y);
        }
    }
    public void Mover(string nome, bool direcao, float tempo){
        StartCoroutine("Cronometro");
        
        if(nome == "Pai"){
            rb = paiRb;    
        }
        else if(nome == "Mãe"){
            rb = maeRb;
        }
    }
    private IEnumerator Cronometro(){
        podeMover = true;
        float i = 0;
        while(i < tempo){
            yield return new WaitForSeconds(0.1f);
            i += 0.1f;
            print(i);
        }
        podeMover = false;
    }
    private void SetarPosicao(GameObject objeto, float posX, float posY)
    {
        Vector3 posicaoCena = objeto.transform.position;
        posicaoCena.x = posX;
        posicaoCena.y = posY;
        objeto.transform.position = posicaoCena;
    }
}
