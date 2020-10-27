using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PlayerScripts
{
    public class PlayerStateScript : MonoBehaviour
    {
        internal float experience=0;
        public int level=1;
        internal List<string> runes;
        
        [SerializeField] private PlayerMainScript mainScript;
        public Text levelText;
        internal bool hasKey=false;

        public void AddExperience(float experienceGain)
        {
            experience += experienceGain;
            if (experience == 10)
            {
                level += 1;
                Debug.Log("Level Up");
                
                levelText.text = level.ToString();
            }
        }
    }
}