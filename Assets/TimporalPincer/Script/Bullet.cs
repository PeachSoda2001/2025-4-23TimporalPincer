using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "ENEMY")
        {
            collision.transform.GetComponent<Enemy>().HandleTakenDMG(40);
        }
        Destroy(this.gameObject);
    }
}
