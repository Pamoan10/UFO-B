using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrPorta : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] SpriteRenderer porta; //Assigno el sprite al que vull accedir

    bool obrint = false, tancant = false; //indico si la porta s'obre o es tanca
    float tamObert, tamTancat; //Mida de la porta oberta i tancada
    void Start()
    {
        tamObert = porta.size.y; //el que mesura la porta oberta
        tamTancat = 0.4f; // el que vull que mesuri quan la tanqui
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O) && !tancant) obrint = true;
        if (Input.GetKeyDown(KeyCode.T) && !obrint) tancant = true;
        if (obrint) Obrir();
        if (tancant) Tancar();
    }
    void Obrir()
    {
        porta.size = Vector2.Lerp(porta.size, new Vector2(0.66f, tamTancat), .1f);
        if (porta.size.y <= tamTancat + 0.01f)
        {
            obrint = false;
        }
    }
    void Tancar()
    {
        porta.size = Vector2.Lerp(porta.size, new Vector2(0.66f, tamObert), .1f);
        if(porta.size.y >= tamObert - 0.01f)
        {
            tancant = false;
        }
    }
}
