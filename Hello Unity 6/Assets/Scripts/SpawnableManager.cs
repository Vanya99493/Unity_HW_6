using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class SpawnableManager : MonoBehaviour
{
    [SerializeField] private ARRaycastManager _raycastManager;
    [SerializeField] private Camera _arCamera;

    private List<ARRaycastHit> _hits;
    private GameObject _spawnedObject = null;

    public void Initialize()
    {
        _hits = new List<ARRaycastHit>();
    }

    public void SpawnObject(Touch touch, GameObject prefab)
    {
        RaycastHit hit;
        Ray ray = _arCamera.ScreenPointToRay(touch.position);

        if (_raycastManager.Raycast(touch.position, _hits))
        {
            if(touch.phase == TouchPhase.Began && _spawnedObject == null)
            {
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.gameObject.tag == "Spawnable")
                    {
                        _spawnedObject = hit.collider.gameObject;
                    }
                    else
                    {
                        SpawnPrefab(_hits[0].pose.position, prefab);
                    }
                }

            }
            else if(touch.phase == TouchPhase.Moved && _spawnedObject != null)
            {
                _spawnedObject.transform.position = _hits[0].pose.position;
            }
            if(touch.phase == TouchPhase.Ended)
            {
                _spawnedObject = null;
             }
        }
    }

    private void SpawnPrefab(Vector3 spawnPosition, GameObject prefab)
    {
        _spawnedObject = Instantiate(prefab, spawnPosition, Quaternion.identity);
    }
}