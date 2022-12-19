using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chapterend : MonoBehaviour
{

    BoxCollider2D bc;

    SpriteRenderer sp;
    // Start is called before the first frame update
    void Start()
    {
        bc = GetComponent<BoxCollider2D>();
        sp = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        bc.isTrigger = false;
        sp.enabled = true;
    }
}
