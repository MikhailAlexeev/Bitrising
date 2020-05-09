using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class ObjectActivator : MonoBehaviour
{
    public TagType activatorTag;
    public bool deactivateOnExit;
    public GameObject[] objectsToActivate;

    public CinemachineTargetGroup cinemachineTargetGroup;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (activatorTag == TagType.Player)
        {
            foreach (var obj in objectsToActivate)
            {
                obj.SetActive(true);
            }
        }
    }

  

    private void OnTriggerExit2D(Collider2D other)
    {
        if (deactivateOnExit)
        {
            foreach (var obj in objectsToActivate)
            {
                obj.SetActive(false);
            }
        }
    }
}