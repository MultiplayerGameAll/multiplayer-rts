using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrulha : MonoBehaviour {
	//Controle de navegacao
	public Transform[] points;
	private int destino = 0;
	private UnityEngine.AI.NavMeshAgent agent;

	//Controle da FSM (Máquina de Estados)
	private Animator fsm;
	private GameObject villager;

	//Usado para verificar LOS
	private Ray ray;
	private RaycastHit hit;
	private Vector3 checkDirection;


	void Start () {
		agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
		agent.autoBraking = false;

		fsm = GetComponent<Animator> ();
		villager = GameObject.Find ("Agent");
	}


	public void ProximoPonto() {
		if (points.Length == 0)	return;
		agent.destination = points [destino].position;
		destino = (destino + 1) % points.Length;
	}

	void Update() {
		float distPlayer = Vector3.Distance (gameObject.transform.position, villager.transform.position);
		fsm.SetFloat ("distancia", distPlayer);
		//Debug.Log("Distância:" + fsm.GetFloat("distancia"));

		checkDirection = villager.transform.position - transform.position;
		ray = new Ray(transform.position, checkDirection);
		if (Physics.Raycast(ray, out hit)) {
			if(hit.collider.gameObject == villager){
				fsm.SetBool("visivel", true);
			} else {
				fsm.SetBool("visivel", false);
			}
		} else {
			fsm.SetBool("visivel", false);
		}

	}
}

