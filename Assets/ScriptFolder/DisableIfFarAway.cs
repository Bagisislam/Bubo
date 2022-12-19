using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableIfFarAway : MonoBehaviour
{
    //Variable
    GameObject _GameObject;

    itemActivator itemActivator;

    //


    // Start is called before the first frame update
    void Start()
    {
        _GameObject = GameObject.Find("ÝtemActivatorObject");
        itemActivator = _GameObject.GetComponent<itemActivator>();

        StartCoroutine(vs());
    }

    IEnumerator vs()
    {
        yield return new WaitForSeconds(0.1f);
        itemActivator._activatorItams.Add(new ActivatorItam { item = this.gameObject, itempos = transform.position });
    }
}
