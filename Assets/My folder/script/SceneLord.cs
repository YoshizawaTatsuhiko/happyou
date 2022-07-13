using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLord : MonoBehaviour
{
    [SerializeField] string _SceneLord;

    public void MoveScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
