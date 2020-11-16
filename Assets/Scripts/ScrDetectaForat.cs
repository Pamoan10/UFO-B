using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrDetectaForat : MonoBehaviour
{
    // Start is called before the first frame update
  
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        float escala = 0; 
        if (collision.CompareTag("Forat") && GetComponentInParent<Rigidbody2D>().velocity.magnitude < 3)
        {
            GetComponentInParent<Rigidbody2D>().velocity = new Vector2(0, 0);
            transform.parent.position = Vector3.Lerp(transform.parent.position, collision.transform.position, .05f);

            escala = transform.parent.localScale.x;
            if (escala > 0)
            {
                escala -= .03f;
                transform.parent.localScale = new Vector3(escala, escala, 1);
            }
            else print("ja ha acabat la caiguda, fer el que calgui ara...");
        }

    }
}
