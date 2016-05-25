using UnityEngine;
using System.Collections;
using System.IO;
using System;

public class Team {
	private static int[] validTeamList = {20,73,174,191,250,271,340,378,395,578,639,810,1126,1405,1450,1507,
											1511,1518,1551,1559,1585,1591,1665,1765,1880,2010,2228,2340,2383,
											2638,2791,2809,3003,3015,3044,3157,3173,3181,3799,3838,3951,4023,
											4093,4930,5030,5240,5254,5433,5590};

	public int teamNumber = 0;
	public ArrayList matches = new ArrayList();

	public static ArrayList teams = new ArrayList();

	public Team(int teamNumber, int matchNumber){
		this.teamNumber = teamNumber;
		var newMatch = new Match (teamNumber, matchNumber);
		matches.Add (newMatch);
	}

	public Team(int teamNumber, int matchNumber, string[] csv){
		this.teamNumber = teamNumber;
		var newMatch = new Match (teamNumber, matchNumber, csv);
		matches.Add (newMatch);
	}

	public void createMatch(int matchNumber){
		var newMatch = new Match (teamNumber, matchNumber);
		matches.Add (newMatch);
	}

	public void createMatch(int matchNumber, string[] csv){
		var newMatch = new Match (teamNumber, matchNumber, csv);
		matches.Add (newMatch);
	}

	public static Team getTeam(int teamNumber){
		foreach(Team myTeam in teams){
			if(myTeam.teamNumber == teamNumber){
				return myTeam;
			}
		}
		return (Team)teams[0];
	}

	public static Team getTeam(string teamNumber){
		foreach(Team myTeam in teams){
			if(myTeam.teamNumber == int.Parse(teamNumber)){
				return myTeam;
			}
		}
		return (Team)teams[0];
	}

	public Match getMatch(int matchNumber){
		foreach(Match match in matches){
			if(match.getMatchNumber() == matchNumber){
				return match;
			}
		}
		return null;
	}

	public static void addMatch(){
		loadAllMatches ();
		bool teamFound = false;
		int teamNumber = int.Parse(SharedValues.tempTeamNumber);
		int matchNumber = int.Parse(SharedValues.tempMatchNumber);
		foreach (Team checkTeam in Team.teams) {
			if (checkTeam.teamNumber == teamNumber) {
				Debug.Log ("Team found: " + getTeam(teamNumber));
				teamFound = true;
				if (checkTeam.getMatch (matchNumber) == null) {
					checkTeam.createMatch (matchNumber);
					SharedValues.myTeam = checkTeam;
					SharedValues.myMatch = checkTeam.getMatch (matchNumber);
					SharedValues.tempComment = SharedValues.myMatch.comment;
					SharedValues.findGameObject ("DefenseScore_List").GetComponent<InstantGuiList> ().selected = SharedValues.myMatch.defense;
					SharedValues.tempScoutName = SharedValues.myMatch.scoutName;
					Debug.Log ("matchNumber: " + matchNumber + " not found");
				} else {
					Debug.Log ("matchNumber: " + matchNumber + " found in the teams logs");
					//TODO error the team already contains the given match
				}
			}
		}

		if (!teamFound) {
			Debug.Log ("Team not found " + teamNumber);
			Team tempTeam = new Team (teamNumber, matchNumber);
			Team.teams.Add(tempTeam);
			SharedValues.myTeam = tempTeam;
			SharedValues.myMatch = SharedValues.myTeam.getMatch (matchNumber);
		}
	}

	public static void addMatch(string teamNumberTemp, string matchNumberTemp, string[] csv){
		bool teamFound = false;
		int matchNumber = int.Parse(matchNumberTemp);
		foreach (Team checkTeam in teams) {
			if (checkTeam.teamNumber == int.Parse(teamNumberTemp)) {
				teamFound = true;
				if (checkTeam.getMatch (matchNumber) == null) {
					Debug.Log ("Adding existing team: " + teamNumberTemp + " match: " + matchNumber);
					checkTeam.createMatch (matchNumber, csv);
				} else {
					//TODO error the team already contains the given match
				}
			}
		}

		if (!teamFound) {
			Debug.Log ("Adding new team from csv file: " + teamNumberTemp + " and match: " + matchNumber);
			Team tempTeam = new Team (int.Parse(teamNumberTemp), matchNumber, csv);
			teams.Add (tempTeam);
		}
	}

	public static void loadAllMatches(){
		if (File.Exists (SharedValues.fileDirectory + "all_matches.csv")) {
			string line;
			string[] csv;
			teams = new ArrayList ();
			teams.Add (new Team (0, 0));
			StreamReader file = new StreamReader (SharedValues.fileDirectory + "all_matches.csv");
			file.ReadLine ();
			while ((line = file.ReadLine ()) != null) {
				csv = line.Split (',');
				Debug.Log ("theoraretically adding  team: " + csv [0] + " match: " + csv [1]);
				addMatch (csv [0], csv [1], csv);
			}
			file.Close ();
		}
	}

	public static bool validTeam(){
		foreach (int myInt in validTeamList) {
			if (myInt == int.Parse (SharedValues.tempTeamNumber)) {
				return true;
			}
		}
		return false;
	}

	public ArrayList getMatches(){
		ArrayList myMatches = new ArrayList();
		foreach (Team myTeam in Team.teams) {
			if (myTeam.teamNumber == teamNumber) {
				foreach (Match myMatch in myTeam.matches) {
					myMatches.Add (myMatch);
				}
			}
		}
		return myMatches;
	}

	public double avgDefensesCrossed(){
		double defensesCrossed = 0;
		double numberOfMatches = 0;
		foreach (Match myMatch in getMatches()) {
			numberOfMatches++;
			defensesCrossed += myMatch.autoLowBarCount + myMatch.autoChevalCount + myMatch.autoDrawbridgeCount + myMatch.autoMoatCount + myMatch.autoPortcullisCount;
			defensesCrossed += myMatch.autoRampartsCount + myMatch.autoRockWallCount + myMatch.autoRoughTerrainCount + myMatch.autoSallyPortCount;
			defensesCrossed += myMatch.teleLowBarCount + myMatch.teleChevalCount + myMatch.teleDrawbridgeCount + myMatch.teleMoatCount + myMatch.telePortcullisCount;
			defensesCrossed += myMatch.teleRampartsCount + myMatch.teleRockWallCount + myMatch.teleRoughTerrainCount + myMatch.teleSallyPortCount;
		}
		return Math.Round((defensesCrossed / numberOfMatches), 1);
	}

	public double percentDefenseCrossed(Match.defenses myDefense){
		double defenseCrossed = 0;
		double totalDefensesCrossed = 0;
		foreach (Match myMatch in getMatches()) {
			totalDefensesCrossed += myMatch.totalAutoDefensesCrossed() + myMatch.totalTeleDefensesCrossed ();
			defenseCrossed += myMatch.getDefenseCount (myDefense);
		}
		return Math.Round ((defenseCrossed / totalDefensesCrossed) * 100, 1);
	}

	public double avgBallsScoredHigh(){
		double ballsScored = 0;
		double numberOfMatches = 0;
		foreach (Match myMatch in getMatches()) {
			numberOfMatches++;
			ballsScored += myMatch.teleTowerTopCount;
		}
		return Math.Round((ballsScored / numberOfMatches), 1);
	}

	public double avgBallsScoredLow(){
		double ballsScored = 0;
		double numberOfMatches = 0;
		foreach (Match myMatch in getMatches()) {
			numberOfMatches++;
			ballsScored += myMatch.teleTowerBottomCount;
		}
		return Math.Round((ballsScored / numberOfMatches), 1);
	}

	public double avgDefensePlayed(){
		double defensePlayed = 0;
		double numberOfMatches = 0;
		foreach (Team myTeam in Team.teams) {
			if (myTeam.teamNumber == teamNumber) {
				foreach (Match myMatch in myTeam.matches) {
					numberOfMatches++;
					defensePlayed += myMatch.defense;
				}
				return Math.Round((defensePlayed / numberOfMatches), 1);
			}
		}
		return -1;
	}

	public double calculateAverageOPR(){
		double totalOPR = 0;
		double numberOfMatches = 0;
		foreach (Match myMatch in getMatches()) {
//			Debug.Log(teamNumber + " autotop: " + myMatch.autoTowerTopCount + " autobottom: " + myMatch.autoTowerBottomCount);
//			Debug.Log(teamNumber + " teletop: " + myMatch.teleTowerTopCount + " telebottom: " + myMatch.teleTowerBottomCount);
//			Debug.Log(teamNumber + " autooprdefenses: " + myMatch.oprAutoDefensesCrossed() + " teleoprdefenses: " + myMatch.oprTeleDefensesCrossed());
//			Debug.Log(teamNumber + " hang: " + myMatch.hang + " capture: " + myMatch.capture);

			totalOPR += (myMatch.autoTowerTopCount * 10) + (myMatch.autoTowerBottomCount * 5);
			totalOPR += (myMatch.teleTowerTopCount * 5) + (myMatch.teleTowerBottomCount * 2);
			totalOPR += (myMatch.oprAutoDefensesCrossed()*10) + (myMatch.oprTeleDefensesCrossed()*5);
			if (myMatch.hang) {
				totalOPR += 15;
//				Debug.Log(teamNumber + " hung for 15");
			} else if(myMatch.capture) {
				totalOPR += 5;
			}

			if ((myMatch.oprAutoDefensesCrossed() + myMatch.oprTeleDefensesCrossed()) >= 8) {
//				Debug.Log(teamNumber + "breached for 20");
				totalOPR += 20;
			}

			if ((myMatch.autoTowerTopCount + myMatch.autoTowerBottomCount + myMatch.teleTowerTopCount + myMatch.teleTowerBottomCount) >= 8) {
				totalOPR += 25;
			}
			numberOfMatches++;
		}
		return Math.Round((totalOPR / numberOfMatches), 1);
	}

	public override string ToString(){
		string myStr = "";
		myStr += "Team: " + teamNumber + "\n";
		foreach (Match myMatch in matches) {
			myStr += myMatch;
		}
		return myStr;
	}
}
