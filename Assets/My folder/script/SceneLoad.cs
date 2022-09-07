using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class SceneLoad : MonoBehaviour
{
    [SerializeField] Image _image;

    public void MoveScene(string sceneName)
    {
        if(_image != null)
        {
            _image.DOFade(1f, 1f).OnComplete(() => SceneManager.LoadScene(sceneName));
        }
        else
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
