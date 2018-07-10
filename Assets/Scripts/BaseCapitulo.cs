using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCapitulo : MonoBehaviour {

    #region Variáveis Gerais

    public bool RodarCapitulo{ get; set;}
    public int Capitulo{ get; set;}

    //Player;
    public Player player;
    public GameObject objeto_Player;
    
    //Personagens;
    public Personagem personagem;

    //Códigos de diálogo;
    public Datilografia datilografia;
    public InicioDatilografia inicioDatilografia;
    public ObjetoDatilografia objetoDatilografia;

    public Timer script_Timer;
    public Choices script_Escolha;

    //Animações;
    public Animator telaPreta;

    //cenários;
    public GameObject bedroom;
    public GameObject redroom;

    //ativar/desabilitar objetos do hud;
    public GameObject hud_Dialogo;
    public GameObject hud_DialogoInicial;
    public GameObject hud_Tutorial;
    public GameObject hud_Escolhas;
    public GameObject hud_TelaPreta;
    public GameObject hud_Tempo;

    #endregion

    #region Variáveis Privadas
    //Capítulos;
    [SerializeField] private Capitulo_1 capitulo1;

    //Numero do capitulo;
    [SerializeField] private int capitulo;

    #endregion

    private void Start () {

        Capitulo = capitulo;
        RodarCapitulo = true;

	}
	
	private void Update () {
        if(RodarCapitulo && Capitulo == 1){
            capitulo1.comecar();
        }
        else{
            //print("Nenhum Capitulo Rodou");
        }
        RodarCapitulo = false;
	}

    #region Funções Importantes

    public void MudarCenario(string nomeCenario)
    {
        //hudTelaPreta.SetActive(true);

        if (nomeCenario == "Bedroom")
        {
            bedroom.SetActive(true);
            redroom.SetActive(false);
        }
        else if (nomeCenario == "Redroom")
        {
            bedroom.SetActive(false);
            redroom.SetActive(true);
        }
    }
    public void SetarPosicao(GameObject objeto, float posX, float posY)
    {
        Vector3 posicaoCena = objeto.transform.position;
        posicaoCena.x = posX;
        posicaoCena.y = posY;
        objeto.transform.position = posicaoCena;
    }

    public void InicioDatilografia(string arquivo)
    {
        hud_DialogoInicial.SetActive(true);
        inicioDatilografia.Digitando("Dialogo\\Capitulo1\\" + arquivo + ".txt");
    }
    public void Datilografia(string arquivo)
    {
        hud_Dialogo.SetActive(true);
        datilografia.Digitando("Dialogo\\Capitulo1\\" + arquivo + ".txt");
    }
    #endregion
}
