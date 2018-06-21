using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour {

	public Rigidbody2D rb;

	[SerializeField]
	private float speed;

    private bool podeRodarParte;

	public float speed_natural;
    public bool mover;
    private bool facingright = true;

    private Animator animacao;

	//variaveis de vez dos objetos;
	public int  armarioVez, 
				portaBedroomVez, 
				tapeteVez, 
				relogioVez;

    public int mesaVez,
               portaRedroomVez,
               cameraVez,
               quadroVez;
                

	//variaveis tecla E;
	public Image imagemTecla;
	public Sprite[] teclaE;

	public bool vasculhando, 
				apertarTeclaE,
				podeApertarE;

    public int cenaObjetos;

	//outros script;
	public Datilografia datilografia;
	public InicioDatilografia inicioDatilografia;
	public ObjetoDatilografia objetoDatilografia;

    public ScriptGeral scriptGeral;

	public Inventory objeto;

	//gameobjects;
	public GameObject hudDialogo;

    void Start()
    {
        #region PlayerPrefs

        PlayerPrefs.SetInt("VasculhouObjetos", 1);

        #endregion
        //configurações iniciais;
        cenaObjetos = 0;
		podeApertarE = true;
        podeRodarParte = false;

        datilografia.acabouFala = true;
        objetoDatilografia.acabouFala = true;
        inicioDatilografia.acabouFala = true;

		//vezes que verificou
		armarioVez = 0;
		portaBedroomVez = 0;
		relogioVez = 0;
		tapeteVez = 0;

		rb = GetComponent<Rigidbody2D> ();
        animacao = GetComponent<Animator>();

		mover = true;
    }

	void Update(){

        //Verifica se vasculhou todos os objetos da cena;
        VerificarObjetosRedroom(1);


        //Métodos;
        VerificarTeclaE();
        VerificarVasculhar();
        VerificarFalaAcabou();
        VerificarRodarProximaParte();
	}

    void FixedUpdate()
    {

		float move = Input.GetAxisRaw ("Horizontal");
		rb.velocity = new Vector2 (move * speed, rb.velocity.y);
		if (mover) {
			animacao.SetFloat ("Andando_Player", Mathf.Abs (move));

			if (move > 0 && !facingright)
				flip ();
			else if (move < 0 && facingright)
				flip ();
		}
    }
    private void VerificarFalaAcabou()
    {
        //verifica se a fala acabou;
        if (!datilografia.acabouFala || !inicioDatilografia.acabouFala || !objetoDatilografia.acabouFala)
        {
            PararPlayer();
        }
        else
        {
            AndarPlayer();
        }
    }


    private void flip()
    {
        facingright = !facingright;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
		transform.localScale = theScale;

		Vector3 teclaScale = imagemTecla.transform.localScale;
		teclaScale.x *= -1;
		imagemTecla.transform.localScale = teclaScale;
    }

    private void VerificarObjetosRedroom(int vez)
    {
        /*objetos:

        * portaRedroom
        * camera
        * quadro
        * mesa
        */

        if ((portaRedroomVez == vez && cameraVez == vez && quadroVez == vez && mesaVez == vez) && PlayerPrefs.GetInt("VasculhouObjetos") == 1)
        {
            PlayerPrefs.SetInt("rodarCap1Part5", 1);
            PlayerPrefs.SetInt("VasculhouObjetos", 0);

            print("Vasculhou...");

            PlayerPrefs.SetInt("rodarParte", 1);
        }
    }

	void OnTriggerStay2D (Collider2D coll){

        #region Objetos Do Bedroom
        //if da tecla E;
        if (coll.gameObject.tag != "Floor")
			vasculhando = true;



		//objetos;
			if (coll.gameObject.tag == "Armario") {
			
				if (apertarTeclaE && vasculhando) {
					
					if (armarioVez == 0 && cenaObjetos == 0) {
						
						hudDialogo.SetActive (true);

						objetoDatilografia.Digitando("Dialogo\\Objetos\\Armario\\1_Vez.txt");
						armarioVez++;

					}
					else {
						hudDialogo.SetActive (true);
						objetoDatilografia.Digitando("Dialogo\\Objetos\\Vasculhou.txt");
					}

				}//fim verificação da tecla;
			}//fim Armario;


			else if(coll.gameObject.tag == "Tapete"){
			
				if (apertarTeclaE == true && vasculhando == true) {

					if (tapeteVez == 0 && cenaObjetos == 0) {

						hudDialogo.SetActive (true);
						
						objetoDatilografia.Digitando("Dialogo\\Objetos\\Tapete\\1_Vez.txt");
						tapeteVez++;
						
						PlayerPrefs.SetInt("chave", 1);

					}
					else {
						
						hudDialogo.SetActive (true);
						objetoDatilografia.Digitando("Dialogo\\Objetos\\Vasculhou.txt");
					}

				}//fim verificação da tecla;
			}//fim Tapete;


		else if(coll.gameObject.tag == "Relogio"){

			if (apertarTeclaE && vasculhando) {

				if (relogioVez == 0 && cenaObjetos == 0) {

					hudDialogo.SetActive (true);

					objetoDatilografia.Digitando("Dialogo\\Objetos\\Relogio\\1_Vez.txt");
					relogioVez++;

				}
				else {

					hudDialogo.SetActive (true);
					objetoDatilografia.Digitando("Dialogo\\Objetos\\Vasculhou.txt");
				}

			}//fim verificação da tecla;
		}//fim Relogio;

        
		else if(coll.gameObject.tag == "PortaBedroom"){
        
			if (apertarTeclaE && vasculhando) {
                
                if ((portaBedroomVez == 0 || portaBedroomVez == 1) && cenaObjetos == 0 && PlayerPrefs.GetInt("chave") == 1) {

					hudDialogo.SetActive (true);

					objetoDatilografia.Digitando("Dialogo\\Objetos\\PortaBedroom\\1_VezChave.txt");
					portaBedroomVez++;
                    PlayerPrefs.SetInt("chave", 0);

                    podeRodarParte = true;


				}
				else if (portaBedroomVez == 0 && cenaObjetos == 0 && PlayerPrefs.GetInt("chave") == 0) {

					hudDialogo.SetActive (true);

					objetoDatilografia.Digitando("Dialogo\\Objetos\\PortaBedroom\\1_Vez.txt");
					portaBedroomVez++;

				}
				else {

					hudDialogo.SetActive (true);
					objetoDatilografia.Digitando("Dialogo\\Objetos\\Vasculhou.txt");
				}

			}//fim verificação da tecla;
		}//fim Relogio;

        #endregion 


        #region Objetos Do Redroom

        //Objetos do Redroom;
        else if (coll.gameObject.tag == "PortaRedroom")
        {

            if (apertarTeclaE && vasculhando)
            {
                if (portaRedroomVez == 0 && cenaObjetos == 0)
                {
                    hudDialogo.SetActive(true);

                    objetoDatilografia.Digitando("Dialogo\\Objetos\\PortaRedroom\\1_Vez.txt");
                    portaRedroomVez++;

                }
                else if (portaRedroomVez == 1 && cenaObjetos == 1)
                {
                    hudDialogo.SetActive(true);
                    objetoDatilografia.Digitando("Dialogo\\Objetos\\PortaRedroom\\2_Vez.txt");

                    portaRedroomVez++;
                }
                else
                {
                    hudDialogo.SetActive(true);
                    objetoDatilografia.Digitando("Dialogo\\Objetos\\Vasculhou.txt");
                }

            }//fim verificação da tecla;
        }//fim Porta do Redroom;

        else if (coll.gameObject.tag == "Quadro")
        {

            if (apertarTeclaE && vasculhando)
            {

                if (quadroVez == 0 && cenaObjetos == 0)
                {

                    hudDialogo.SetActive(true);

                    objetoDatilografia.Digitando("Dialogo\\Objetos\\Quadro\\1_Vez.txt");
                    quadroVez++;

                }
                else if (quadroVez == 1 && cenaObjetos == 1)
                {
                    hudDialogo.SetActive(true);
                    objetoDatilografia.Digitando("Dialogo\\Objetos\\Quadro\\2_Vez.txt");

                    quadroVez++;
                }
                else
                {

                    hudDialogo.SetActive(true);
                    objetoDatilografia.Digitando("Dialogo\\Objetos\\Vasculhou.txt");
                }

            }//fim verificação da tecla;
        }//fim Quadro do Redroom;

        else if (coll.gameObject.tag == "Mesa")
        {

            if (apertarTeclaE && vasculhando)
            {

                if (mesaVez == 0 && cenaObjetos == 0)
                {

                    hudDialogo.SetActive(true);

                    objetoDatilografia.Digitando("Dialogo\\Objetos\\Mesa\\1_Vez.txt");
                    mesaVez++;

                }
                else if (mesaVez == 1 && cenaObjetos == 1)
                {
                    hudDialogo.SetActive(true);
                    objetoDatilografia.Digitando("Dialogo\\Objetos\\Mesa\\2_Vez.txt");

                    mesaVez++;
                }
                else
                {

                    hudDialogo.SetActive(true);
                    objetoDatilografia.Digitando("Dialogo\\Objetos\\Vasculhou.txt");
                }

            }//fim verificação da tecla;
        }//fim Mesa do Redroom;
        else if (coll.gameObject.tag == "Camera")
        {

            if (apertarTeclaE && vasculhando)
            {

                if (cameraVez == 0 && cenaObjetos == 0)
                {

                    hudDialogo.SetActive(true);

                    objetoDatilografia.Digitando("Dialogo\\Objetos\\Camera\\1_Vez.txt");
                    cameraVez++;

                }
                else if (cameraVez == 1 && cenaObjetos == 1)
                {
                    hudDialogo.SetActive(true);
                    objetoDatilografia.Digitando("Dialogo\\Objetos\\Camera\\2_Vez.txt");

                    podeRodarParte = true;

                    cameraVez++;
                    scriptGeral.parte++;
                }
                else
                {

                    hudDialogo.SetActive(true);
                    objetoDatilografia.Digitando("Dialogo\\Objetos\\Vasculhou.txt");
                }

            }//fim verificação da tecla;
        }//fim Camera;

        #endregion
    }//fim Trigger;

    void OnTriggerExit2D(Collider2D coll)
	{
		//if da tecla E;
		if (coll.gameObject.tag != "Floor") {
			vasculhando = false;
		}
	}



	public void PararPlayer(){
		speed = 0;
		mover = false;
		Debug.Log ("parou player");
	}

	public void AndarPlayer(){
		speed = speed_natural;
		mover = true;
		Debug.Log ("ande player");
	}
    public void ResetarVezesVasculhouBedroom(int vezValor)
    {
        portaBedroomVez = vezValor;
        armarioVez = vezValor;
        relogioVez = vezValor;
        tapeteVez = vezValor;
    }
    public void ResetarVezesVaculhouRedroom(int vezValor)
    {
        portaRedroomVez = vezValor;
        relogioVez = vezValor;
        quadroVez = vezValor;
        mesaVez = vezValor;
    }
    public void VerificarRodarProximaParte() {

        if (podeRodarParte && objetoDatilografia.acabouFala)
        {
            PlayerPrefs.SetInt("rodarParte", 1);
            podeRodarParte = false;
            print("RodarParte");
        }
    }
    private void VerificarVasculhar()
    {
        //vasculhar if;
        if (vasculhando)
        {

            imagemTecla.sprite = teclaE[1];
        }
        else
        {
            imagemTecla.sprite = teclaE[0];
        }
    }

    private void VerificarTeclaE()
    {

        if (Input.GetKeyDown(KeyCode.E) && podeApertarE == true)
        {
            apertarTeclaE = true;
        }
        else
        {
            apertarTeclaE = false;
        }
    }
}//fim



