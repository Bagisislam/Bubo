using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallFollowScript : MonoBehaviour
{
    [SerializeField] Transform target;
    Vector3 pos;
    private float mize;

    private void Start()
    {
        pos = transform.position;
        mize = GetComponent<BoxCollider2D>().size.x / 2;
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 newpos = new Vector3(transform.position.x,target.transform.position.y+1,transform.position.z);

        transform.position = Vector3.Lerp(transform.position,newpos,0.8f*Time.deltaTime);

       

    }
}
