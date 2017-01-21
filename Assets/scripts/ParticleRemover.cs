using UnityEngine;
using System.Collections;

public class ParticleRemover : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{
		Destroy (gameObject, 5);
	}
	

}
