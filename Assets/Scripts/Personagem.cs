using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BasePersonagem {

    [SerializeField] public GameObject objeto;
    [SerializeField] public Rigidbody2D rb;
    [SerializeField] public Animator animator;
}
public class Personagem : MonoBehaviour {

    //Personagens;
    [SerializeField] BasePersonagem pai = new BasePersonagem();
    [SerializeField] BasePersonagem mae = new BasePersonagem();

    [SerializeField] private Capitulo_1 capitulo1;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float velocidade;
    [SerializeField] private float tempo;
    private bool podeMover;
    private float direcao;

    private bool verificarEvento;
	// Use this for initialization
	void Start () {
        
        podeMover = false;
        verificarEvento = false;

        //SetActives;
        pai.objeto.SetActive(false);
        mae.objeto.SetActive(false);

	}
    void Update()
    {
        Cronometro();

        //Animators;
        if(pai.objeto.activeSelf){
            pai.animator.SetFloat("velocidade", velocidade);
        }
    }
    void FixedUpdate() {
        Movimentacao();
    }
    public void Chamar(string nome, float posX, float posY)
    {
        if (nome == "Pai")
        {
            pai.objeto.SetActive(true);
            SetarPosicao(pai.objeto, posX, posY);
        }
        else if(nome == "Mãe")
        {
            mae.objeto.SetActive(true);
            SetarPosicao(mae.objeto, posX, posY);
        }
        else
        {
            print("Nome do personagem não corresponde...");
        }
    }
    private void Movimentacao(){
        if(podeMover){
            rb.velocity = new Vector2(direcao * velocidade, rb.velocity.y);
            print("Movendo");
        }
    }
    public void Mover(string nome, float velocidade, bool direcao, float tempo){
        
        this.tempo = tempo;
        this.velocidade = velocidade;
        //Direcao;
        if(direcao){
            this.direcao = 1;
        }
        else{
            this.direcao = -1;
        }

        //Quem deve mexer;
        if(nome == "Pai"){
            rb = pai.rb;    
        }
        else if(nome == "Mãe"){
            rb = mae.rb;
        }
        else{
            print("Nenhum RB selecionado...");
        }

        verificarEvento = true;
    }
    private void Cronometro(){
        if (tempo > 0)
        {
            tempo -= Time.deltaTime;
            podeMover = true;
        }
        else if(tempo <= 0){
            podeMover = false;
            velocidade = 0;
            
            rb.velocity = new Vector2(0f, rb.velocity.y);

            if(verificarEvento){
                capitulo1.RodarParte = true;
                capitulo1.RodarEvento = true;

                verificarEvento = false;
            }
        }
        else{
            print("Erro...");
        }
    }
    private void SetarPosicao(GameObject objeto, float posX, float posY)
    {
        Vector3 posicaoCena = objeto.transform.position;
        posicaoCena.x = posX;
        posicaoCena.y = posY;
        objeto.transform.position = posicaoCena;
    }
}
