using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent_Coletor : MonoBehaviour {

	public int recursos;
	UnityEngine.AI.NavMeshAgent navegador;

	// Use this for initialization
	void Start () {
		recursos = 0;
		navegador = GetComponent<UnityEngine.AI.NavMeshAgent> ();
	}

	// Update is called once per frame
	public void Update () {

	}

	public void MoverPara(Vector3 posicao) {
		navegador.SetDestination (posicao);
	}
}
