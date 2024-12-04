using System.Collections;
using System.Collections.Generic;
using Assets.WasapiAudio.Scripts.Unity;
using UnityEngine;


public class BuildingSpawn : MonoBehaviour
{
    public const int AMOUNT_BUILDINGS = 20;

    public WasapiAudioSource _WasapiAudioSource;

    public GameObject[] ModelBuilding;

    private GameObject[] Clones = new GameObject[AMOUNT_BUILDINGS + 1];

    public List<Vector3> ScaleGameObject = new List<Vector3>();

    public List<float> AudioScale = new List<float>();
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
        for (int i = 0; i < ModelBuilding.Length; i++) {
            if (ScaleGameObject.Count <= i) {
                ScaleGameObject.Add(new Vector3(10.0F, 0.0F, 10.0F));
            }
            if (AudioScale.Count <= i) {
                AudioScale.Add(150);
            }
        }

        for (int i = 0; i < ModelBuilding.Length; i++) {
            GameObject model = ModelBuilding[i];

            model.SetActive(false);
            model.transform.localScale = ScaleGameObject[i];
        }

        for (int i = 0; i < AMOUNT_BUILDINGS; i++) {
            //var rotation = Quaternion.Euler(-90, 0, 0);
            var rotation = Quaternion.identity;

            int index = Random.Range(0, ModelBuilding.Length);
            var building = Instantiate(
                ModelBuilding[index]) as GameObject;
            building.name = building.name + '-' + i;
            PlaceRandomly(building);

            building.AddComponent<BoxCollider>();

            var component = building.AddComponent<ReactBehaviourY>();
            component.WasapiAudioSource = _WasapiAudioSource;
            component.SpectrumSize = SpectrumBandRange[1];
            component.MinFrequency = MinFrequency;
            component.MaxFrequency = MaxFrequency;
            component.AudioScale = (float)1.2*AudioScale[index];
            // component.AudioScale = AudioScale[index];

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
