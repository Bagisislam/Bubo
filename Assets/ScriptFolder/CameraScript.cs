using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] float FollowSpeed;
    [SerializeField] float setyaxes;
    [SerializeField] float setzaxes;
    [SerializeField] Transform target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newpos = new Vector3(target.position.x,target.position.y+setyaxes, setzaxes);

        transform.position = Vector3.Slerp(transform.position,newpos,FollowSpeed*Time.deltaTime);
    }
}
