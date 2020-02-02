using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class HoleParticleSystem : MonoBehaviour
{
    #region Variables
    
    public ObjectDifficulty difficulty;
    [SerializeField]
    private List<Transform> holeTransformList = new List<Transform>();
    private HashSet<int> indexAlreadyChosen = new HashSet<int>();
    [SerializeField] private GameObject objectToRemovePrefab;
    private int maxHoles;
    #endregion

    private void Awake() {
        switch (difficulty)
        {
            case ObjectDifficulty.easy:
                maxHoles = Random.Range(2, 4);
                break;
            case ObjectDifficulty.normal:
                maxHoles = Random.Range(4, 6);
                break;
            case ObjectDifficulty.hard :
                maxHoles = Random.Range(6, 8);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
        for (int i = 0; i <= maxHoles; i++) {
            int randomChildIndex = Random.Range(0, transform.childCount);
            while (indexAlreadyChosen.Contains(randomChildIndex)) {
                randomChildIndex = Random.Range(0, transform.childCount);
            }

            indexAlreadyChosen.Add(randomChildIndex);
            holeTransformList.Add(transform.GetChild(randomChildIndex));
        }

        foreach (Transform holeTransform in holeTransformList)
        {
            Instantiate(objectToRemovePrefab, holeTransform.position, holeTransform.rotation, holeTransform);
        }
    }
}
