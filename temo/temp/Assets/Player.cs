using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Temp
{
    public class Player : MonoBehaviour
    {
        public float moveSpeed;
        public string itemName;
        public GameObject item;
        public bool hasWatering = false;
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            Vector3 direction = new Vector3(-horizontalInput, 0f, -verticalInput);
            transform.Translate(direction * moveSpeed * Time.deltaTime);

            if (hasWatering)
            {
                Vector3 playerPos = gameObject.transform.position;
                item = GameObject.Find(itemName);
                item.transform.position = new Vector3(playerPos.x - .25f, playerPos.y, playerPos.z);
            }
        }
    }
}

