using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutScenes : MonoBehaviour {

    //boleanos;
    public bool acabouCena;

    public Player player;
    public GameObject objetoPlayer;

    public ScriptGeral scriptGeral;

    public Animator telaPreta;

    //pegar componentes de outros códigos;
    public Datilografia datilografia;
    public InicioDatilografia inicioDatilografia;
    public ObjetoDatilografia objetoDatilografia;

    public Personagem personagem;

    //ativar/desabilitar objetos do hud;
    public GameObject hudDialogo;
    public GameObject hudDialogoInicial;
    public GameObject hudTutorial;
    public GameObject hudEscolhas;
    public GameObject hudTelaPreta;

    void Start () {
	}
    public void rodarCena(int capitulo, int parte)
    {
        if (capitulo == 1 && parte == 2)
        {
            StartCoroutine("Cap1_cena2");
        }
        else if (capitulo == 1 && parte == 4)
        {
            StartCoroutine("Cap1_cena4");
        }
        else if (capitulo == 1 && parte == 6)
        {
            StartCoroutine("Cap1_cena6");
        }
    }

    private IEnumerator Cap1_cena2 ()
    {
        scriptGeral.MudarCenario("Bedroom");

        yield return new WaitForSeconds(0.3f);

        telaPreta.SetTrigger("fadeIn");

        Vector3 posicaoInicialCena = player.transform.position;
        posicaoInicialCena.x = -5.78f;
        posicaoInicialCena.y = -1.72f;
        player.transform.position = posicaoInicialCena;

        hudDialogo.SetActive(true);
        telaPreta.SetTrigger("fadeIn");
        datilografia.Digitando("Dialogo\\Cap1_pt2.txt");
        scriptGeral.parte++;
        player.PararPlayer();
    }
    private IEnumerator Cap1_cena4()
    {
        telaPreta.SetTrigger("fadeOut");

        yield return new WaitForSeconds(1f);

        scriptGeral.MudarCenario("Redroom");

        //posicao inical player;
        Vector3 posicaoInicialCena = player.transform.position;
        posicaoInicialCena.x = -6.05f;
        posicaoInicialCena.y = -1.5f;
        player.transform.position = posicaoInicialCena;

        yield return new WaitForSeconds(0.3f);

        hudDialogo.SetActive(true);
        telaPreta.SetTrigger("fadeIn");
        datilografia.Digitando("Dialogo\\Cap1_pt4.txt");
    }
    private IEnumerator Cap1_cena6()
    {

        yield return new WaitForSeconds(1f);
        personagem.Chamar("Pai", -5f, -1.4f);
        objetoPlayer.SetActive(false);
        telaPreta.SetTrigger("fadeIn");

        player.ResetarVezesVaculhouRedroom(2);
        yield return new WaitForSeconds(0.5f);
        hudDialogo.SetActive(true);
        datilografia.Digitando("Dialogo\\Cap1_pt6.txt");
        scriptGeral.parte++;
    }
    private IEnumerator Cap1_cena8()
    {
        yield return new WaitForSeconds(0.5f);
        objetoPlayer.SetActive(true);

        hudTelaPreta.SetActive(true);
        hudEscolhas.SetActive(false);
        datilografia.Digitando("Dialogo\\Cap1_pt8_Esc1.txt");
    }

}
