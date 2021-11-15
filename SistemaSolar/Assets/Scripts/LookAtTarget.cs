using UnityEngine;
using System.Collections;

public class LookAtTarget : MonoBehaviour {

	static public GameObject target; // the target that the camera should look at
	public GameObject[] astros;

	void Start () {
		if (target == null) 
		{
			target = this.gameObject;
			Debug.Log ("LookAtTarget target not specified. Defaulting to parent GameObject");
		}
	}
	
	// Update is called once per frame
	void Update () {
		foreach (GameObject item in astros)
			if (item != target)
                item.GetComponent<AudioSource>().Pause();

		if (target != this.gameObject)
		{ 
			transform.LookAt(target.transform);
			if (!target.GetComponent<AudioSource>().isPlaying)
				target.GetComponent<AudioSource>().Play();
		}
		else
			if (!astros[0].GetComponent<AudioSource>().isPlaying)
				astros[0].GetComponent<AudioSource>().Play();
	}	
}