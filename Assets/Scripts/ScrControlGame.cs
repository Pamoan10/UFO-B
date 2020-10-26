using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrControlGame : MonoBehaviour
{
    public static int punts = 0; //puntuació
    public static int pickups = 0; //nombre de pickups a l'escena
    public static int pickupRestants; //pickups restants

    private void Update()
    {
        if (ScrControlGame.pickups == 0)
        {
            JocAcabat();
        }
    }
    void JocAcabat()
    {
        print("S'ha acabat!");
    }
}
