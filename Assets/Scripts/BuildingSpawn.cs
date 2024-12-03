using System.Collections;
using System.Collections.Generic;
using Assets.WasapiAudio.Scripts.Unity;
using UnityEngine;

public class BuildingSpawn : MonoBehaviour
{
    public const int AMOUNT_BUILDINGS = 15;

    public WasapiAudioSource _WasapiAudioSource;

    public GameObject[] ModelBuilding;

    public GameObject[] Clones = new GameObject[AMOUNT_BUILDINGS + 1];

    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject model in ModelBuilding) {
            model.SetActive(false);
            model.transform.localScale = new Vector3(10.0F, 0.0F, 10.0F);
        }

        for (int i = 0; i < AMOUNT_BUILDINGS; i++) {
            //var rotation = Quaternion.Euler(-90, 0, 0);
            var rotation = Quaternion.identity;

            var building = Instantiate(
                ModelBuilding[Random.Range(0, ModelBuilding.Length)]) as GameObject;
            building.name = building.name + '-' + i;
            PlaceRandomly(building);

            building.AddComponent<BoxCollider>();

            var component = building.AddComponent<ReactBehaviourY>();
            component.WasapiAudioSource = _WasapiAudioSource;
            component.SpectrumSize = 32;
            component.MinFrequency = 200;
            component.MaxFrequency = 18000;
            component.AudioScale = 150;
            component.Power = 2;
            component.SpectrumBand = Random.Range(5, 32);
            component.smoothFall = true;
            component.fallSpeed = 0.3F;

            building.SetActive(true);


            int maxAttempts = 5;
            int attempts = 0;
            while (true) {
                PlaceRandomly(building);
                bool noIntersect = true;

                foreach (GameObject clone in Clones) {
                    Collider collider1 = null, collider2 = null;

                    if (building != null) collider1 = building.GetComponent<Collider>();

                    if (clone != null) collider2 = clone.GetComponent<Collider>();

                    if (collider1 != null && clone != null) {
                        if (collider1.bounds.Intersects(collider2.bounds)) {
                            noIntersect = false;
                            attempts++;
                            Debug.Log("Bounds intersecting");
                        }
                    }
                }

                if (attempts > maxAttempts) {
                    break;
                }

                if (noIntersect) {
                    break;
                }
            }

            Clones[i] = building;
        }
    }

    private void PlaceRandomly(GameObject go) {
        var x = Random.Range(-200, 200);
        var z = Random.Range(0, 200);
        go.gameObject.transform.position = new Vector3(x, -0.05F, z);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
