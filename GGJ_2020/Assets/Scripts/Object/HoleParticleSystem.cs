using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleParticleSystem : MonoBehaviour
{
    #region Variables
    [SerializeField]
    private List<Transform> holeTransformList = new List<Transform>();
    private HashSet<int> indexAlreadyChosen = new HashSet<int>();
    [SerializeField] private GameObject objectToRemovePrefab;
    public int maxHoles;
    #endregion

    private void Awake() {
        for (int i = 0; i < maxHoles; i++) {
            int randomChildIndex = UnityEngine.Random.Range(0, transform.childCount);
            while (indexAlreadyChosen.Contains(randomChildIndex)) {
                randomChildIndex = UnityEngine.Random.Range(0, transform.childCount);
            }

            indexAlreadyChosen.Add(randomChildIndex);
            holeTransformList.Add(transform.GetChild(randomChildIndex));
        }

        foreach (Transform holeTransform in holeTransformList)
        {
            Instantiate(objectToRemovePrefab, holeTransform.position, holeTransform.rotation, holeTransform);
            holeTransform.GetComponent<ParticleSystem>().Play();
        }
    }
}
