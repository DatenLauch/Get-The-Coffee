using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using GTC_Scripts;
using TMPro;
using UnityEngine;

public class DoorLock : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;
    public string Interactionprompt => _prompt;

    [SerializeField] BPuzzle bPuzzle;

    // private int[] numbersForSolution = new int[4];
    public int solutionNumber;
    
    //Door Movement
    public GameObject movingDoor;
    public float moveDuration = 2f;
    bool doorMoved = false;
    public float speed;

    
    public bool Interact(Interactor interactor)
    {
        int[] numbersForSolution = parseTextIntoIntArray(bPuzzle);
        if(calcNumberForDoorCheck(numbersForSolution)) { 
            Debug.Log("Right Numbers");
            if (!doorMoved)
            {
                doorMoved = true;
                StartCoroutine(MoveObjectToTarget());
            }
        }
        else Debug.Log("Wrong Numbers");
        return true;
    }

    int[] parseTextIntoIntArray(BPuzzle bPuzzle)
    {
        int[] numbers = new []{-1};
        if (this.bPuzzle.getBPuzzleComponents() != null)
        {
            BPuzzleNumber[] components = bPuzzle.getBPuzzleComponents();
            numbers = new int[components.Length-1];
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = components[i].getNumber();
                 
            }
        }
        return numbers;
    }

    bool calcNumberForDoorCheck(int[] binaryArray)
    {
        int result = 0;
        int power = 0;

        for (int i = binaryArray.Length - 1; i >= 0; i--)
        {
            if (binaryArray[i] == 1)
            {
                result += (int)Math.Pow(2, power);
            }
            power++;
        }
        Debug.Log(result);
        return result == solutionNumber;

    }


    IEnumerator MoveObjectToTarget()
    {
        float timeElapsed = 0f;
        Vector3 startPosition = movingDoor.transform.position;
        Vector3 targetPosition = movingDoor.transform.position;
        targetPosition.z = movingDoor.transform.position.z + 2f;

        while (timeElapsed < moveDuration)
        {
            movingDoor.transform.position = Vector3.Lerp(startPosition, targetPosition, timeElapsed / moveDuration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        movingDoor.transform.position = targetPosition; // Sicherstellen, dass die Zielposition erreicht wird
        
    } 
    public void ShowBorder() {}
    public void HideBorder() {}
}
