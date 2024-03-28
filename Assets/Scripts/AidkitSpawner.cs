using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AidkitSpawner : MonoBehaviour
{
    public Aidkit aidkitPrefab;
    public float deleyMin = 3;
    public float deleyMax = 9;

    private List<Transform> _spawnerPoints;
    private Aidkit _aidkit;

    private void Start()
    {
        _spawnerPoints = new List<Transform>(transform.GetComponentsInChildren<Transform>());
    }

    private void Update()
    {
        if (_aidkit != null) return;
        if (IsInvoking()) return;
        Invoke("CreateAidkit",Random.Range(deleyMin,deleyMax));
    }

    private void CreateAidkit()
    {
        _aidkit = Instantiate(aidkitPrefab);
        _aidkit.transform.position = _spawnerPoints[Random.Range(0,_spawnerPoints.Count)].position;
    }
}
