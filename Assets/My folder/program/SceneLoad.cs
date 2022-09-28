using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class SceneLoad : MonoBehaviour
{
    /// <summary>Fade‚³‚¹‚é‘ÎÛ</summary>
    [SerializeField] Image _image = default;
    /// <summary>Fade‚·‚é‚Ü‚Å‚ÌŠÔ</summary>
    [SerializeField] float _fadeTime = 1f;

    void OnEnable()
    {
        Debug.Log("complete");
        _image.gameObject.SetActive(true);
        _image.DOFade(0f, _fadeTime).OnComplete(() => _image.gameObject.SetActive(false));
    }

    public void MoveScene(string sceneName)
    {
        if(_image != null)
        {
            _image.DOFade(1f, _fadeTime)
                .OnComplete(() => SceneManager.LoadScene(sceneName));
        }
        else
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
