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
        public GameObject skin;
        public Sprite hermes;
        public Sprite zeus;
        public Sprite ares;

        void SetHouse()
        {
            houseNameText.text = house;
            if (house == "HERMES")
            {
                //setSkin(hermes);
            }
            else if (house == "ZEUS")
            {
                //setSkin(zeus);
            } 
            else if (house == "ARES")
            {
                //setSkin(ares);
            }
        }

        private void Update()
        {
            house = MainMenu.houseName;
            SetHouse();
        }

        void setSkin(Sprite obj2)
        {
            Debug.Log("cambiando sprite");
            skin.GetComponent<SpriteRenderer>().sprite = obj2;
            Debug.Log("cambiando sprite2");
        }
    }
}