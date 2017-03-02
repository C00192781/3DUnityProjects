using UnityEngine;
using System.Collections;

public class FormationInvader : MonoBehaviour {

	FormationController formationController;
    //public Boundary boundary;

    void Start() {
        // find the formation controller
        formationController = transform.parent.gameObject.GetComponent<FormationController>();
	}

	// Update is called once per frame
	void Update () {
		float x = transform.position.x;

		if (x <= formationController.leftEdge)
        {
            formationController.MoveRight();
		}
        else if (x >= formationController.rightEdge)
        {
            formationController.MoveLeft();
		}
	}
}
