using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ChapterScipt : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI Text;
    bool IsChaptarDone;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Text.text = "Chapter Ýs Over." +
            "to be continued";
    }

}
