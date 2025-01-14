using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInventory : MonoBehaviour
{
    public int NumberOfCollectibles { get; private set; }
    public UnityEvent<PlayerInventory> OnCollect;
    public void Collected()
    {
        NumberOfCollectibles++;
        OnCollect.Invoke(this);
    }
}
