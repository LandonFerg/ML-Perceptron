using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class changeCube : MonoBehaviour {

    public int color = 1;
    public Perceptron brain;

    public int label;

    float x;
    float z;

    public MeshRenderer pointcubeRend;
    public MeshRenderer wrongCubePosRend;
    public MeshRenderer wrongCubeNegRend;
    public MeshRenderer correctCubeNegRend;

    void Start()
    {
        brain = GameObject.Find("GM").GetComponent<Perceptron>();
        x = gameObject.transform.position.x;
        z = gameObject.transform.position.z;

        float[] Theinputs = { x, z };
        int trainGuess = brain.guess(Theinputs);

        if (x > z)
        {
            color = 4;
            label = 1;
        }
        else
        {
            color = 1;
            label = -1;
        }

        int target = label;

        //brain.train(Theinputs, target);    // uncomment to train automatically

        if (trainGuess == target)
        {
            pointcubeRend.material.SetColor("_Color", Color.green);
            wrongCubeNegRend.material.SetColor("_Color", Color.green);
            wrongCubePosRend.material.SetColor("_Color", Color.green);
            correctCubeNegRend.material.SetColor("_Color", Color.green);
        }
        else
        {
            pointcubeRend.material.SetColor("_Color", Color.red);
            wrongCubeNegRend.material.SetColor("_Color", Color.red);
            wrongCubePosRend.material.SetColor("_Color", Color.red);
            correctCubeNegRend.material.SetColor("_Color", Color.red);
        }

        switch (color)
        {
            case 1:
                pointcubeRend.enabled = true;
                wrongCubeNegRend.enabled = false;
                wrongCubePosRend.enabled = false;
                correctCubeNegRend.enabled = false;
                break;
            case 2:
                pointcubeRend.enabled = false;
                wrongCubeNegRend.enabled = true;
                wrongCubePosRend.enabled = false;
                correctCubeNegRend.enabled = false;
                break;
            case 3:
                pointcubeRend.enabled = false;
                wrongCubeNegRend.enabled = false;
                wrongCubePosRend.enabled = true;
                correctCubeNegRend.enabled = false;
                break;
            case 4:
                pointcubeRend.enabled = false;
                wrongCubeNegRend.enabled = false;
                wrongCubePosRend.enabled = false;
                correctCubeNegRend.enabled = true;
                break;
            default:
                print("incorrect color input");
                break;
        }

    }

    void Update()
    {

        float[] Theinputs = { x, z };
        int trainGuess = brain.guess(Theinputs);

        int target = label;

        if (trainGuess == target)
        {
            pointcubeRend.material.SetColor("_Color", Color.green);
            wrongCubeNegRend.material.SetColor("_Color", Color.green);
            wrongCubePosRend.material.SetColor("_Color", Color.green);
            correctCubeNegRend.material.SetColor("_Color", Color.green);
        }
        else
        {
            pointcubeRend.material.SetColor("_Color", Color.red);
            wrongCubeNegRend.material.SetColor("_Color", Color.red);
            wrongCubePosRend.material.SetColor("_Color", Color.red);
            correctCubeNegRend.material.SetColor("_Color", Color.red);
        }


        if (Input.GetMouseButtonDown(0))    // trains on left mouse click
        {
            Debug.Log("de pressed");
            brain.train(Theinputs, target);
        }
    }
}
