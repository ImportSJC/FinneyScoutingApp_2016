using UnityEngine;
using System.Collections;
using System.IO;
using System;
using System.Text.RegularExpressions;

public class Match {

	private int teamNumber = -1;
	private int matchNumber = -1;

	public string scoutName = "";

	public enum defenses
	{
		None,
		Portcullis,
		RoughTerrain,
		Moat,
		Cheval,
		Ramparts,
		Drawbridge,
		SallyPort,
		RockWall,
		LowBar
	};

	public defenses defensePos1 = defenses.None;
	public defenses defenseMiddle = defenses.None;
	public defenses defensePos2 = defenses.None;
	public defenses defensePos3 = defenses.None;

	public bool autoApproachedDefense = false;

	public int autoLowBarCount = 0;
	public int autoChevalCount = 0;
	public int autoPortcullisCount = 0;
	public int autoMoatCount = 0;
	public int autoRampartsCount = 0;
	public int autoDrawbridgeCount = 0;
	public int autoSallyPortCount = 0;
	public int autoRockWallCount = 0;
	public int autoRoughTerrainCount = 0;

	public int teleLowBarCount = 0;
	public int teleChevalCount = 0;
	public int telePortcullisCount = 0;
	public int teleMoatCount = 0;
	public int teleRampartsCount = 0;
	public int teleDrawbridgeCount = 0;
	public int teleSallyPortCount = 0;
	public int teleRockWallCount = 0;
	public int teleRoughTerrainCount = 0;

	public int autoTowerBottomCount = 0;
	public int autoTowerTopCount = 0;
	public int teleTowerBottomCount = 0;
	public int teleTowerTopCount = 0;

	public bool capture = false;
	public bool hang = false;

	public string comment = "";

	public int defense = 0; //0=NA 1=poor 2=decent 3=great

	private int incrementInt;//for incrementing through the csvValues

	public Match(int teamNumber, int matchNumber){
		this.teamNumber = teamNumber;
		this.matchNumber = matchNumber;
	}

	public Match(int teamNumber, int matchNumber, string[] csvValues){
		incrementInt = 3;
		this.teamNumber = int.Parse(csvValues[0]);
		this.matchNumber = int.Parse(csvValues[1]);

		this.scoutName = csvValues [2];

		assignValue_defense (ref defensePos1, csvValues [incrementInt]);
		assignValue_defense (ref defenseMiddle, csvValues [incrementInt]);
		assignValue_defense (ref defensePos2, csvValues [incrementInt]);
		assignValue_defense (ref defensePos3, csvValues [incrementInt]);

		assignValue_bool (ref autoApproachedDefense, csvValues[incrementInt]);
		assignValue_int (ref autoLowBarCount, csvValues[incrementInt]);
		assignValue_int (ref autoChevalCount, csvValues[incrementInt]);
		assignValue_int (ref autoPortcullisCount, csvValues[incrementInt]);
		assignValue_int (ref autoMoatCount, csvValues[incrementInt]);
		assignValue_int (ref autoRampartsCount, csvValues[incrementInt]);
		assignValue_int (ref autoDrawbridgeCount, csvValues[incrementInt]);
		assignValue_int (ref autoSallyPortCount, csvValues[incrementInt]);
		assignValue_int (ref autoRockWallCount, csvValues[incrementInt]);
		assignValue_int (ref autoRoughTerrainCount, csvValues[incrementInt]);

		assignValue_int (ref teleLowBarCount, csvValues[incrementInt]);
		assignValue_int (ref teleChevalCount, csvValues[incrementInt]);
		assignValue_int (ref telePortcullisCount, csvValues[incrementInt]);
		assignValue_int (ref teleMoatCount, csvValues[incrementInt]);
		assignValue_int (ref teleRampartsCount, csvValues[incrementInt]);
		assignValue_int (ref teleDrawbridgeCount, csvValues[incrementInt]);
		assignValue_int (ref teleSallyPortCount, csvValues[incrementInt]);
		assignValue_int (ref teleRockWallCount, csvValues[incrementInt]);
		assignValue_int (ref teleRoughTerrainCount, csvValues[incrementInt]);

		assignValue_int (ref autoTowerBottomCount, csvValues[incrementInt]);
		assignValue_int (ref autoTowerTopCount, csvValues[incrementInt]);
		assignValue_int (ref teleTowerBottomCount, csvValues[incrementInt]);
		assignValue_int (ref teleTowerTopCount, csvValues[incrementInt]);

		assignValue_bool (ref capture, csvValues[incrementInt]);
		assignValue_bool (ref hang, csvValues[incrementInt]);
		assignValue_int (ref defense, csvValues[incrementInt]);
		comment = csvValues [incrementInt];
	}

	public int totalAutoDefensesCrossed(){
		return autoLowBarCount + autoChevalCount + autoDrawbridgeCount + autoMoatCount + autoPortcullisCount +
			autoRampartsCount + autoRockWallCount + autoRoughTerrainCount + autoSallyPortCount;
	}

	public int totalTeleDefensesCrossed(){
		return teleLowBarCount + teleChevalCount + teleDrawbridgeCount + teleMoatCount + telePortcullisCount +
			teleRampartsCount + teleRockWallCount + teleRoughTerrainCount + teleSallyPortCount;
	}

	public int oprAutoDefensesCrossed(){
			return Math.Min(autoLowBarCount,1) + Math.Min(autoChevalCount,1) + Math.Min(autoDrawbridgeCount,1) + Math.Min(autoMoatCount,1) + Math.Min(autoPortcullisCount,1) +
				Math.Min(autoRampartsCount,1) + Math.Min(autoRockWallCount,1) + Math.Min(autoRoughTerrainCount,1) + Math.Min(autoSallyPortCount,1);
	}

	public int oprTeleDefensesCrossed(){
			return Math.Min(teleLowBarCount,2) + Math.Min(teleChevalCount,2) + Math.Min(teleDrawbridgeCount,2) + Math.Min(teleMoatCount,2) + Math.Min(telePortcullisCount,2) +
				Math.Min(teleRampartsCount,2) + Math.Min(teleRockWallCount,2) + Math.Min(teleRoughTerrainCount,2) + Math.Min(teleSallyPortCount,2);
	}

	public int getMatchNumber(){
		return this.matchNumber;
	}

	public void submitMatch(){
		string myStr = "";
		if (!File.Exists (SharedValues.fileDirectory + "all_matches.csv")) {
			myStr += "teamNumber,matchNumber,scoutName,defensePos1,defenseMiddle,defensePos2,defensePos3,";
			myStr += "autoApproachedDefense,autoLowBarCount,autoChevalCount,autoPortcullisCount,";
			myStr += "autoMoatCount,autoRampartsCount,autoDrawbridgeCount,autoSallyPortCount,autoRockWallCount,autoRoughTerrainCount,";
			myStr += "teleLowBarCount,teleChevalCount,telePortcullisCount,teleMoatCount,teleRampartsCount,teleDrawbridgeCount,";
			myStr += "teleSallyPortCount,teleRockWallCount,teleRoughTerrainCount,autoTowerBottomCount,autoTowerTopCount,teleTowerBottomCount,";
			myStr += "teleTowerTopCount,capture,hang,defense,comment\n";
		}
		comment = comment.Replace (",", "[comma]");
		comment = comment.Replace ("\n", "[newline]");
		scoutName = scoutName.Replace (",", "");
		scoutName = scoutName.Replace ("\n", "");

		myStr += teamNumber + "," + matchNumber + "," + scoutName + "," + defensePos1 + "," + defenseMiddle + "," + defensePos2 + "," + defensePos3 + ",";
		myStr += autoApproachedDefense + "," + autoLowBarCount + "," + autoChevalCount + "," + autoPortcullisCount + ",";
		myStr += autoMoatCount + "," + autoRampartsCount + "," + autoDrawbridgeCount + "," + autoSallyPortCount + "," + autoRockWallCount + "," + autoRoughTerrainCount + ",";
		myStr += teleLowBarCount + "," + teleChevalCount + "," + telePortcullisCount + "," + teleMoatCount + "," + teleRampartsCount + "," + teleDrawbridgeCount + ",";
		myStr += teleSallyPortCount + "," + teleRockWallCount + "," + teleRoughTerrainCount + "," + autoTowerBottomCount + "," + autoTowerTopCount + ",";
		myStr += teleTowerBottomCount + "," + teleTowerTopCount + "," + capture + "," + hang + "," + defense + "," + comment + "\n";

//			File.WriteAllText (SharedValues.fileDirectory + teamNumber + "_" + matchNumber + ".csv", myStr);
		if (File.Exists (SharedValues.fileDirectory + "all_matches.csv")) {
			string finishedStr = "";
			bool replaced = false;
			string[] fileStr = File.ReadAllLines (SharedValues.fileDirectory + "all_matches.csv");
			foreach (string fileLineStr in fileStr) {
				string[] fileLineStrSplit = fileLineStr.Split (',');
				if (fileLineStrSplit [0].Equals (teamNumber.ToString ()) &&
					fileLineStrSplit [1].Equals (matchNumber.ToString ())) {
					finishedStr += myStr;
					replaced = true;
				} else {
					finishedStr += fileLineStr + "\n";
				}
			}
			if (!replaced) {
				File.AppendAllText (SharedValues.fileDirectory + "all_matches.csv", myStr);
			} else {
				File.WriteAllText (SharedValues.fileDirectory + "all_matches.csv", finishedStr);
			}
		} else {
			File.WriteAllText (SharedValues.fileDirectory + "all_matches.csv", myStr);
		}
	}

	private void assignValue_bool(ref bool myBool, string myString){
		if (myString.Equals ("TRUE", StringComparison.InvariantCultureIgnoreCase)) {
			myBool = true;
		} else if (myString.Equals ("FALSE", StringComparison.InvariantCultureIgnoreCase)) {
			myBool = false;
		}
		incrementInt++;
	}

	private void assignValue_int(ref int myInt, string myString){
		myInt = int.Parse (myString);
		incrementInt++;
	}

	private void assignValue_defense(ref defenses myDef, string myString){
		switch (myString) {
		case("Cheval"):
			myDef = defenses.Cheval;
			break;
		case("Moat"):
			myDef = defenses.Moat;
			break;
		case("Drawbridge"):
			myDef = defenses.Drawbridge;
			break;
		case("Portcullis"):
			myDef = defenses.Portcullis;
			break;
		case("SallyPort"):
			myDef = defenses.SallyPort;
			break;
		case("RoughTerrain"):
			myDef = defenses.RoughTerrain;
			break;
		case("RockWall"):
			myDef = defenses.RockWall;
			break;
		case("Ramparts"):
			myDef = defenses.Ramparts;
			break;
		}
		incrementInt++;
	}

	public int getDefenseCount(defenses myDefense){
		switch (myDefense) {
		case(defenses.Cheval):
			return autoChevalCount + teleChevalCount;
		case(defenses.Moat):
			return autoMoatCount + teleMoatCount;
		case(defenses.Drawbridge):
			return autoDrawbridgeCount + teleDrawbridgeCount;
		case(defenses.Portcullis):
			return autoPortcullisCount = telePortcullisCount;
		case(defenses.SallyPort):
			return autoSallyPortCount + teleSallyPortCount;
		case(defenses.RoughTerrain):
			return autoRoughTerrainCount + teleRoughTerrainCount;
		case(defenses.RockWall):
			return autoRockWallCount + teleRockWallCount;
		case(defenses.Ramparts):
			return autoRampartsCount + teleRampartsCount;
		case(defenses.LowBar):
			return autoLowBarCount + teleLowBarCount;
		}
		return -1;
	}

	public override string ToString ()
	{
		string myStr = "";
		myStr += "\tMatch: " + matchNumber + "\n";
		myStr += "\t\tTeam Number: " + teamNumber + "\n";
		return myStr;
	}
}
