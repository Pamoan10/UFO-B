using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScrControlGame : MonoBehaviour
{
    public static int punts = 0; //puntuació
    public static int pickups = 0; //nombre de pickups a l'escena

    //[SerializeField] Text nivellFi;
    [SerializeField] GameObject pantallafi;
    [SerializeField] AudioSource so; //per accedir so ambient
    bool pausat = false;

    string[] escenes = { "Level1", "Level2", "Level3"}; //fem un array per organitzar nivells
    static int level = 0; //vull que duri per això és static

    private void Start()
    {
        so.ignoreListenerPause = true;
        Time.timeScale = 1;
    }
    private void Update()
    {
        if(ScrControlGame.pickups == 0) NivellFinalitzat();
        ControlEntradaUsuari();
       
    }
    void NivellFinalitzat()
    {
        //print("End");
        //nivellFi.text = "Fi del joc";
        //ScrControlGame.pickups = -1;
        pantallafi.SetActive(true); //mostra la pantalla
        Time.timeScale = 0; //parar el temps
    }
    void ControlEntradaUsuari()
    {
        if (Input.GetKeyDown(KeyCode.X)) //ScrControlGame.pickups = 0; primer prototipus
        EliminaPickups();
        if (Input.GetKeyDown(KeyCode.B)) MuteFons();
        if (Input.GetKeyDown(KeyCode.M)) MuteAudio();
        if (Input.GetKeyDown(KeyCode.KeypadMinus)) so.volume -= 0.05f;
        if (Input.GetKeyDown(KeyCode.KeypadPlus)) so.volume += 0.05f;
        if (Input.GetKeyDown(KeyCode.Alpha1)) AudioListener.volume -= 0.05f;
        if (Input.GetKeyDown(KeyCode.Alpha2)) AudioListener.volume += 0.05f;
        AudioListener.volume = Mathf.Clamp(AudioListener.volume, 0, 1); //AudioListener por tenir nivells negatius, amb això ho delimito
        if (Input.GetKeyDown(KeyCode.Return) && ScrControlGame.pickups == 0) NextLevel();
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
    void MuteFons()
    {
        pausat = !pausat;
        if (pausat) so.Pause(); else so.Play();
    }
    void MuteAudio()
    {
        AudioListener.pause = !AudioListener.pause;
    }
    void NextLevel()
    {
        level++;
        if (level < escenes.Length)
            SceneManager.LoadScene(escenes[level]); //array per que canvii de nivell
        else print("GAME OVER"); //prototipus
    }
}
