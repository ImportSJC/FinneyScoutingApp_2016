﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;


public class SharedValues : MonoBehaviour {

	public static bool addMode = true;
	public static int screen = 0;

//	public static ArrayList teams = new ArrayList();

//	private string teamNumber = "";
//	private string matchNumber = "";
	public static Team myTeam = null;
	public static Match myMatch = null;

//	public static string fileDirectory = "C:\\Users\\Stephen\\Unity\\json\\";
	public static string fileDirectory = "";// /sdcard/Android/data/

//	Dictionary<string,GameObject> myDict = new Dictionary<string,GameObject>();
	private static GameObject page0;
	private static GameObject page1;
	private static GameObject page2;
	private static GameObject page3;
	private static GameObject page4;

	private static GameObject fieldPage1;
	private static GameObject fieldPage2;
	private static GameObject fieldPage3;
	private static GameObject fieldPage4;

	private static GameObject[] allObjects;

	public static string tempComment = "";

	public static string tempTeamNumber = "";
	public static string tempMatchNumber = "";

	public static string tempMatchNumberField = "";

	public static string tempScoutName = "";

	//team #s for on the field defense selection
	public static string defenseTeamNumber1 = "";//opponent
	public static string defenseTeamNumber2 = "";//opponent
	public static string defenseTeamNumber3 = "";//opponent

	public static string audienceCategory = "";
	public static string visibleCategories = "ABCD";

	public static double dpiScale = 1.0;

	// Use this for initialization
	void Start () {
		fileDirectory = Application.persistentDataPath + "/";

		myTeam = new Team(0, 0);
		myMatch = myTeam.getMatch (0);
		Team.teams.Add (myTeam);

		allObjects = Resources.FindObjectsOfTypeAll (typeof(GameObject)) as GameObject[];
		page0 = findGameObject("Page0");
		page1 = findGameObject("Page1");
		page2 = findGameObject("Page2");
		page3 = findGameObject("Page3");
		page4 = findGameObject ("Page4");

		fieldPage1 = findGameObject ("FieldPage1");
		fieldPage2 = findGameObject ("FieldPage2");
		fieldPage3 = findGameObject ("FieldPage3");
		fieldPage4 = findGameObject ("FieldPage4");
	}

	public static void decreaseDPI(){
		dpiScale -= 0.1;
	}

	public static void increaseDPI(){
		dpiScale += 0.1;
	}

	public static void sendMessage(string message){
		findGameObject ("InstantGUI").BroadcastMessage(message);
	}

	public static void resetTextBoxes(){
		tempComment = "";
		tempTeamNumber = "";
		tempMatchNumber = "";
	}

//	public static void addMatch(){
//		bool teamFound = false;
//		int teamNumber = int.Parse(tempTeamNumber);
//		int matchNumber = int.Parse(tempMatchNumber);
//		foreach (Team checkTeam in Team.teams) {
//			if (checkTeam.teamNumber == teamNumber) {
//				teamFound = true;
//				if (checkTeam.getMatch (matchNumber) == null) {
//					checkTeam.createMatch (matchNumber);
//					myMatch = checkTeam.getMatch (matchNumber);
//				} else {
//					//TODO error the team already contains the given match
//				}
//			}
//		}
//
//		if (!teamFound) {
//			Team tempTeam = new Team (teamNumber, matchNumber);
//			myTeam = tempTeam;
//			myMatch = myTeam.getMatch (matchNumber);
//		}
//	}

	public static GameObject findGameObject(string name){
		foreach (GameObject myObj in allObjects) {
			if (myObj != null && myObj.name.Equals (name)) {
				return myObj;
			}
		}
		return null;
	}

	public static Texture setPosButtonImage(Match.defenses defense){
		switch (defense) {
		case(Match.defenses.Cheval):
			return Resources.Load ("Cheval_de_Frise") as Texture;

		case(Match.defenses.Drawbridge):
			return Resources.Load ("Drawbridge") as Texture;
			
		case(Match.defenses.Moat):
			return Resources.Load ("Moat") as Texture;
			
		case(Match.defenses.Portcullis):
			return Resources.Load ("Portcullis") as Texture;
			
		case(Match.defenses.Ramparts):
			return Resources.Load ("Ramparts") as Texture;
			
		case(Match.defenses.RockWall):
			return Resources.Load ("Rock_Wall") as Texture;
			
		case(Match.defenses.RoughTerrain):
			return Resources.Load ("Rough_Terrain") as Texture;
			
		case(Match.defenses.SallyPort):
			return Resources.Load ("Sally_Port") as Texture;
		}
		return Resources.Load ("noImage") as Texture;
	}

	public static void alterCount_auto(Match.defenses myDefense){
		switch (myDefense) {
		case(Match.defenses.Cheval):
			addSubMode(ref SharedValues.myMatch.autoChevalCount);
			break;
		case(Match.defenses.Drawbridge):
			addSubMode(ref SharedValues.myMatch.autoDrawbridgeCount);
			break;
		case(Match.defenses.Moat):
			addSubMode(ref SharedValues.myMatch.autoMoatCount);
			break;
		case(Match.defenses.Portcullis):
			addSubMode(ref SharedValues.myMatch.autoPortcullisCount);
			break;
		case(Match.defenses.Ramparts):
			addSubMode(ref SharedValues.myMatch.autoRampartsCount);
			break;
		case(Match.defenses.RockWall):
			addSubMode(ref SharedValues.myMatch.autoRockWallCount);
			break;
		case(Match.defenses.RoughTerrain):
			addSubMode(ref SharedValues.myMatch.autoRoughTerrainCount);
			break;
		case(Match.defenses.SallyPort):
			addSubMode(ref SharedValues.myMatch.autoSallyPortCount);
			break;
		}
	}

	public static void alterCount_tele(Match.defenses myDefense){
		switch (myDefense) {
		case(Match.defenses.Cheval):
			addSubMode(ref SharedValues.myMatch.teleChevalCount);
			break;
		case(Match.defenses.Drawbridge):
			addSubMode(ref SharedValues.myMatch.teleDrawbridgeCount);
			break;
		case(Match.defenses.Moat):
			addSubMode(ref SharedValues.myMatch.teleMoatCount);
			break;
		case(Match.defenses.Portcullis):
			addSubMode(ref SharedValues.myMatch.telePortcullisCount);
			break;
		case(Match.defenses.Ramparts):
			addSubMode(ref SharedValues.myMatch.teleRampartsCount);
			break;
		case(Match.defenses.RockWall):
			addSubMode(ref SharedValues.myMatch.teleRockWallCount);
			break;
		case(Match.defenses.RoughTerrain):
			addSubMode(ref SharedValues.myMatch.teleRoughTerrainCount);
			break;
		case(Match.defenses.SallyPort):
			addSubMode(ref SharedValues.myMatch.teleSallyPortCount);
			break;
		}
	}

	public static void addSubMode(ref int myCount){
		if(SharedValues.addMode){
			myCount++;
		}else{
			myCount--;
		}
	}

	public static int getCount_auto(Match.defenses myDefense){
		switch (myDefense) {
		case(Match.defenses.Cheval):
			return SharedValues.myMatch.autoChevalCount;
		case(Match.defenses.Drawbridge):
			return SharedValues.myMatch.autoDrawbridgeCount;
		case(Match.defenses.Moat):
			return SharedValues.myMatch.autoMoatCount;
		case(Match.defenses.Portcullis):
			return SharedValues.myMatch.autoPortcullisCount;
		case(Match.defenses.Ramparts):
			return SharedValues.myMatch.autoRampartsCount;
		case(Match.defenses.RockWall):
			return SharedValues.myMatch.autoRockWallCount;
		case(Match.defenses.RoughTerrain):
			return SharedValues.myMatch.autoRoughTerrainCount;
		case(Match.defenses.SallyPort):
			return SharedValues.myMatch.autoSallyPortCount;
		}
		return -1;
	}

	public static int getCount_tele(Match.defenses myDefense){
		switch (myDefense) {
		case(Match.defenses.Cheval):
			return SharedValues.myMatch.teleChevalCount;
		case(Match.defenses.Drawbridge):
			return SharedValues.myMatch.teleDrawbridgeCount;
		case(Match.defenses.Moat):
			return SharedValues.myMatch.teleMoatCount;
		case(Match.defenses.Portcullis):
			return SharedValues.myMatch.telePortcullisCount;
		case(Match.defenses.Ramparts):
			return SharedValues.myMatch.teleRampartsCount;
		case(Match.defenses.RockWall):
			return SharedValues.myMatch.teleRockWallCount;
		case(Match.defenses.RoughTerrain):
			return SharedValues.myMatch.teleRoughTerrainCount;
		case(Match.defenses.SallyPort):
			return SharedValues.myMatch.teleSallyPortCount;
		}
		return -1;
	}

	void OnGUI(){

		if (screen == 0) {
			tempTeamNumber = GUI.TextArea (new Rect (100, 40, 100, 50), tempTeamNumber);
			tempMatchNumber = GUI.TextArea (new Rect (410, 40, 100, 50), tempMatchNumber);
			tempScoutName = GUI.TextArea (new Rect (150, 125, 100, 50), tempScoutName);
		} else if (screen == 4) {
			tempComment = GUI.TextArea (new Rect (50, 80, Screen.width - 100, 200), tempComment);
		} else if (screen == 10) {
			defenseTeamNumber1 = GUI.TextArea (new Rect (100, 180-25, 100, 50), defenseTeamNumber1);
			defenseTeamNumber2 = GUI.TextArea (new Rect (350, 180-25, 100, 50), defenseTeamNumber2);
			defenseTeamNumber3 = GUI.TextArea (new Rect (600, 180-25, 100, 50), defenseTeamNumber3);

			audienceCategory = GUI.TextArea (new Rect (220, 260-25, 100, 50), audienceCategory);

			tempMatchNumberField = GUI.TextArea (new Rect (110, 50-25, 100, 50), tempMatchNumberField);
		}
	}

	public static void loadFieldMatch(int matchNumber){
		bool loaded = false;
		if (File.Exists (SharedValues.fileDirectory + "match_schedule.csv")) {
			string line;
			string[] csv;
			StreamReader file = new StreamReader (SharedValues.fileDirectory + "match_schedule.csv");
			file.ReadLine ();
			while ((line = file.ReadLine ()) != null) {
				csv = line.Split (',');
				if (matchNumber == int.Parse (csv [0])) {
					SharedValues.defenseTeamNumber1 = csv [1];
					SharedValues.defenseTeamNumber2 = csv [2];
					SharedValues.defenseTeamNumber3 = csv [3];
					SharedValues.audienceCategory = csv [4];
					loaded = true;
				}
			}
			file.Close ();
		}
		if (!loaded) {
			SharedValues.defenseTeamNumber1 = "";
			SharedValues.defenseTeamNumber2 = "";
			SharedValues.defenseTeamNumber3 = "";
			SharedValues.audienceCategory = "";
		}
	}

	// Update is called once per frame
	void Update () {
		if ((audienceCategory.Equals ("A", System.StringComparison.InvariantCultureIgnoreCase) && visibleCategories.Contains("A")) || (audienceCategory.Equals ("B", System.StringComparison.InvariantCultureIgnoreCase) && visibleCategories.Contains("B"))
			|| (audienceCategory.Equals ("C", System.StringComparison.InvariantCultureIgnoreCase) && visibleCategories.Contains("C")) || (audienceCategory.Equals ("D", System.StringComparison.InvariantCultureIgnoreCase) && visibleCategories.Contains("D"))) {
			visibleCategories = visibleCategories.Replace (audienceCategory, "");
		}

		page0.SetActive (screen == 0);
		page1.SetActive (screen == 1);
		page2.SetActive (screen == 2);
		page3.SetActive (screen == 3);
		page4.SetActive (screen == 4);

		fieldPage1.SetActive (screen == 10);
		fieldPage2.SetActive (screen == 11);
		fieldPage3.SetActive (screen == 12);
		fieldPage4.SetActive (screen == 13);
	}
}