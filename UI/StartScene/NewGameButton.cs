using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewGameButton : MonoBehaviour
{
    public void OnButtonPress()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }
}
