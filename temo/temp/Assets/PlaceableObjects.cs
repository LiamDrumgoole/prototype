using System;
using System.Drawing;
using TMPro;
using UnityEditor.UI;
using UnityEngine;
namespace Temp
{
    public class PlaceableObjects : MonoBehaviour
    {
        [SerializeField] private Camera playerCamera;
        [SerializeField] private Player player;
        // These check what layers the items are able to place on. 
        [SerializeField] private LayerMask placementCollider;
        [SerializeField] private LayerMask placementCheck;
        // Money
        [SerializeField] private float money;
        [SerializeField] private TextMeshProUGUI moneyText;
        private GameObject placingObjects;
        public GameObject[] plantPrefab;
        private int rotationCount = 0;
        private float itemCosts = 0;
        private void Start() { }
        public void RotatePos()
        {
            if(Input.GetKeyDown(KeyCode.Q))
            {
                rotationCount += 45;
            }
            if(Input.GetKeyDown(KeyCode.E))
            {
                rotationCount -= 45;
            }
        }
        private void Update()
        {
            moneyText.text = money.ToString();
            if(Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.E))
            {
                RotatePos();
                placingObjects.transform.rotation = Quaternion.Euler(0, rotationCount, 0);
            }
            if(placingObjects != null)
            {
                Ray camRay = playerCamera.ScreenPointToRay(Input.mousePosition);
                RaycastHit HitInfo;
                if(Physics.Raycast(camRay, out HitInfo, 100f, placementCollider))
                {
                    placingObjects.transform.position = HitInfo.point;
                }
                if(Input.GetMouseButtonDown(0) && HitInfo.collider.gameObject != null)
                {
                    if(!HitInfo.collider.gameObject.CompareTag("CantPlace"))
                    {
                        BoxCollider plantCollider = placingObjects.gameObject.GetComponent<BoxCollider>();
                        plantCollider.isTrigger = true;
                        Vector3 boxCenter = placingObjects.gameObject.transform.position + plantCollider.center;
                        Vector3 halfExtents = plantCollider.size / 2;
                        if(Physics.CheckBox(boxCenter, halfExtents, Quaternion.identity, placementCheck, QueryTriggerInteraction.Ignore))
                        {
                            plantCollider.isTrigger = false;
                            placingObjects = null;
                            money = money - itemCosts;
                        }
                    }
                }
            }
        }
        public void SetItemToPlace(GameObject plant)
        {
            if(plant.name == "Grass Patch")
                itemCosts = 100;
            if(plant.name == "Dirt Patch")
                itemCosts = 200;
            if(money >= itemCosts)
            {
                placingObjects = Instantiate(plant, Vector3.zero, Quaternion.identity);
            }
        }
    }
}