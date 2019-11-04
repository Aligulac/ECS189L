using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arcanum
{
    public enum Spells { Explosion, BlackHole, Meteor}

    [RequireComponent(typeof(BlackHoleMaker))]
    [RequireComponent(typeof(ExplosionMaker))]
    public class SpellFactory : MonoBehaviour
    {
        public void BuildSpell(Spells type)
        {
            if(Spells.BlackHole == type)
            {
                var collection = GameObject.FindGameObjectsWithTag("BlackHole");
                if(collection.Length == 0)
                {
                    Debug.Log("we have 0 balckhole and create one");
                    var blackHole = this.GetComponent<BlackHoleMaker>().Make();
                    blackHole.transform.position = new Vector3(this.transform.position.x,
                        this.transform.position.y / 2, this.transform.position.z);
                }
                Debug.Log("we already have a blackhole");
            }
            else if (Spells.Explosion == type)
            {
                var fireball = this.GetComponent<ExplosionMaker>().Make();
                fireball.transform.position = this.transform.position;
            }
            else if (Spells.Meteor == type)
            {
                var fireball = this.GetComponent<MeteorMaker>().Make();
                fireball.transform.position = this.transform.position;
            }
        }

        public void Update()
        {
            if (Input.GetButtonDown("Jump"))
            {

                this.BuildSpell(Spells.BlackHole);
            }
            else if(Input.GetButtonDown("Fire1"))
            {
                this.BuildSpell(Spells.Explosion);
            }
            else if (Input.GetButtonDown("Fire2"))
            {
                this.BuildSpell(Spells.Meteor);
            }
         }

    }

}
