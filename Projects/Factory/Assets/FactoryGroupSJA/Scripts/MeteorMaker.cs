﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SJA
{

    public class MeteorMaker : MonoBehaviour, IFactorySpell
    {
        [SerializeField] private GameObject prefab;

        public GameObject Make()
        {
            var newGameObject = Instantiate(this.prefab);
            return newGameObject;
        }
    }
}
