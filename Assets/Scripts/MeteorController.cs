using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MeteorController : MonoBehaviour {

	public List<GameObject> AsteroidPrefabs;
	public List<Material> AsteroidMaterials;

	public GameObject Debrees;
	public GameObject Explosion;
	public GameObject Lava;

	public float initthreshold = 10f;
	public float thresholdfactor = 0.95f;

	public float spawndistance = 150f;

	public float maxspeed = 10f;

	public float maxangspeed = 5f;

	public float mininterval = 0.3f;

	int asteroidcounter;
	float maintimmer;
	float mainthreshold;
	GameObject Planet;

	public float min_distance = 100; 


	// Use this for initialization
	void Start () {
		Planet=GameObject.FindGameObjectWithTag("Planet");
		mainthreshold = initthreshold;
		maintimmer = 0;
		asteroidcounter = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
		maintimmer += Time.deltaTime;

		if (maintimmer > mainthreshold) {
			maintimmer -= mainthreshold;
			mainthreshold *= thresholdfactor;
			if (mainthreshold < mininterval)
				mainthreshold = mininterval;
			asteroidcounter++;
			SpawnAsteroid ();
		}

	}

	void SpawnAsteroid ()
	{
		GameObject asteroid = AsteroidPrefabs[Random.Range(0,AsteroidPrefabs.Count)];
		Material material = AsteroidMaterials[Random.Range(0,AsteroidMaterials.Count)];
		Vector3 Position = new Vector3();
		Vector3 scale = new Vector3 ();
		scale.x = Random.Range (0.5f, 1f);
		scale.y = Random.Range (0.5f, 1f);
		scale.z = Random.Range (0.5f, 1f);
		float massscale = scale.x * scale.y * scale.y;
		Position = RandomMeteorPosition();
		GameObject newasteroid = Instantiate (asteroid, Position, Random.rotation);
		scale.x = scale.x * newasteroid.transform.localScale.x;
		scale.y = scale.y * newasteroid.transform.localScale.y;
		scale.z = scale.z * newasteroid.transform.localScale.z;

		newasteroid.GetComponent<MeshRenderer> ().material = material;
		newasteroid.transform.localScale = scale;
		newasteroid.GetComponent<Rigidbody> ().mass = 5 * massscale;

		Vector3 velo = new Vector3();

		velo = (Random.rotationUniform * Vector3.forward) * Random.Range(0,maxspeed);
		newasteroid.GetComponent<Rigidbody> ().velocity = velo;
		newasteroid.GetComponent<Rigidbody> ().angularVelocity = Random.rotationUniform * Vector3.forward * Random.Range(0,maxangspeed);


	}

	Vector3 RandomMeteorPosition()
	{
		
		Vector3 Position = new Vector3();
		Position = (Random.rotationUniform * Vector3.forward) * spawndistance;
		Position = Position + Planet.transform.position;
		return Position;
	}


}
