using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public int HP = 100;
    public Slider HPUI;
    public void HandleTakenDMG(int DMG)
    {
        HP -= DMG;
        if(HP<=0)
        {
            Destroy(this.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HPUI.value = (float)HP / 100f;
    }
}
