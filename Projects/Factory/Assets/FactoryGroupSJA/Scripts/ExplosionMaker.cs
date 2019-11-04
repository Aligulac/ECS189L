using SJA;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SJA
{
    public class ExplosionMaker : MonoBehaviour, IFactorySpell
    {
        [SerializeField] private GameObject prefab;

        public void Start()
        {
        }

        public GameObject Make()
        {
            GameObject newGameObject = Instantiate(prefab, gameObject.transform);
            return newGameObject;
        }
    }
}
