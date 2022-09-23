using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Temp
{
    public class Dirt : MonoBehaviour
    {
        [SerializeField] private GameObject plant;
        public Player playerBools;
        private bool inTrigger;

        // Update is called once per frame
        void Update()
        {
            if (inTrigger)
            {
                if (playerBools.hasWatering && Input.GetKeyDown(KeyCode.Q))
                {
                    Instantiate(plant, transform.position, transform.rotation);
                }
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            inTrigger = true;
        }

        private void OnTriggerExit(Collider other)
        {
            inTrigger = false;
        }
    }
}
