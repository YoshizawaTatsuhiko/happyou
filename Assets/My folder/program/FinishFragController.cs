using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishFragController : MonoBehaviour
{
    public static FinishFragController Instance => _instance;

    private static FinishFragController _instance = null;

    /// <summary>�����l��false</summary>
    public bool IsFinished { get; set; } = false;

    private void Awake()
    {
        _instance = this;
    }}
