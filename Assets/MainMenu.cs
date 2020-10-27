using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public static string houseName;
    public void AresSelect()
    {
        houseName = "ARES";
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Debug.Log("ARES");
    }

    public void HermesSelect()
    {
        houseName = "HERMES";
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Debug.Log("HERMES");
    }
}
