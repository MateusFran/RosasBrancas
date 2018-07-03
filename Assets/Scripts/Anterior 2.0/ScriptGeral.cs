using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScriptGeral : MonoBehaviour {

	//Variaveis:
	public int escolhaAtual;
	public bool continueRoteiro, rodarParte = true;
	public int capitulo, parte;

	//pegar componentes de outros códigos;
	public Datilografia datilografia;
	public InicioDatilografia inicioDatilografia;
	public ObjetoDatilografia objetoDatilografia;

    //Outros Scripts;
    public Timer timer;
	public Player player;
    public CutScenes cutScene;
    public Choices escolha;

	public Animator telaPreta;

	//ativar/desabilitar objetos do hud;
	public GameObject hudDialogo;
	public GameObject hudDialogoInicial;
	public GameObject hudTutorial;
	public GameObject hudEscolhas;
	public GameObject hudTelaPreta;
    public GameObject hudTempo;

    public GameObject hudFinal;

    public GameObject objetoPlayer;

    //cenários;
    public GameObject bedroom;
    public GameObject redroom;

    private GameObject objetoDelay;
    //Testes;

    /*
	void Start () {

        //valores inicais de variaveis;

        #region PlayerPrefs

        PlayerPrefs.SetInt("rodarParte", 1);
        PlayerPrefs.SetInt("escolha", 0);
        PlayerPrefs.SetInt("rodarCap1Part5", 0);
        #endregion


        //Desabilitando objetos canvas;
        hudEscolhas.SetActive (false);
		hudDialogo.SetActive(false);

		hudDialogoInicial.SetActive (true);
		player.PararPlayer ();


	}//fim start;
    */

	void Update () {

        escolhaAtual = PlayerPrefs.GetInt("escolha");

        //verifica qual capítulo rodar;
        RodarCapituloParte();


        //Verificação de capítulos específicos;
        VerificarCap1Part5();
	}
    private void RodarCapituloParte()
    {
        if (PlayerPrefs.GetInt("rodarParte") == 1)
        {

            if (capitulo == 1 && parte == 1)
            {
                Cap1part1();
            }
            else if (capitulo == 1 && parte == 2)
            {
                Cap1part2();
            }
            else if (capitulo == 1 && parte == 3)
            {
                Cap1part3();
            }
            else if (capitulo == 1 && parte == 4)
            {
                Cap1part4();
            }

            else if (capitulo == 1 && parte == 5)
            {
                if (PlayerPrefs.GetInt("rodarCap1Part5") == 1 && objetoDatilografia.acabouFala)
                {
                    player.PararPlayer();
                    hudDialogo.SetActive(true);
                    Cap1part5();

                    hudTempo.SetActive(true);
                    //timer.ComecarTempo(15f);

                    player.cenaObjetos = 1;
                    
                    PlayerPrefs.SetInt("rodarCap1Part5", 0);
                }
                
            }
            else if (capitulo == 1 && parte == 6)
            {
                bool jaRodou6 = false;
                if (objetoDatilografia.acabouFala && !jaRodou6)
                {
                    //timer.PararTempo();
                    cutScene.rodarCena(1, 6);
                    Cap1part6();
                    jaRodou6 = true;
                }
            }
            else if (capitulo == 1 && parte == 7)
            {
                hudTelaPreta.SetActive(false);
                hudEscolhas.SetActive(true);
                escolha.SetarEscolhas("Sair", "Não sair");
                parte++;
            }
            else if (capitulo == 1 && parte == 8 && escolhaAtual == 1)
            {
                hudDialogo.SetActive(true);
                cutScene.rodarCena(1, 8);
            }
            else if (capitulo == 1 && parte == 8 && escolhaAtual == 2)
            {
                hudDialogo.SetActive(true);

                hudTelaPreta.SetActive(true);
                hudEscolhas.SetActive(false);
                datilografia.Digitando("Dialogo\\Cap1_pt8_Esc2.txt");
            }
            else
            {
                Cap2part1();
            }
            PlayerPrefs.SetInt("rodarParte", 0);
        }//fim rodarParte
    }
    #region CAPÍTULOS


    //Capítulos:
    private void Cap1part1(){

		hudTelaPreta.SetActive (true);
        //Datilografia("Cap1.txt");
            //Cap1_pt1.txt");
		parte++;

	}//fim Cap1_part1;

	private void Cap1part2(){
        cutScene.rodarCena(1, 2); 
    }//fim Cap1_part2;

	private void Cap1part3(){
        MudarCenario("Bedroom");

		Tutorial ();
		Invoke ("Tutorial", 3.0f);
        parte++;
    }
    private void Cap1part4()
    {
        //configurações do player;
        player.PararPlayer();
        cutScene.rodarCena(1, 4);
        parte++;
    }
    private void Cap1part5()
    {
        datilografia.Digitando("Dialogo\\Cap1_pt5.txt");
    }
    private void Cap1part6()
    {
        telaPreta.SetTrigger("fadeOut");
        hudFinal.SetActive(true);
        cutScene.rodarCena(1, 6);

    }
    private void Cap2part1()
    {

    }

    #endregion

    #region Outras Funções
    private void VerificarCap1Part5()
    {
        if ((capitulo == 1 && parte == 5) && objetoDatilografia.acabouFala)
        {
            PlayerPrefs.SetInt("rodarParte", 1);
            print("rodouParte5...");
        }
    }

    //outras funcões;
    public void Tutorial(){
		if (hudTutorial.activeSelf) {
			hudTutorial.SetActive (false);
		} else {
			hudTutorial.SetActive (true);
		}
	}

    //troca de cenários;
    public void MudarCenario(string nomeCenario) {

        //hudTelaPreta.SetActive(true);

        if (nomeCenario == "Bedroom")
        {
            bedroom.SetActive(true);
            redroom.SetActive(false);
        }
        else if (nomeCenario == "Redroom") {
            bedroom.SetActive(false);
            redroom.SetActive(true);
        }
    }
    #endregion

}
