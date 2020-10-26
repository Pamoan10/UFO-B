using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ----------------------------------------------------------------------------------
/// DESCRIPCIÓ
///         Script utilitzat per gestionar les accions relacionades amb la UI
/// AUTORA: Paula Moreta
/// DATA:   26/10/2020
/// VERSIÓ: 1.0
/// CONTROL DE VERSIONS
///         1.0: primera versió. Mostra puntuació
/// ----------------------------------------------------------------------------------
/// </summary>



public class ScrUI : MonoBehaviour
{
    [SerializeField]
    Text puntuacio; //per accedir a l'element de la UI
    [SerializeField]
    Text pickupsRestants; //per accedir a l'element de la UI    
    // Start is called before the first frame update
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        puntuacio.text = "Puntuació: " + ScrControlGame.punts;
        pickupsRestants.text = "Pickups: " + ScrControlGame.pickupRestants;
    }
}
