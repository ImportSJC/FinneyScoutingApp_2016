using UnityEngine;
using System.Collections;
using System.IO;
using System;

public class DefenseSharedValues : MonoBehaviour {

//	public static ArrayList teams = new ArrayList();

	// Use this for initialization
	void Start () {
		
	}

	public static void resetFieldMode(){
		//reset the field mode values
		resetDefenseSelection();
		SharedValues.audienceCategory = "";
		SharedValues.defenseTeamNumber1 = "";
		SharedValues.defenseTeamNumber2 = "";
		SharedValues.defenseTeamNumber3 = "";
		SharedValues.screen = 10;
	}

	public static void resetDefenseSelection(){
		SharedValues.visibleCategories = "ABCD";
		SharedValues.myMatch.defensePos1 = Match.defenses.None;
		SharedValues.myMatch.defenseMiddle = Match.defenses.None;
		SharedValues.myMatch.defensePos2 = Match.defenses.None;
		SharedValues.myMatch.defensePos3 = Match.defenses.None;
	}

//	public static void addMatch(string teamNumberTemp, string matchNumberTemp, string[] csv){
//		bool teamFound = false;
//		int teamNumber = int.Parse(teamNumberTemp);
//		int matchNumber = int.Parse(matchNumberTemp);
//		foreach (Team checkTeam in Team.teams) {
//			if (checkTeam.teamNumber == teamNumber) {
//				teamFound = true;
//				if (checkTeam.getMatch (matchNumber) == null) {
//					print ("adding match: " +matchNumber + " to existing team: " + teamNumber);
//					checkTeam.createMatch (matchNumber, csv);
//				} else {
//					//TODO error the team already contains the given match
//				}
//			}
//		}
//
//		if (!teamFound) {
//			print("creating team: " + teamNumber + " adding match: " + matchNumber);
//			Team tempTeam = new Team (teamNumber, matchNumber, csv);
//			Team.teams.Add (tempTeam);
//		}
//	}
//
//	public static void loadAllMatches(){
//		string line;
//		string[] csv;
//		StreamReader file = new StreamReader (SharedValues.fileDirectory + "all_matches.csv");
//		file.ReadLine ();
//		while((line = file.ReadLine()) != null){
//			csv = line.Split(',');
//			addMatch (csv[0], csv[1], csv);
//		}
//		file.Close ();
//
//		foreach (Team myTeam in Team.teams) {
//			print (myTeam);
//		}
//	}

//	public static double avgBallsScored(string teamNumber){
//		double ballsScored = 0;
//		double numberOfMatches = 0;
//		foreach (Team myTeam in Team.teams) {
//			if (myTeam.teamNumber == int.Parse (teamNumber)) {
//				foreach (Match myMatch in myTeam.matches) {
//					numberOfMatches++;
//					ballsScored += myMatch.autoTowerTopCount + myMatch.autoTowerBottomCount + myMatch.teleTowerTopCount + myMatch.teleTowerBottomCount;
//				}
//				return Math.Round((ballsScored / numberOfMatches), 1);
//			}
//		}
//		return -1;
//	}

//	public static double avgDefensePlayed(string teamNumber){
//		double defensePlayed = 0;
//		double numberOfMatches = 0;
//		foreach (Team myTeam in Team.teams) {
//			if (myTeam.teamNumber == int.Parse (teamNumber)) {
//				foreach (Match myMatch in myTeam.matches) {
//					numberOfMatches++;
//					defensePlayed += myMatch.defense;
//				}
//				return Math.Round((defensePlayed / numberOfMatches), 1);
//			}
//		}
//		return -1;
//	}

//	public static double percentDefenseCrossed(string teamNumber, Match.defenses myDefense){
//		double defenseCrossed = 0;
//		double totalDefensesCrossed = 0;
//		foreach (Team myTeam in Team.teams) {
//			if (myTeam.teamNumber == int.Parse (teamNumber)) {
//				foreach (Match myMatch in myTeam.matches) {
//					totalDefensesCrossed += myMatch.autoLowBarCount + myMatch.autoChevalCount + myMatch.autoDrawbridgeCount + myMatch.autoMoatCount + myMatch.autoPortcullisCount;
//					totalDefensesCrossed += myMatch.autoRampartsCount + myMatch.autoRockWallCount + myMatch.autoRoughTerrainCount + myMatch.autoSallyPortCount;
//					totalDefensesCrossed += myMatch.teleLowBarCount + myMatch.teleChevalCount + myMatch.teleDrawbridgeCount + myMatch.teleMoatCount + myMatch.telePortcullisCount;
//					totalDefensesCrossed += myMatch.teleRampartsCount + myMatch.teleRockWallCount + myMatch.teleRoughTerrainCount + myMatch.teleSallyPortCount;
//					defenseCrossed += myMatch.getDefenseCount (myDefense);
//				}
//				return Math.Round ((defenseCrossed / totalDefensesCrossed) * 100, 1);
//			}
//		}
//		return -1;
//	}

	// Update is called once per frame
	void Update () {
	
	}
}
