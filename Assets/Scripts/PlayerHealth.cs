using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public float health;
    public Slider slider;

    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = health;

    }

    void OnCollisionEnter(Collision enemigo)
    {
        if (enemigo.gameObject.tag == "Minotaur") 
        {
            health = health - 50f;
            Debug.Log("Minotauro choco");
        }

        
    }
}
