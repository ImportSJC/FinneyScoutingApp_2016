using UnityEngine;
using System.Collections;



public class WindowFunction : MonoBehaviour {

	private Match.defenses tempDefense;

	private int position;

	// Use this for initialization
	void Start () {
		
	}

	public void initDefense(int myPos, Match.defenses setDef){
		position = myPos;
		tempDefense = setDef;
		resetDefenseToggles ();
		switch (setDef) {
		case(Match.defenses.Cheval):
			GameObject.Find ("Cheval_Toggle").GetComponent<InstantGuiToggle>().check = true;
			break;
		case(Match.defenses.Drawbridge):
			GameObject.Find ("Drawbridge_Toggle").GetComponent<InstantGuiToggle>().check = true;
			break;
		case(Match.defenses.Moat):
			GameObject.Find ("Moat_Toggle").GetComponent<InstantGuiToggle>().check = true;
			break;
		case(Match.defenses.Portcullis):
			GameObject.Find ("Portcullis_Toggle").GetComponent<InstantGuiToggle>().check = true;
			break;
		case(Match.defenses.Ramparts):
			GameObject.Find ("Ramparts_Toggle").GetComponent<InstantGuiToggle>().check = true;
			break;
		case(Match.defenses.RockWall):
			GameObject.Find ("RockWall_Toggle").GetComponent<InstantGuiToggle>().check = true;
			break;
		case(Match.defenses.RoughTerrain):
			GameObject.Find ("RoughTerrain_Toggle").GetComponent<InstantGuiToggle>().check = true;
			break;
		case(Match.defenses.SallyPort):
			GameObject.Find ("SallyPort_Toggle").GetComponent<InstantGuiToggle>().check = true;
			break;
		case(Match.defenses.None):
			tempDefense = Match.defenses.None;
			break;
		}
	}

	public void initDefense(int myPos, Match.defenses setDef, string activeCategories){
		position = myPos;
		tempDefense = setDef;
		resetDefenseToggles ();

		if (!activeCategories.Contains ("A")) {
			SharedValues.findGameObject ("Cheval_Toggle").SetActive (false);
			SharedValues.findGameObject ("Portcullis_Toggle").SetActive (false);
		}

		if (!activeCategories.Contains ("B")) {
			SharedValues.findGameObject ("Moat_Toggle").SetActive (false);
			SharedValues.findGameObject ("Ramparts_Toggle").SetActive (false);
		}

		if (!activeCategories.Contains ("C")) {
			SharedValues.findGameObject ("Drawbridge_Toggle").SetActive (false);
			SharedValues.findGameObject ("SallyPort_Toggle").SetActive (false);
		}

		if (!activeCategories.Contains ("D")) {
			SharedValues.findGameObject ("RockWall_Toggle").SetActive (false);
			SharedValues.findGameObject ("RoughTerrain_Toggle").SetActive (false);
		}

		switch (setDef) {
		case(Match.defenses.Cheval):
			if (SharedValues.visibleCategories.Contains ("A")) {
				GameObject.Find ("Cheval_Toggle").GetComponent<InstantGuiToggle>().check = true;
			}
			break;
		case(Match.defenses.Drawbridge):
			if (SharedValues.visibleCategories.Contains ("C")) {
				GameObject.Find ("Drawbridge_Toggle").GetComponent<InstantGuiToggle> ().check = true;
			}
			break;
		case(Match.defenses.Moat):
			if (SharedValues.visibleCategories.Contains ("B")) {
				GameObject.Find ("Moat_Toggle").GetComponent<InstantGuiToggle> ().check = true;
			}
			break;
		case(Match.defenses.Portcullis):
			if (SharedValues.visibleCategories.Contains ("A")) {
				GameObject.Find ("Portcullis_Toggle").GetComponent<InstantGuiToggle> ().check = true;
			}
			break;
		case(Match.defenses.Ramparts):
			if (SharedValues.visibleCategories.Contains ("B")) {
				GameObject.Find ("Ramparts_Toggle").GetComponent<InstantGuiToggle> ().check = true;
			}
			break;
		case(Match.defenses.RockWall):
			if (SharedValues.visibleCategories.Contains ("D")) {
				GameObject.Find ("RockWall_Toggle").GetComponent<InstantGuiToggle> ().check = true;
			}
			break;
		case(Match.defenses.RoughTerrain):
			if (SharedValues.visibleCategories.Contains ("D")) {
				GameObject.Find ("RoughTerrain_Toggle").GetComponent<InstantGuiToggle> ().check = true;
			}
			break;
		case(Match.defenses.SallyPort):
			if (SharedValues.visibleCategories.Contains ("C")) {
				GameObject.Find ("SallyPort_Toggle").GetComponent<InstantGuiToggle> ().check = true;
			}
			break;
		case(Match.defenses.None):
			tempDefense = Match.defenses.None;
			break;
		}
	}

	public void resetDefenseToggles(){
		SharedValues.findGameObject ("Cheval_Toggle").SetActive (true);
		SharedValues.findGameObject ("Drawbridge_Toggle").SetActive (true);
		SharedValues.findGameObject ("Moat_Toggle").SetActive (true);
		SharedValues.findGameObject ("Portcullis_Toggle").SetActive (true);
		SharedValues.findGameObject ("Ramparts_Toggle").SetActive (true);
		SharedValues.findGameObject ("RockWall_Toggle").SetActive (true);
		SharedValues.findGameObject ("RoughTerrain_Toggle").SetActive (true);
		SharedValues.findGameObject ("SallyPort_Toggle").SetActive (true);
		GameObject.Find ("Cheval_Toggle").GetComponent<InstantGuiToggle> ().check = false;
		GameObject.Find ("Drawbridge_Toggle").GetComponent<InstantGuiToggle>().check = false;
		GameObject.Find ("Moat_Toggle").GetComponent<InstantGuiToggle>().check = false;
		GameObject.Find ("Portcullis_Toggle").GetComponent<InstantGuiToggle>().check = false;
		GameObject.Find ("Ramparts_Toggle").GetComponent<InstantGuiToggle>().check = false;
		GameObject.Find ("RockWall_Toggle").GetComponent<InstantGuiToggle>().check = false;
		GameObject.Find ("RoughTerrain_Toggle").GetComponent<InstantGuiToggle>().check = false;
		GameObject.Find ("SallyPort_Toggle").GetComponent<InstantGuiToggle>().check = false;
	}

	public void applyDefense(){
		if (SharedValues.findGameObject ("Cheval_Toggle") != null && SharedValues.findGameObject ("Cheval_Toggle").GetComponent<InstantGuiToggle> ().check) {
			completeApply(Match.defenses.Cheval);
			SharedValues.visibleCategories = SharedValues.visibleCategories.Replace ("A", "");
		} else if (SharedValues.findGameObject ("Drawbridge_Toggle") != null && SharedValues.findGameObject ("Drawbridge_Toggle").GetComponent<InstantGuiToggle> ().check) {
			completeApply(Match.defenses.Drawbridge);
			SharedValues.visibleCategories = SharedValues.visibleCategories.Replace ("C", "");
		} else if (SharedValues.findGameObject ("Moat_Toggle") != null && SharedValues.findGameObject ("Moat_Toggle").GetComponent<InstantGuiToggle> ().check) {
			completeApply(Match.defenses.Moat);
			SharedValues.visibleCategories = SharedValues.visibleCategories.Replace ("B", "");
		} else if (SharedValues.findGameObject ("Portcullis_Toggle") != null && SharedValues.findGameObject ("Portcullis_Toggle").GetComponent<InstantGuiToggle> ().check) {
			completeApply(Match.defenses.Portcullis);
			SharedValues.visibleCategories = SharedValues.visibleCategories.Replace ("A", "");
		} else if (SharedValues.findGameObject ("Ramparts_Toggle") != null && SharedValues.findGameObject ("Ramparts_Toggle").GetComponent<InstantGuiToggle> ().check) {
			completeApply(Match.defenses.Ramparts);
			SharedValues.visibleCategories = SharedValues.visibleCategories.Replace ("B", "");
		} else if (SharedValues.findGameObject ("RockWall_Toggle") != null && SharedValues.findGameObject ("RockWall_Toggle").GetComponent<InstantGuiToggle> ().check) {
			completeApply(Match.defenses.RockWall);
			SharedValues.visibleCategories = SharedValues.visibleCategories.Replace ("D", "");
		} else if (SharedValues.findGameObject ("RoughTerrain_Toggle") != null && SharedValues.findGameObject ("RoughTerrain_Toggle").GetComponent<InstantGuiToggle> ().check) {
			completeApply(Match.defenses.RoughTerrain);
			SharedValues.visibleCategories = SharedValues.visibleCategories.Replace ("D", "");
		} else if (SharedValues.findGameObject ("SallyPort_Toggle") != null && SharedValues.findGameObject ("SallyPort_Toggle").GetComponent<InstantGuiToggle> ().check) {
			completeApply(Match.defenses.SallyPort);
			SharedValues.visibleCategories = SharedValues.visibleCategories.Replace ("C", "");
		}
	}

	private void completeApply(Match.defenses myDefense){
		switch (position) {
		case(0):
			SharedValues.myMatch.defenseMiddle = myDefense;
			break;
		case(1):
			SharedValues.myMatch.defensePos1 = myDefense;
			break;
		case(2):
			SharedValues.myMatch.defensePos2 = myDefense;
			break;
		case(3):
			SharedValues.myMatch.defensePos3 = myDefense;
			break;
		}
	}

	// Update is called once per frame
	void Update () {
	
	}
}
