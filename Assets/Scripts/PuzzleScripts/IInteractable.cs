using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GTC_Scripts
{
    public interface IInteractable
    {
        public string Interactionprompt { get; }
        public bool Interact(Interactor interactor);
    }
}