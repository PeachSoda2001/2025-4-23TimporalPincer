using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropDownManager : MonoBehaviour
{
    public GameObject[] DropDowns;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            for(int i = 0;i<DropDowns.Length;i++)
            {
                DropDowns[i].GetComponent<Rigidbody>().useGravity = true;
                DropDowns[i].GetComponent<Rigidbody>().isKinematic = false;
            }
        }
    }
}
