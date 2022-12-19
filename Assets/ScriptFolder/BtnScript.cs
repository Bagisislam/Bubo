using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BtnScript : MonoBehaviour
{
    [SerializeField] GameObject Settingscaravan;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartBtnMethod()
    {
        SceneMenedermethdo(1);
    }

    public void PcVersionMethod()
    {
        SceneMenedermethdo(2);
    }

    public void MobilVersion()
    {
        SceneMenedermethdo(3);
    }

    public void QuitBtn()
    {
        Application.Quit();
    }

    public void ResumeGameBtn()
    {
        Time.timeScale = 1;
        Settingscaravan.SetActive(false);
    }

    public void JoyStickMenubtn()
    {
        Time.timeScale = 0;
        Settingscaravan.SetActive(true);
    }

    public void SceneMenedermethdo(int vs)
    {
        SceneManager.LoadScene(vs);
    }


}
