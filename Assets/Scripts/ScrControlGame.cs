using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrControlGame : MonoBehaviour
{
    public static int punts = 0; //puntuació
    public static int pickups = 0; //nombre de pickups a l'escena

    [SerializeField] Text nivellFi;

    private void Update()
    {
        if(ScrControlGame.pickups == 0) NivellFinalitzat();
        ControlEntradaUsuari();
       
    }
    void NivellFinalitzat()
    {
        //print("End");
        nivellFi.text = "Fi del joc";
        //ScrControlGame.pickups = -1;
    }
    void ControlEntradaUsuari()
    {
        if (Input.GetKeyDown(KeyCode.X)) //ScrControlGame.pickups = 0; primer prototipus
        EliminaPickups();
    }
    void EliminaPickups()
    {
        GameObject[] picks;
        picks = GameObject.FindGameObjectsWithTag("Pickup");
        foreach(GameObject p in picks)
        {
            pickups--;
            punts += p.GetComponent<ScrPickup>().valor; //per incrementar X
            Destroy(p);
            
            
        }
    }
}
