using System.Collections;
using System.Collections.Generic;
using GTC_Scripts;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
namespace GTC_Scripts
{
    public class BPuzzleNumber : MonoBehaviour, ISelectionBorder, INumberChangeable
    {

        [SerializeField] public TextMeshProUGUI displayNumber;

        [SerializeField] public Image image;
        private bool numberChanged = false;
        
        void Start()
        {
            image.gameObject.SetActive(false);
        }

        public void ChangeNumber()
        {
            displayNumber.text = numberChanged ? "0" : "1";
            numberChanged = !numberChanged;
        }
        

        public void ShowBorder()
        {
            image.transform.position = displayNumber.transform.position;
            image.gameObject.SetActive(true);
        }

        public void HideBorder()
        {
            image.gameObject.SetActive(false);
        }
        
        public int getNumber() { return int.Parse(displayNumber.text); }
    }
}
