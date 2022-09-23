using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Temp
{
    public class Item : MonoBehaviour
    {
        [SerializeField] private string itemName;
        public Player playerBools;
        private bool inTrigger = false;
        private void Update()
        {
            if (inTrigger)
            {
                if (Input.GetKeyDown(KeyCode.Q))
                {
                    playerBools.hasWatering = true;
                    playerBools.itemName = itemName;
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

    


