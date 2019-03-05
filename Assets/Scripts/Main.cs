using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour {

    public int generationNum;
    public Text generationTex;

    void Update()
    {
        generationTex.text = generationNum.ToString();

        if (Input.GetMouseButtonDown(0))    // trains on left mouse click
        {
            generationNum++;
        }
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene("testScene");
    }
}
