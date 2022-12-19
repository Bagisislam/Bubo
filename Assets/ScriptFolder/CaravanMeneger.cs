using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaravanMeneger : MonoBehaviour
{
    [SerializeField] GameObject Settingscaravan;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        PauseGame();
    }

    public void PauseGame()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
                Settingscaravan.SetActive(true);

            }
            else if (Time.timeScale == 0)
            {
                Time.timeScale = 1;
                Settingscaravan.SetActive(false);
            }
        }
    }
}
