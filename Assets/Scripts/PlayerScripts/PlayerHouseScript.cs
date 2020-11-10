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
        public GameObject ares;
        public Sprite hermes;
        public Sprite zeus;

        void SetHouse()
        {
            
            houseNameText.text = house;
        }

        private void Start()
        {
            house = MainMenu.houseName;
            if (house == "HERMES") 
            {
                Replace(ares, hermes);
            } else if (house == "ZEUS") 
            {
                Replace(ares, zeus);
            }
            SetHouse();
        }

        void Replace(GameObject obj1, Sprite obj2)
        {
            //Instantiate(obj2, obj1.transform.position, Quaternion.identity);
            //obj2.GetComponent<SpriteRenderer>().sortingOrder = 2;
            obj1.GetComponent<SpriteRenderer>().sprite = obj2;
            //Destroy(obj1);
        }
    }
}