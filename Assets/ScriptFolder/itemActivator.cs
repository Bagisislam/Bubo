using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class itemActivator : MonoBehaviour
{
    //Variables
    [SerializeField]
    float DictanceFromPlayer;

    private GameObject Player;

    public List<ActivatorItam> _activatorItams;

    //


    private void Start()
    {
        Player = GameObject.Find("Bubo");
        _activatorItams = new List<ActivatorItam>();


        StartCoroutine(CheckActivation());
    }

    IEnumerator CheckActivation()
    {
        List<ActivatorItam> removeList = new List<ActivatorItam>();

        if (_activatorItams.Count > 0)
        {
            foreach (var item in _activatorItams)
            {
                if (Vector3.Distance(Player.transform.position, item.itempos) > DictanceFromPlayer)
                {
                    //if a obje of listActivatorItam have been destroyed by something than obje equel to null in this case this if statmen gonna run up
                    //and do not Set to Active of obje because the obje no longer exit in the game and there is no nessesery to set active .
                    if (item.item == null)
                    {
                        removeList.Add(item);

                    }
                    else
                    {
                        item.item.SetActive(false);
                    }
                }
                else
                {
                    if (item.item == null)
                    {
                        removeList.Add(item);
                    }
                    else
                    {
                        item.item.SetActive(true);
                    }
                }

            }
        }

        yield return new WaitForSeconds(0.01f);

        if (removeList.Count > 0)
        {
            foreach (var item in removeList)
            {
                _activatorItams.Remove(item);
            }

        }

        yield return new WaitForSeconds(0.01f);

        StartCoroutine(CheckActivation());

    }

}


public  class ActivatorItam
{
    public GameObject item;

    public Vector3 itempos;

}