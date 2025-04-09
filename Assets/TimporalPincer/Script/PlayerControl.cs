using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public static PlayerControl Instance;
    public bool IsInteractingWithUI;
    private GameObject doorController;
    private void Awake()
    {
        if (Instance == null) Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        IsInteractingWithUI = false;
        doorController = GameObject.FindGameObjectWithTag("DOOR_CONTROLLER");
    }

    // Update is called once per frame
    void Update()
    {
        if(!IsInteractingWithUI && doorController != null && Vector3.Distance(doorController.transform.position,this.transform.position)<=5)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                IsInteractingWithUI = true;
                PasswardManager.Instance.HandleStartMiniGame();
            }
        }
    }
}
