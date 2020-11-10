using System;
using UnityEngine;

namespace PlayerScripts
{
    public class PlayerPushBackScript : MonoBehaviour
    {
        private void Start()
        {
            PlayerHealthScript.takeDamage += PushBack;
        }

        void PushBack()
        {
            Debug.Log("Pushback");
        }
    }
}