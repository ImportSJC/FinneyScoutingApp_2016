using UnityEngine;
using System.Collections;
using System;

public class ButtonFunction : MonoBehaviour {

	private InstantGuiButton myButton;
	private InstantGuiToggle myToggle;
	private InstantGuiList myList;

	static GameObject popup = null;

	private int offsetRight = 0;
	private int offsetLeft = 0;
	private int offsetTop = 0;
	private int offsetBottom = 0;

    private int fontSize = 25;

	// Use this for initialization
	void Start () {
        if (this.name.Contains ("Toggle")) {
			myToggle = this.GetComponent<InstantGuiToggle> ();
			offsetRight = myToggle.offset.right;
			offsetLeft = myToggle.offset.left;
			offsetTop = myToggle.offset.top;
			offsetBottom = myToggle.offset.bottom;
            fontSize = myToggle.style.fontSize;
		} else if (this.name.Contains ("List")) {
			myList = this.GetComponent<InstantGuiList> ();
			offsetRight = myList.offset.right;
			offsetLeft = myList.offset.left;
			offsetTop = myList.offset.top;
			offsetBottom = myList.offset.bottom;
            fontSize = myList.style.fontSize;
        }
        else {
			myButton = this.GetComponent<InstantGuiButton> ();
			offsetRight = myButton.offset.right;
			offsetLeft = myButton.offset.left;
			offsetTop = myButton.offset.top;
			offsetBottom = myButton.offset.bottom;
            fontSize = myButton.style.fontSize;
        }
    }

	void onButtonClick(){
        try {
            Vibration.Vibrate(20);
        }
        catch(Exception e)
        {
            print("Vibration not enabled on device");
        }
		switch(this.name){
		case("Add/Sub_Button"):
			SharedValues.addMode = !SharedValues.addMode;
			if (SharedValues.addMode) {
				myButton.text = "Current Mode: Add";
			} else {
				myButton.text = "Current Mode: Sub";
			}
			break;
		case("NextPage_Button"):
			if (SharedValues.screen == 0 && (SharedValues.tempTeamNumber.Equals ("") || SharedValues.tempMatchNumber.Equals("")
				|| SharedValues.myTeam.teamNumber == 0 && SharedValues.myMatch.getMatchNumber() == 0)) {
				Debug.Log ("Enter team and match first");
			} else {
				SharedValues.screen++;
			}
			break;
		case("PrevPage_Button"):
			SharedValues.screen--;
			break;
		case("AddTeam/Match_Button"):
			if (Team.validTeam () && !SharedValues.tempScoutName.Equals("")) {
				Team.addMatch ();
				SharedValues.screen++;
			}
			break;

		case("Pos1_Button"):
			popup.SetActive (true);
			popup.GetComponent<WindowFunction> ().initDefense (1, SharedValues.myMatch.defensePos1, SharedValues.visibleCategories);
			break;
		case("Pos2_Button"):
			popup.SetActive (true);
			popup.GetComponent<WindowFunction> ().initDefense (2, SharedValues.myMatch.defensePos2, SharedValues.visibleCategories);
			break;
		case("Pos3_Button"):
			popup.SetActive (true);
			popup.GetComponent<WindowFunction> ().initDefense (3, SharedValues.myMatch.defensePos3, SharedValues.visibleCategories);
			break;
		case("PosMiddle_Button"):
			popup.SetActive (true);
			popup.GetComponent<WindowFunction> ().initDefense (0, SharedValues.myMatch.defenseMiddle, SharedValues.visibleCategories);
			break;
		case("PopupDone_Button"):
			popup.GetComponent<WindowFunction> ().applyDefense ();
			popup.SetActive (false);
			break;
		case("PopupCancel_Button"):
			popup.SetActive (false);
			break;
		
		case("LowBarCountAuto_Button"):
			if (SharedValues.addMode) {
				SharedValues.myMatch.autoLowBarCount++;
			} else {
				SharedValues.myMatch.autoLowBarCount--;
			}
			break;
		case("LowBarCountTele_Button"):
			if (SharedValues.addMode) {
				SharedValues.myMatch.teleLowBarCount++;
			} else {
				SharedValues.myMatch.teleLowBarCount--;
			}
			break;
		case("Pos1CountAuto_Button"):
			SharedValues.alterCount_auto (SharedValues.myMatch.defensePos1);
			break;
		case("Pos2CountAuto_Button"):
			SharedValues.alterCount_auto (SharedValues.myMatch.defensePos2);
			break;
		case("Pos3CountAuto_Button"):
			SharedValues.alterCount_auto (SharedValues.myMatch.defensePos3);
			break;
		case("PosMiddleCountAuto_Button"):
			SharedValues.alterCount_auto (SharedValues.myMatch.defenseMiddle);
			break;

		case("Pos1CountTele_Button"):
			SharedValues.alterCount_tele (SharedValues.myMatch.defensePos1);
			break;
		case("Pos2CountTele_Button"):
			SharedValues.alterCount_tele (SharedValues.myMatch.defensePos2);
			break;
		case("Pos3CountTele_Button"):
			SharedValues.alterCount_tele (SharedValues.myMatch.defensePos3);
			break;
		case("PosMiddleCountTele_Button"):
			SharedValues.alterCount_tele (SharedValues.myMatch.defenseMiddle);
			break;
		case("SubmitMatch_Button"):
			SharedValues.findGameObject ("DefenseScore_List").GetComponent<InstantGuiList> ().selected = 0;
			SharedValues.myMatch.comment = SharedValues.tempComment;
			SharedValues.myMatch.scoutName = SharedValues.tempScoutName;
			SharedValues.myMatch.submitMatch ();
			SharedValues.resetTextBoxes ();
			SharedValues.myTeam = (Team)Team.teams [0];
			SharedValues.myMatch = SharedValues.myTeam.getMatch (0);
			SharedValues.screen = 0;
			break;

		case("TopCountAuto_Button"):
			SharedValues.addSubMode (ref SharedValues.myMatch.autoTowerTopCount);
			break;
		case("BottomCountAuto_Button"):
			SharedValues.addSubMode (ref SharedValues.myMatch.autoTowerBottomCount);
			break;
		case("TopCountTele_Button"):
			SharedValues.addSubMode (ref SharedValues.myMatch.teleTowerTopCount);
			break;
		case("BottomCountTele_Button"):
			SharedValues.addSubMode (ref SharedValues.myMatch.teleTowerBottomCount);
			break;

		case("Capture_Toggle"):
			SharedValues.myMatch.capture = !SharedValues.myMatch.capture;
			break;
		case("Hang_Toggle"):
			SharedValues.myMatch.hang = !SharedValues.myMatch.hang;
			break;
		case("autoApproachedDefense_Toggle"):
			SharedValues.myMatch.autoApproachedDefense = !SharedValues.myMatch.autoApproachedDefense;
			break;

		case("IncreaseDPI_Button"):
			SharedValues.increaseDPI ();
			break;
		case("DecreaseDPI_Button"):
			SharedValues.decreaseDPI ();
			break;

		case("FieldMode_Button"):
			SharedValues.screen = 10;
			Team.loadAllMatches ();
			break;
		case("ScoutMode_Button"):
			SharedValues.screen = 0;
			break;
		case("ResetFieldMode_Button"):
			DefenseSharedValues.resetFieldMode ();
			break;
		case("ResetDefenseSelection_Button"):
			DefenseSharedValues.resetDefenseSelection ();
			break;
		case("FieldModeDone_Button"):
			DefenseSharedValues.resetFieldMode ();
			break;

		case("FieldLoadMatch_Button"):
			SharedValues.loadFieldMatch (int.Parse (SharedValues.tempMatchNumberField));
			break;
		}
	}

	void updateButtons(){
		if (myButton != null) {
            myButton.offset.right = (int)(offsetRight * SharedValues.dpiScale);
            myButton.offset.left = (int)(offsetLeft * SharedValues.dpiScale);
            myButton.offset.top = (int)(offsetTop * SharedValues.dpiScale);
            myButton.offset.bottom = (int)(offsetBottom * SharedValues.dpiScale);
            myButton.style.fontSize = (int)(fontSize * SharedValues.dpiScale);
        } else if (myToggle != null) {
            myToggle.offset.right = (int)(offsetRight * SharedValues.dpiScale);
            myToggle.offset.left = (int)(offsetLeft * SharedValues.dpiScale);
			myToggle.offset.top = (int)(offsetTop * SharedValues.dpiScale);
			myToggle.offset.bottom = (int)(offsetBottom * SharedValues.dpiScale);
            myToggle.style.fontSize = (int)(fontSize * SharedValues.dpiScale);
        } else if (myList != null) {
			myList.offset.right = (int)(offsetRight * SharedValues.dpiScale);
			myList.offset.left = (int)(offsetLeft * SharedValues.dpiScale);
			myList.offset.top = (int)(offsetTop * SharedValues.dpiScale);
			myList.offset.bottom = (int)(offsetBottom * SharedValues.dpiScale);
            myList.style.fontSize = (int)(fontSize * SharedValues.dpiScale);
        }
		switch (this.name) {
		case("NextPage_Button"):
			if ((SharedValues.screen < 4 || (SharedValues.screen < 13 && SharedValues.screen >= 10)) && myButton.disabled) {
				myButton.disabled = false;
			} else if (((SharedValues.screen >= 4 && SharedValues.screen < 10) || SharedValues.screen >= 13) && !myButton.disabled) {
				myButton.disabled = true;
				myButton.pressed = false;
			}
			break;
		case("PrevPage_Button"):
			if ((SharedValues.screen != 0  && SharedValues.screen != 10) && myButton.disabled) {
				myButton.disabled = false;
			} else if((SharedValues.screen == 0 || SharedValues.screen == 10) && !myButton.disabled) {
				myButton.disabled = true;
				myButton.pressed = false;
			}
			break;

		case("Pos1_Button"):
			myButton.style.main.texture = SharedValues.setPosButtonImage (SharedValues.myMatch.defensePos1);
			break;
		case("Pos2_Button"):
			myButton.style.main.texture = SharedValues.setPosButtonImage (SharedValues.myMatch.defensePos2);
			break;
		case("Pos3_Button"):
			myButton.style.main.texture = SharedValues.setPosButtonImage (SharedValues.myMatch.defensePos3);
			break;
		case("PosMiddle_Button"):
			myButton.style.main.texture = SharedValues.setPosButtonImage (SharedValues.myMatch.defenseMiddle);
			break;

		case("Pos1CountAuto_Button"):
			myButton.style.main.texture = SharedValues.setPosButtonImage (SharedValues.myMatch.defensePos1);
			break;
		case("Pos2CountAuto_Button"):
			myButton.style.main.texture = SharedValues.setPosButtonImage (SharedValues.myMatch.defensePos2);
			break;
		case("Pos3CountAuto_Button"):
			myButton.style.main.texture = SharedValues.setPosButtonImage (SharedValues.myMatch.defensePos3);
			break;
		case("PosMiddleCountAuto_Button"):
			myButton.style.main.texture = SharedValues.setPosButtonImage (SharedValues.myMatch.defenseMiddle);
			break;

		case("Pos1CountTele_Button"):
			myButton.style.main.texture = SharedValues.setPosButtonImage (SharedValues.myMatch.defensePos1);
			break;
		case("Pos2CountTele_Button"):
			myButton.style.main.texture = SharedValues.setPosButtonImage (SharedValues.myMatch.defensePos2);
			break;
		case("Pos3CountTele_Button"):
			myButton.style.main.texture = SharedValues.setPosButtonImage (SharedValues.myMatch.defensePos3);
			break;
		case("PosMiddleCountTele_Button"):
			myButton.style.main.texture = SharedValues.setPosButtonImage (SharedValues.myMatch.defenseMiddle);
			break;

		case("TopCountAuto_Button"):
			myButton.text = "Top: " + SharedValues.myMatch.autoTowerTopCount;
			break;
		case("BottomCountAuto_Button"):
			myButton.text = "Bottom: " + SharedValues.myMatch.autoTowerBottomCount;
			break;
		case("TopCountTele_Button"):
			myButton.text = "Top: " + SharedValues.myMatch.teleTowerTopCount;
			break;
		case("BottomCountTele_Button"):
			myButton.text = "Bottom: " + SharedValues.myMatch.teleTowerBottomCount;
			break;

		case("Capture_Toggle"):
			myToggle.check = SharedValues.myMatch.capture;
			break;
		case("Hang_Toggle"):
			myToggle.check = SharedValues.myMatch.hang;
			break;
		case("autoApproachedDefense_Toggle"):
			myToggle.check = SharedValues.myMatch.autoApproachedDefense;
			break;

		case("DefenseScore_List"):
			SharedValues.myMatch.defense = myList.selected;
			break;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (popup == null) {
			popup = SharedValues.findGameObject("SelectDefense_Popup");
			popup.SetActive (false);
		}

		updateButtons ();
		if (myButton != null && myButton.activated) {
			onButtonClick ();
		}

		if (myToggle != null && myToggle.activated) {
			onButtonClick ();
		}

		if (myList != null && myList.activated) {
			onButtonClick ();
		}
	}
}
