using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    private Rigidbody2D player;


    /* NOTA Public para fijarme yo de los datos que suelta */
    public Vector2 initialPosition;
    public Vector2 salidaPosition;

    public Vector2[] listaEntradas;
    public Vector2[] listaSalidas;

    public GameObject casillaInicio;
    public GameObject casillaSalida;

    public int numeroentrada;
    public int numerosalida;
    
    public Button BotonArriba;
    public Button BotonAbajo;
    public Button BotonDerecha;
    public Button BotonIzquierda;


    /* NOTA Esta parte se ocupa de la aleatorización de los cachos de pared. Mucho más simple de lo que
     *      inicialmente iba a ser, que se puede ver en el Script no utilizado SemiModular */
    int A;
    int B;

    public GameObject A1, A2, B1, B2;

    public Vector2 Posicion;
    Vector2 valores;

    /* BASURA QUE USÉ AL COMENZAR*/
    //public Vector2 Entrada1 = new Vector2(120, 117);
    //public Vector3 Entrada2 = new Vector2(120, 974);
    //public Vector3 Entrada3 = new Vector2(1808, 974);
    //public Vector3 Entrada4 = new Vector2(1808, 117);
    //public GameObject casillaInicio1;
    //public GameObject casillaInicio2;
    //public GameObject casillaInicio3;
    //public GameObject casillaInicio4;

    bool teclapulsadaizquierda, teclapulsadaderecha, teclapulsadaarriba, teclapulsadaabajo;
    // Use this for initialization
    void Start()
    {
        restartGame();
        player = GetComponent<Rigidbody2D>();

        /* NOTA Uso restartGame también para el inicio de manera que ya no necesito poner todo esto aqui */
        //InicioPos();
        //salidaPos();
        //transform.position = initialPosition;
        //casillaInicio.transform.position = initialPosition;
        //casillaSalida.transform.position = salidaPosition;

        /* NOTA En lugar de hacer esto altero la posición de un unico objeto, optimizando más la escena. Más elegante. */
        //if (initialPosition == listaEntradas[0]){
        //    casillaInicio1.SetActive(true);
        //}
        //if (initialPosition == listaEntradas[1])
        //{
        //    casillaInicio2.SetActive(true);
        //}
        //if (initialPosition == listaEntradas[2])
        //{
        //    casillaInicio3.SetActive(true);
        //}
        //if (initialPosition == listaEntradas[3])
        //{
        //    casillaInicio4.SetActive(true);
        //}

        int width = 1920; // or something else
        int height = 1080; // or something else
        bool isFullScreen = false; // should be windowed to run in arbitrary resolution
        int desiredFPS = 60; // or something else

        Screen.SetResolution(width, height, isFullScreen, desiredFPS);
    }

    /* NOTA Al final he movido el collider de la salida al centro. Mi intención principal era que se ganara la partida al estar unos segundos
     *      sobre la salida, pero no lo he conseguido. */ 
    /*private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Salidas"))
        {
            Destroy(player.gameObject);
        }
    }*/

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Salidas"))
        {
            restartGame();
        }

    }

    void FixedUpdate()
    {

        /* NOTA  He intentado hacer que al pulsar el botón se envie una orden dentro del Update, de manera que al mantener pulsado
         *       se moviese continuamente pero no lo he conseguido. */

        if (Input.GetKey(KeyCode.A))
        {
            Vector2 Velocidad = new Vector2(-15, 0);
            player.MovePosition(player.position + Velocidad);
        }
        if (Input.GetKey(KeyCode.D))
        {
            Vector2 Velocidad = new Vector2(15, 0);
            player.MovePosition(player.position + Velocidad);
        }
        if (Input.GetKey(KeyCode.W))
        {
            Vector2 Velocidad = new Vector2(0, 15);
            player.MovePosition(player.position + Velocidad);
        }
        if (Input.GetKey(KeyCode.S))
        {
            Vector2 Velocidad = new Vector2(0, -15);
            player.MovePosition(player.position + Velocidad);
        }
    }

    void InicioPos()
    {
        //Tengo dudas sobre qué metodo seguir. El Random range de Unity lo podria hacer y que me diera dos valores, uno para la entrada y otro para la salida.

        for (int i = 0; i < 6;)
        {
            numeroentrada = Random.Range(0, listaEntradas.Length);
            initialPosition = listaEntradas[numeroentrada];
            Debug.Log(initialPosition + listaEntradas[numeroentrada]);
            return;
        }
    }
    void salidaPos()
    {

        for (int i = 0; i < 6;)
        {
            numerosalida = Random.Range(0, listaSalidas.Length);
            while(numerosalida == numeroentrada)
            {
                numerosalida = Random.Range(0, listaSalidas.Length);
            }
            salidaPosition = listaSalidas[numerosalida];
            Debug.Log(salidaPosition + listaSalidas[numerosalida]);
            return;
        }
    }
    public void boton()
    {

    }
    public void restartGame()
    {
        InicioPos();
        salidaPos();
        restartBarras();
        transform.position = initialPosition;
        casillaInicio.transform.position = initialPosition;
        casillaSalida.transform.position = salidaPosition;
    }

    public void restartBarras()
    {
        randomCachos();
        if (A == 0)
        {
            A1.SetActive(true);
            A2.SetActive(false);
        }
        else
        {
            A1.SetActive(false);
            A2.SetActive(true);
        }

        if (B == 0)
        {
            B1.SetActive(true);
            B2.SetActive(false);
        }
        else
        {
            B1.SetActive(false);
            B2.SetActive(true);
        }
    }

    void randomCachos()
    {
        A = Random.Range(0, 2);
        B = Random.Range(0, 2);

        Debug.Log(A);
        Debug.Log(B);

    }

    public void botonizq()
    {
        Vector2 Velocidad = new Vector2(-140, 0);
        player.MovePosition(player.position + Velocidad);
    }
    public void botonider()
    {
        Vector2 Velocidad = new Vector2(140, 0);
        player.MovePosition(player.position + Velocidad);
    }
    public void botonup()
    {
        Vector2 Velocidad = new Vector2(0, 140);
        player.MovePosition(player.position + Velocidad);
    }
    public void botondown()
    {
        Vector2 Velocidad = new Vector2(0, -140);
        player.MovePosition(player.position + Velocidad);
    }
}
