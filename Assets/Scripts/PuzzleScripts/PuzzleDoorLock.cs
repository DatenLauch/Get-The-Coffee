using System;
using GTC_Scripts;
using UnityEngine;

public class PuzzleDoorLock : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;
    public string Interactionprompt => _prompt;
    [SerializeField] BPuzzle bPuzzle;
    public int solutionNumber;
    public DoorTrigger doorToOpen;
    [SerializeField] AudioManager audioManager;

    //Door Movement
    bool doorMoved = false;

    public bool Interact(Interactor interactor)
    {
        int[] numbersForSolution = parseTextIntoIntArray(bPuzzle);
        if (calcNumberForDoorCheck(numbersForSolution))
        {
            Debug.Log("Right Numbers");
            if (!doorMoved)
            {
                doorMoved = true;
                audioManager.playSound(SoundEnum.KeyCardAccept);
                doorToOpen.OpenDoor();
            }
        }
        else
        {
            audioManager.playSound(SoundEnum.KeyCardReject);
            Debug.Log("Wrong Numbers");
        }

        return true;
    }

    int[] parseTextIntoIntArray(BPuzzle bPuzzle)
    {
        int[] numbers = new[] { -1 };
        if (this.bPuzzle.getBPuzzleComponents() != null)
        {
            BPuzzleNumber[] components = bPuzzle.getBPuzzleComponents();
            numbers = new int[components.Length - 1];
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
}
