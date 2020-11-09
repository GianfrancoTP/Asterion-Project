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
        internal int armor = 1;

        void SetHouse()
        {
            
            houseNameText.text = house;
        }

        private void Start()
        {
            house = MainMenu.houseName;
            //house = "ARES";
            SetHouse();
        }

     
    }
}