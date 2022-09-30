using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField]
    private float _speed = 10.0f;
    

    void Update()
    {
        
        MoveUP();
     
       
    }
    void MoveUP()
    {
        transform.Translate(Vector3.up * _speed * Time.deltaTime);

        if (transform.position.y > 8f)
        {
            if (transform.parent != null)
            {
                Destroy(transform.parent.gameObject);
            }
            Destroy(this.gameObject);

        }
    }

    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
           
                
                Destroy(other.gameObject);
                Destroy(this.gameObject);
            Debug.Log("RESPONSE");
            ScoreManager.instance.AddPoints(10);

            
        }
    }
}
