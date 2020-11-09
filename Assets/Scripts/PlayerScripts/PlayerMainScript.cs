using System;
using UnityEngine;
using UnityEngine.UI;


namespace PlayerScripts
{
    public class PlayerMainScript : MonoBehaviour
    {
        [SerializeField] internal PlayerInputScript inputScript;
        [SerializeField] internal PlayerMovementScript movementScript;
        [SerializeField] internal PlayerStateScript stateScript;
        [SerializeField] internal PlayerCollisionScript playerCollisionScript;
        [SerializeField] internal PlayerAttackScript playerAttackScript;
        [SerializeField] internal PlayerHealthScript healthScript;
        [SerializeField] internal PlayerHouseScript houseScript;
        [SerializeField] internal PlayerPowerScript powerScript;
        private void Awake()
        {

        }
    }
}