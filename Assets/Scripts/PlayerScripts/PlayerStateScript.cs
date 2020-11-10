using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GhostScript;
using DefaultNamespace;

namespace PlayerScripts
{
    public class PlayerStateScript : MonoBehaviour
    {
        internal float experience=0;
        internal double experience_to_level = 10;
        public int level=1;
        internal List<string> runes;
        
        [SerializeField] private PlayerMainScript mainScript;
        public Text levelText;
        internal bool hasKey=false;
        

        public void Start()
        {
            GhostStateScript.GhostDeath += AddExperience;
        }

        public void AddExperience(string enemy)
        {
            if (enemy == "GHOST")
            {
                experience += 10;
                Debug.Log("Your experience is " + experience.ToString() + " out of " + experience_to_level.ToString());
            }
            if (experience == experience_to_level)
            {
                experience_to_level = experience_to_level * 1.5;
                AudioControllerScript.LevelUpSound();
                level += 1;
                Debug.Log("Level Up");
                
                levelText.text = "Level " + level.ToString();
            }
        }
    }
}