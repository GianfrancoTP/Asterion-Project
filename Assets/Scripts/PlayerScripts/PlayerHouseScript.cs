using System;
using UnityEngine;
using UnityEngine.UI;

namespace PlayerScripts
{
    public class PlayerHouseScript : MonoBehaviour
    {
        internal string house;
        public Text houseNameText;
        [SerializeField] private PlayerMainScript mainScript;

        void SetHouse()
        {
            
            houseNameText.text = house;
        }

        private void Start()
        {
            house = MainMenu.houseName;
            SetHouse();
        }
    }
}