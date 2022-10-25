using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private SpawnableManager _spawnableManager;
    [SerializeField] private UiManager _uiManager;
    [Header("Spawnable prefabs")]
    [SerializeField] private GameObject[] _prefabs;

    private void Awake()
    {
        _spawnableManager.Initialize();
        _uiManager.Inititalize(_prefabs.Length);
    }

    private void Update()
    {
        if(Input.touchCount == 0)
        {
            return;
        }

        _spawnableManager.SpawnObject(Input.GetTouch(0), _prefabs[_uiManager.CurrentIndex]);
    }
}