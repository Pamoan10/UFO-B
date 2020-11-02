using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrPlayer : MonoBehaviour
{
    [SerializeField]
    float forsa = 3;
    float x, y; //variables per guardar lectura dels cursors de forma global

    //Vull definir un objecte del tipus Rigidbody anomenat rb (variable), val 0. Per accedir al component RigidBody:
    Rigidbody2D rb;
    ScrPickup scrP;
    AudioSource a; //per accedir a l'audio DEFINIR VARIABLE

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); //ara rb apunta al component rigidBody del player AIXÒ ÉS BÀSIC
        a = GetComponent<AudioSource>(); //ACCEDIR AL COMPONENT
        //print("En aquesta escena: " + ScrControlGame.pickups); 
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Horizontal"); //llegir moviment horizontal
        y = Input.GetAxis("Vertical"); //llegir moviment vertical
        
    }
    private void FixedUpdate()
    {
        rb.AddForce(new Vector2(x*forsa, y*forsa));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.tag == "Pickup") Destroy(collision.gameObject);
        if (collision.CompareTag("Pickup"))
        {
            AudioSource audioP; //definir variable per accedir a l'audio del pickup

            audioP = collision.GetComponent<AudioSource>();
            AudioSource.PlayClipAtPoint(audioP.clip, Camera.main.transform.position);

            scrP = collision.GetComponent<ScrPickup>();
            ScrControlGame.punts += scrP.valor;
            Destroy(collision.gameObject);
            ScrControlGame.pickups--;

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        a.Play();
    }

}
