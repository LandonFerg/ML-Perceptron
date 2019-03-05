using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Perceptron : MonoBehaviour {

    public GameObject positiveCubePrefab;

    changeCube changeCubeScript;

    public int positiveCubeAmount = 10;

    float[] weights = new float[2];
    public float[] inputs = { -1, 0.5f };

    public float lr = 0.1f;    // Learning rate

    // Activation function | For this we use something similair to sin but only returns a -1 or 1.
    int sign(float n)
    {
        if (n > 0)
        {
            return 1;
        }
        else if (n == 0)
        {
            Debug.Log("Returning 0 :(");
            return 0;
        }
        else return -1;
    }

    void Start()
    {

        // Initialize weights randomly
        for (int i = 0; i < weights.Length; i++)
        {
            weights[i] = Random.Range(-1.0f, 1.0f);
        }

        float[] inputs = { -1, 0.5f };                          // Create Inputs

        int theGuess = guess(inputs);
        Debug.Log(theGuess);

            for (int i = 0; i < positiveCubeAmount; i++)
            {
            //Instantiate GameObject with X & Z values between -2 & 2
            Instantiate(positiveCubePrefab, new Vector3(Random.Range(-2.0f, 2.0f), Random.Range(-0.0f, 1f), Random.Range(-2.0f, 2.0f)), transform.rotation); 
            }

    }

    // Takes inputs, guesses them and returns a -1 or 1
    public int guess(float[] inputs)
    {
        float sum = 0;

        for (int i = 0; i < weights.Length; i++)
        {
            sum += inputs[i] * weights[i];
        }

        int output = sign(sum);

        return output;
    }

    public void train(float[] inputs, int target)
    {
        int guessTrain = guess(inputs);
        int error = target - guessTrain;

        // Tune all of the weights
        for (int i = 0; i < weights.Length; i++)
        {
            weights[i] += error * inputs[i] * lr;
        }
    }
}