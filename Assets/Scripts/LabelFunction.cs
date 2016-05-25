using UnityEngine;
using System.Collections;

public class LabelFunction : MonoBehaviour {

	private InstantGuiElement myLabel;

    private int offsetRight = 0;
    private int offsetLeft = 0;
    private int offsetTop = 0;
    private int offsetBottom = 0;

    private int fontSize = 0;

	// Use this for initialization
	void Start () {
		myLabel = this.gameObject.GetComponent<InstantGuiElement> ();
        offsetRight = myLabel.offset.right;
        offsetLeft = myLabel.offset.left;
        offsetTop = myLabel.offset.top;
        offsetBottom = myLabel.offset.bottom;
        fontSize = myLabel.style.fontSize;
    }


	void updateLabel(){
        myLabel.offset.right = (int)(offsetRight * SharedValues.dpiScale);
        myLabel.offset.left = (int)(offsetLeft * SharedValues.dpiScale);
        myLabel.offset.top = (int)(offsetTop * SharedValues.dpiScale);
        myLabel.offset.bottom = (int)(offsetBottom * SharedValues.dpiScale);

        //		myLabel.fontSize = 100;
        //		myLabel.currentFont.fontSize = (int)(fontSize * SharedValues.dpiScale);
        switch (this.name) {
		case("LoadedTeam/Match_Label"):
			myLabel.text = "Loaded - Team: " + SharedValues.myTeam.teamNumber + " Match: " + SharedValues.myMatch.getMatchNumber ();
			break;

		case("LowBarCountAuto_Label"):
			myLabel.text = "" + SharedValues.myMatch.autoLowBarCount;
			break;
		case("Pos1CountAuto_Label"):
			myLabel.text = "" + SharedValues.getCount_auto (SharedValues.myMatch.defensePos1);
			break;
		case("Pos2CountAuto_Label"):
			myLabel.text = "" + SharedValues.getCount_auto (SharedValues.myMatch.defensePos2);
			break;
		case("Pos3CountAuto_Label"):
			myLabel.text = "" + SharedValues.getCount_auto (SharedValues.myMatch.defensePos3);
			break;
		case("PosMiddleCountAuto_Label"):
			myLabel.text = "" + SharedValues.getCount_auto (SharedValues.myMatch.defenseMiddle);
			break;

		case("LowBarCountTele_Label"):
			myLabel.text = "" + SharedValues.myMatch.teleLowBarCount;
			break;
		case("Pos1CountTele_Label"):
			myLabel.text = "" + SharedValues.getCount_tele (SharedValues.myMatch.defensePos1);
			break;
		case("Pos2CountTele_Label"):
			myLabel.text = "" + SharedValues.getCount_tele (SharedValues.myMatch.defensePos2);
			break;
		case("Pos3CountTele_Label"):
			myLabel.text = "" + SharedValues.getCount_tele (SharedValues.myMatch.defensePos3);
			break;
		case("PosMiddleCountTele_Label"):
			myLabel.text = "" + SharedValues.getCount_tele (SharedValues.myMatch.defenseMiddle);
			break;

		case("DefenseScore_Label"):
			switch (SharedValues.myMatch.defense) {
			case(0):
				myLabel.text = "Defense: Not Applicable";
				break;
			case(1):
				myLabel.text = "Defense: Poor";
				break;
			case(2):
				myLabel.text = "Defense: Decent";
				break;
			case(3):
				myLabel.text = "Defense: Great";
				break;
			}
			break;

		case("FileDir_Label"):
			myLabel.text = "File Path: " + SharedValues.fileDirectory;
			break;

		case("ScreenDPI_Label"):
			myLabel.text = "Screen DPI: " + Screen.dpi + " (" + SharedValues.dpiScale * 100 + "%)";
			break;

		case("DefenseTeamNumber1_Label"):
			myLabel.text = "Team: " + SharedValues.defenseTeamNumber1;
			break;
		case("DefenseTeamNumber2_Label"):
			myLabel.text = "Team: " + SharedValues.defenseTeamNumber2;
			break;
		case("DefenseTeamNumber3_Label"):
			myLabel.text = "Team: " + SharedValues.defenseTeamNumber3;
			break;
		case("Team1AverageDefensesCrossed_Label"):
			myLabel.text = "" + Team.getTeam(SharedValues.defenseTeamNumber1).avgDefensesCrossed();
			break;
		case("Team2AverageDefensesCrossed_Label"):
			myLabel.text = "" + Team.getTeam(SharedValues.defenseTeamNumber2).avgDefensesCrossed();
			break;
		case("Team3AverageDefensesCrossed_Label"):
			myLabel.text = "" + Team.getTeam(SharedValues.defenseTeamNumber3).avgDefensesCrossed();
			break;

		case("Team1AverageBallsScoredHigh_Label"):
			myLabel.text = "" + Team.getTeam(SharedValues.defenseTeamNumber1).avgBallsScoredHigh();
			break;
		case("Team2AverageBallsScoredHigh_Label"):
			myLabel.text = "" + Team.getTeam(SharedValues.defenseTeamNumber2).avgBallsScoredHigh();
			break;
		case("Team3AverageBallsScoredHigh_Label"):
			myLabel.text = "" + Team.getTeam(SharedValues.defenseTeamNumber3).avgBallsScoredHigh();
			break;

		case("Team1AverageBallsScoredLow_Label"):
			myLabel.text = "" + Team.getTeam(SharedValues.defenseTeamNumber1).avgBallsScoredLow();
			break;
		case("Team2AverageBallsScoredLow_Label"):
			myLabel.text = "" + Team.getTeam(SharedValues.defenseTeamNumber2).avgBallsScoredLow();
			break;
		case("Team3AverageBallsScoredLow_Label"):
			myLabel.text = "" + Team.getTeam(SharedValues.defenseTeamNumber3).avgBallsScoredLow();
			break;

		case("Team1AverageDefense_Label"):
			myLabel.text = "" + Team.getTeam(SharedValues.defenseTeamNumber1).avgDefensePlayed();
			break;
		case("Team2AverageDefense_Label"):
			myLabel.text = "" + Team.getTeam(SharedValues.defenseTeamNumber2).avgDefensePlayed();
			break;
		case("Team3AverageDefense_Label"):
			myLabel.text = "" + Team.getTeam(SharedValues.defenseTeamNumber3).avgDefensePlayed();
			break;

		case("Team1OPR_Label"):
			myLabel.text = "" + Team.getTeam(SharedValues.defenseTeamNumber1).calculateAverageOPR();
			break;
		case("Team2OPR_Label"):
			myLabel.text = "" + Team.getTeam(SharedValues.defenseTeamNumber2).calculateAverageOPR();
			break;
		case("Team3OPR_Label"):
			myLabel.text = "" + Team.getTeam(SharedValues.defenseTeamNumber3).calculateAverageOPR();
			break;

		case("Team1LowBarAverageDefenseCount_Label"):
			myLabel.text = Team.getTeam(SharedValues.defenseTeamNumber1).percentDefenseCrossed (Match.defenses.LowBar) + "%";
			break;
		case("Team1ChevalAverageDefenseCount_Label"):
			myLabel.text = Team.getTeam(SharedValues.defenseTeamNumber1).percentDefenseCrossed (Match.defenses.Cheval) + "%";
			break;
		case("Team1PortcullisAverageDefenseCount_Label"):
			myLabel.text = Team.getTeam(SharedValues.defenseTeamNumber1).percentDefenseCrossed (Match.defenses.Portcullis) + "%";
			break;
		case("Team1RampartsAverageDefenseCount_Label"):
			myLabel.text = Team.getTeam(SharedValues.defenseTeamNumber1).percentDefenseCrossed (Match.defenses.Ramparts) + "%";
			break;
		case("Team1RoughTerrainAverageDefenseCount_Label"):
			myLabel.text = Team.getTeam(SharedValues.defenseTeamNumber1).percentDefenseCrossed (Match.defenses.RoughTerrain) + "%";
			break;
		case("Team1MoatAverageDefenseCount_Label"):
			myLabel.text = Team.getTeam(SharedValues.defenseTeamNumber1).percentDefenseCrossed (Match.defenses.Moat) + "%";
			break;
		case("Team1RockWallAverageDefenseCount_Label"):
			myLabel.text = Team.getTeam(SharedValues.defenseTeamNumber1).percentDefenseCrossed (Match.defenses.RockWall) + "%";
			break;
		case("Team1SallyPortAverageDefenseCount_Label"):
			myLabel.text = Team.getTeam(SharedValues.defenseTeamNumber1).percentDefenseCrossed (Match.defenses.SallyPort) + "%";
			break;
		case("Team1DrawbridgeAverageDefenseCount_Label"):
			myLabel.text = Team.getTeam(SharedValues.defenseTeamNumber1).percentDefenseCrossed (Match.defenses.Drawbridge) + "%";
			break;

		case("Team2LowBarAverageDefenseCount_Label"):
			myLabel.text = Team.getTeam(SharedValues.defenseTeamNumber2).percentDefenseCrossed (Match.defenses.LowBar) + "%";
			break;
		case("Team2ChevalAverageDefenseCount_Label"):
			myLabel.text = Team.getTeam(SharedValues.defenseTeamNumber2).percentDefenseCrossed (Match.defenses.Cheval) + "%";
			break;
		case("Team2PortcullisAverageDefenseCount_Label"):
			myLabel.text = Team.getTeam(SharedValues.defenseTeamNumber2).percentDefenseCrossed (Match.defenses.Portcullis) + "%";
			break;
		case("Team2RampartsAverageDefenseCount_Label"):
			myLabel.text = Team.getTeam(SharedValues.defenseTeamNumber2).percentDefenseCrossed (Match.defenses.Ramparts) + "%";
			break;
		case("Team2RoughTerrainAverageDefenseCount_Label"):
			myLabel.text = Team.getTeam(SharedValues.defenseTeamNumber2).percentDefenseCrossed (Match.defenses.RoughTerrain) + "%";
			break;
		case("Team2MoatAverageDefenseCount_Label"):
			myLabel.text = Team.getTeam(SharedValues.defenseTeamNumber2).percentDefenseCrossed (Match.defenses.Moat) + "%";
			break;
		case("Team2RockWallAverageDefenseCount_Label"):
			myLabel.text = Team.getTeam(SharedValues.defenseTeamNumber2).percentDefenseCrossed (Match.defenses.RockWall) + "%";
			break;
		case("Team2SallyPortAverageDefenseCount_Label"):
			myLabel.text = Team.getTeam(SharedValues.defenseTeamNumber2).percentDefenseCrossed (Match.defenses.SallyPort) + "%";
			break;
		case("Team2DrawbridgeAverageDefenseCount_Label"):
			myLabel.text = Team.getTeam(SharedValues.defenseTeamNumber2).percentDefenseCrossed (Match.defenses.Drawbridge) + "%";
			break;

		case("Team3LowBarAverageDefenseCount_Label"):
			myLabel.text = Team.getTeam(SharedValues.defenseTeamNumber3).percentDefenseCrossed (Match.defenses.LowBar) + "%";
			break;
		case("Team3ChevalAverageDefenseCount_Label"):
			myLabel.text = Team.getTeam(SharedValues.defenseTeamNumber3).percentDefenseCrossed (Match.defenses.Cheval) + "%";
			break;
		case("Team3PortcullisAverageDefenseCount_Label"):
			myLabel.text = Team.getTeam(SharedValues.defenseTeamNumber3).percentDefenseCrossed (Match.defenses.Portcullis) + "%";
			break;
		case("Team3RampartsAverageDefenseCount_Label"):
			myLabel.text = Team.getTeam(SharedValues.defenseTeamNumber3).percentDefenseCrossed (Match.defenses.Ramparts) + "%";
			break;
		case("Team3RoughTerrainAverageDefenseCount_Label"):
			myLabel.text = Team.getTeam(SharedValues.defenseTeamNumber3).percentDefenseCrossed (Match.defenses.RoughTerrain) + "%";
			break;
		case("Team3MoatAverageDefenseCount_Label"):
			myLabel.text = Team.getTeam(SharedValues.defenseTeamNumber3).percentDefenseCrossed (Match.defenses.Moat) + "%";
			break;
		case("Team3RockWallAverageDefenseCount_Label"):
			myLabel.text = Team.getTeam(SharedValues.defenseTeamNumber3).percentDefenseCrossed (Match.defenses.RockWall) + "%";
			break;
		case("Team3SallyPortAverageDefenseCount_Label"):
			myLabel.text = Team.getTeam(SharedValues.defenseTeamNumber3).percentDefenseCrossed (Match.defenses.SallyPort) + "%";
			break;
		case("Team3DrawbridgeAverageDefenseCount_Label"):
			myLabel.text = Team.getTeam(SharedValues.defenseTeamNumber3).percentDefenseCrossed (Match.defenses.Drawbridge) + "%";
			break;

		case("AverageDefensesCrossed_Label"):
			myLabel.text = "Average\nDefenses\nCrossed";
			break;
		case("AverageBallsHigh_Label"):
			myLabel.text = "Average\nBalls\nScored\nHigh";
			break;
		case("AverageBallsLow_Label"):
			myLabel.text = "Average\nBalls\nScored\nLow";
			break;
		case("AverageDefense_Label"):
			myLabel.text = "Average\nDefense\nAbility";
			break;
        default:
                myLabel.style.fontSize = (int)(fontSize * SharedValues.dpiScale);
                break;
		}
	}
	
	// Update is called once per frame
	void Update () {
		updateLabel ();
	}
}
