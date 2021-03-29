using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeGenerator : MonoBehaviour
{
    public GameObject trunkPrefab;
    public GameObject leafPrefab;

    int numLeaves = 200;
    int numTrees = 100;
    float area = 25f;
    float leafRange = 1.5f;

    void Start()
    {
        for (var i = 0; i < numTrees; i++)
        {
            GenerateTree(i);
        }
    }

    void GenerateTree(int num)
    {
        var tree = new GameObject($"Tree {num}");
        float x = Random.Range(-area, area);
        float z = Random.Range(-area, area);
        var trunk = Instantiate(
                trunkPrefab,
                new Vector3(
                    x,
                    2.5f,
                    z
                ),
                Quaternion.identity
            );
        trunk.transform.parent = tree.transform;
        for (var i = 0; i < numLeaves; i++)
        {
            var leaf = Instantiate(
                leafPrefab,
                Vector3.zero,
                RandomRotation()
            );
            leaf.transform.parent = tree.transform;
            leaf.transform.localPosition = new Vector3(
                Random.Range(x - leafRange, x + leafRange),
                Random.Range(5f - (leafRange / 2), 5f + (leafRange / 2)),
                Random.Range(z - leafRange, z + leafRange)
            );
        }
    }

    Quaternion RandomRotation()
    {
        float theta = 45f;
        return Quaternion.Euler(
            Random.Range(-theta, theta),
            Random.Range(-theta, theta),
            Random.Range(-theta, theta)
        );
    }

    void Update()
    {

    }
}
