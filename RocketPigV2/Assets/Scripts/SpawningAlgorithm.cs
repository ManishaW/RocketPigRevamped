using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using System.Collections;

public class SpawningAlgorithm : MonoBehaviour
{
    // to find the path from
    // top left to bottom right
    public static int [,] generatedMatrix =  new int[5, 4];
    public static SpawningAlgorithm instance;

    static bool isPath(int[,] arr)
    {
        // set arr[0][0] = 1
        arr[0, 0] = 1;
        arr[0, 1] = 1;

        // Mark reachable (from top left) nodes
        // in first row and first column.
        for (int i = 1; i < 5; i++)
            if (arr[i, 0] != -1)
                arr[i, 0] = arr[i - 1, 0];
        for (int j = 1; j < 4; j++)
            if (arr[0, j] != -1)
                arr[0, j] = arr[0, j - 1];

        // Mark reachable nodes in
        // remaining matrix.
        for (int i = 1; i < 5; i++)
            for (int j = 1; j < 4; j++)
                if (arr[i, j] != -1)
                    arr[i, j] = Mathf.Max(arr[i, j - 1],
                                        arr[i - 1, j]);

        // return yes if right
        // bottom index is 1
        return (arr[5 - 1, 4 - 2] == 1);
    }
    int[,] generateRandomMatrix()
    {
        // Random rnd = new Random();
        int[,] randoMatrix =  new int[5, 4];
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                randoMatrix[i,j] = 0;
            }
        }
        int challengeMode;
        float timeInAir = Time.time-PlayGameScene.blastTime;
        if (timeInAir>30){
            challengeMode =(int)Random.Range(13,20);
            Debug.Log("Hard ");
        }else if (timeInAir>20){
            challengeMode =(int)Random.Range(7,13);

            Debug.Log("Medium ");
        }else{
           challengeMode =(int)Random.Range(3,6);
        }

        for (int i=0;i<challengeMode;i++){
            int row= (int)Random.Range(0,4);
            int col= (int)Random.Range(0,5);
            // if (randoMatrix[col,row]!=-1)
            if (randoMatrix[col,row]==0){
                randoMatrix[col,row]= -1;
            } else{
                i--;
            }
            
        }
        
        randoMatrix[4,3] = 0;
        return randoMatrix;
    }


public static void printArray(int[,] randoMatrix){
    for (int i = 0; i < 5; i++)
        {
            Debug.Log(randoMatrix[i,0]+" "+randoMatrix[i,1]+" "+randoMatrix[i,2]+" "+randoMatrix[i,3] );

        }
}

    //Driver code
    // public static void Main()
    void Start()
    {

   

    }
    void Awake(){
        instance = this;
    }
 
    public static void generateMatrixWithPath(){
        bool containsPath = false;
        int[,] arr2 = new int[5, 4];
        while (!containsPath){
            arr2 = instance.generateRandomMatrix();
            containsPath = isPath(arr2);
        }
        int row= (int)Random.Range(0,4);
        int col= (int)Random.Range(0,5);
        if (arr2[col,row]==1){
            arr2[col,row]= 2;
        }
        generatedMatrix = arr2;
        

    }
}

// This code is contributed
// by vt_m