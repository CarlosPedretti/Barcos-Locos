using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IslandGenerator : MonoBehaviour
{
    [Header("General")]
    public Vector2 MaximunPoint;
    public Vector2 MinimunPoint;
    public Transform Player1, Player2;
    [Header("Islands")]
    public GameObject IslandPrefab;
    public Vector2 IslandScale;
    public Vector2Int NumberIslands;
    public float MinDistanceBetweenIslands;
    public Material[] IslandMats;
    [Header("Crates")]
    public GameObject CratePrefab;
    public Vector2Int NumberCrates;
    public float MinDistanceBetweenCrates;



    void Start()
    {
        int nIslands = Random.Range(NumberIslands.x, NumberIslands.y);
        Vector3[] currentPositionIslands = new Vector3[nIslands];
        for (int i = 0; i < nIslands; i++)
        {
            Vector3 pos;
            do
            {
                pos = new Vector3(Random.Range(MinimunPoint.x, MaximunPoint.x),
                    Random.Range(-2.0f, -4.0f),
                    Random.Range(MinimunPoint.y, MaximunPoint.y));

            } while (IsNear(currentPositionIslands, i, pos, MinDistanceBetweenIslands));

            float scale = Random.Range(IslandScale.x, IslandScale.y);

            GameObject island = Instantiate(IslandPrefab, pos, Quaternion.Euler(0.0f, Random.Range(0.0f, 360.0f), 0.0f), transform);
            island.transform.localScale = new Vector3(scale, scale, scale);
            island.GetComponentInChildren<MeshRenderer>().sharedMaterial = IslandMats[Random.Range(0, IslandMats.Length)];
            currentPositionIslands[i] = pos;

        }

        //Crates

        int nCrates = Random.Range(NumberCrates.x, NumberCrates.y);
        Vector3[] currentPositionCrates = new Vector3[nCrates];
        for (int i = 0; i < nCrates; i++)
        {
            Vector3 pos;
            do
            {
                pos = new Vector3(Random.Range(MinimunPoint.x, MaximunPoint.x),
                    1.9f,
                    Random.Range(MinimunPoint.y, MaximunPoint.y));

            } while (IsNear(currentPositionIslands, nIslands, pos, MinDistanceBetweenIslands + MinDistanceBetweenCrates) ||
                     IsNear(currentPositionCrates, i, pos, MinDistanceBetweenCrates));

            Instantiate(CratePrefab, pos, Quaternion.Euler(0.0f, Random.Range(0.0f, 360.0f), 0.0f), transform);
            currentPositionCrates[i] = pos;
        }

        bool IsNear(Vector3[] currentPositions, int current, Vector3 position, float minDistance)
        {
            if ((Player1.transform.position - position).sqrMagnitude < minDistance * minDistance) return true;
            if ((Player2.transform.position - position).sqrMagnitude < minDistance * minDistance) return true;
            for (int i = 0; i < current; ++i)
            {
                if ((currentPositions[i] - position).sqrMagnitude < minDistance * minDistance) return true;
            }
            return false;
        }


    }


    void Update()
    {
        
    }
}
