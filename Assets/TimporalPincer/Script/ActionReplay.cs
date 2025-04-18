
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionReplay : MonoBehaviour
{

    private CharacterController controller;

    private bool isInReplayMode;
    private List<ActionReplayRecord> actionReplayRecords = new List<ActionReplayRecord>();

    // Start is called before the first frame update
    void Start()
    {
        /*
        rigidbody = Getcomponent<Rigidbody>();
        */
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            isInReplayMode = !isInReplayMode;

            if (isInReplayMode)
            {
                SetTransform(0);

                //Stop collision
                /*
                rigidbody.isKinematic = true;
                */
            }
            else
            {
                SetTransform(actionReplayRecords.Count - 1);

                //Start collision
                /*
                rigidbody.isKinematic = false;
                */
            }
        }
    }

    private void FixedUpdate()
    {
        actionReplayRecords.Add(new ActionReplayRecord { position = transform.position, rotation = transform.rotation });
    }
    private void SetTransform(int index)
    {
        ActionReplayRecord actionReplayRecord = actionReplayRecords[index];

        transform.position = actionReplayRecord.position;
        /*
        transform.rotation = actionReplayRecord rotation;
        */
    }
}
