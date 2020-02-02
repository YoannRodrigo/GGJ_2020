#region

using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

#endregion

public class HoleParticleSystem : MonoBehaviour
{
    private void Awake()
    {
        switch (difficulty)
        {
            case ObjectDifficulty.easy:
                maxHoles = Random.Range(2, 4);
                break;
            case ObjectDifficulty.normal:
                maxHoles = Random.Range(4, 6);
                break;
            case ObjectDifficulty.hard:
                maxHoles = Random.Range(6, 8);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }

        for (int i = 0; i <= maxHoles; i++)
        {
            int randomChildIndex = Random.Range(0, transform.childCount);
            while (indexAlreadyChosen.Contains(randomChildIndex))
            {
                randomChildIndex = Random.Range(0, transform.childCount);
            }

            indexAlreadyChosen.Add(randomChildIndex);
            holeTransformList.Add(transform.GetChild(randomChildIndex));
        }

        FindObjectOfType<GameCanvasManager>().currentNbHoleMax = maxHoles;
        FindObjectOfType<GameCanvasManager>().currentNbHoleFix = 0;

        foreach (Transform holeTransform in holeTransformList)
        {
            Instantiate(objectToRemovePrefab, holeTransform.position, holeTransform.rotation, holeTransform);
        }
    }

    #region Variables

    public ObjectDifficulty difficulty;

    [SerializeField] private List<Transform> holeTransformList = new List<Transform>();

    private readonly HashSet<int> indexAlreadyChosen = new HashSet<int>();
    [SerializeField] private GameObject objectToRemovePrefab;
    private int maxHoles;

    #endregion
}