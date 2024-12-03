using System.Collections;
using System.Collections.Generic;
using Assets.WasapiAudio.Scripts.Unity;
using UnityEngine;

public class BuildingSpawn : MonoBehaviour
{
    public const int AMOUNT_BUILDINGS = 15;

    public WasapiAudioSource _WasapiAudioSource;

    public GameObject[] ModelBuilding;

    private GameObject[] Clones = new GameObject[AMOUNT_BUILDINGS + 1];

    public float AudioScale = 150;
    public float Power = 2;
    public int[] SpectrumBandRange = {
        5, 32
    };

    public float FallSpeed = 0.3F;

    public int MinFrequency = 200;
    public int MaxFrequency = 18000;

    public bool smoothFall = true;

    public int MaxColliderAttempts = 5;


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
            component.SpectrumSize = SpectrumBandRange[1];
            component.MinFrequency = MinFrequency;
            component.MaxFrequency = MaxFrequency;
            component.AudioScale = AudioScale;
            component.Power = Power;
            component.SpectrumBand = Random.Range(
                SpectrumBandRange[0], SpectrumBandRange[1]);
            component.smoothFall = smoothFall;
            component.fallSpeed = FallSpeed;

            building.SetActive(true);

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

                if (attempts > MaxColliderAttempts) {
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
