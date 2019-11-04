using SJA;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SJA
{
    public class BlackHoleMaker : MonoBehaviour, IFactorySpell
    {
        [SerializeField] private GameObject prefab;

        public void Start()
        {

        }

        public GameObject Make()
        {
            Debug.Log("here");
            GameObject newGameObject = Instantiate(prefab);
            return newGameObject;
        }
    }
}