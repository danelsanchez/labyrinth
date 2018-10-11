using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SemiModularBasico : MonoBehaviour {

    /* NOTA La idea primigenia que tuvo resulto ser demasiado compleja, por lo que decidí por un acercamiento más simple*/
    //public int NumeroDeLista;
    public int PosicionX;

    public Vector2 Posicion;
    Vector2 valores;
    //public Vector2 [] listaPosiciones;

    // Use this for initialization
    void Start () {
        restartBarras();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void restartBarras()
    {
        X();

        Posicion = valores;
        transform.position = Posicion;
    }

    void X()
    {
        valores = new Vector3(PosicionX, Random.Range(252, 826), 0);
        //for (int i = 0; i < listaPosiciones.Length; i++)
        //{

            
        //    listaPosiciones[i] = valores;
        //}
        
    }
}
