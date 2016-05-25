//using UnityEngine;
//using System.Collections;
//
//public class MyGUI : MonoBehaviour {
//
//	public GUIStyle bigStyle;
//
//	Texture lowBarImage;
//
//	//Category A
//	Texture chevalImage ;
//	Texture portcullisImage;
//
//	//Category B
//	Texture moatImage;
//	Texture rampartsImage;
//
//	//Category C
//	Texture drawbridgeImage;
//	Texture sallyPortImage;
//
//	//Category D
//	Texture rockWallImage;
//	Texture roughTerrainImage;
//
//
//
//	private const double imageScaling = 0.4;
//	public int currPosX = 25;
//	private const int preGame_defensesPosY = 150;
//	private const int midGame_defensesPosY = 80;
//	private const int padding = 5;
//
//	private bool addMode = true;
//
//	private int screen = 1; //1=pregame; 2=auto 3=tele; 4=endgame;
//
//	private ArrayList teams = new ArrayList();
//
//	private string teamNumber = "";
//	private string matchNumber = "";
//	Team myTeam;
//	Match myMatch;
//
//	public static string fileDirectory = "C:\\Users\\Stephen\\Unity\\json\\";
//
//	// Use this for initialization
//	void Start () {
//		myTeam = new Team();
//		myTeam.createTeam (0);
//		myTeam.createMatch (0);
//		myMatch = myTeam.getMatch (0);
//		teams.Add (myTeam);
//
//
//		lowBarImage = Resources.Load("Low_Bar") as Texture;
//		chevalImage = Resources.Load("Cheval_de_Frise") as Texture;
//		portcullisImage = Resources.Load("Portcullis") as Texture;
//		moatImage = Resources.Load("Moat") as Texture;
//		rampartsImage = Resources.Load("Ramparts") as Texture;
//		drawbridgeImage = Resources.Load("Drawbridge") as Texture;
//		sallyPortImage = Resources.Load("Sally_Port") as Texture;
//		rockWallImage = Resources.Load("Rock_Wall") as Texture;
//		roughTerrainImage = Resources.Load("Rough_Terrain") as Texture;
//	}
//
//	void OnGUI(){
//		if (screen == 1) {
////			addButton_pregame (lowBarImage, ref myMatch.chevalActive, false);
//			addButton_pregame (portcullisImage, chevalImage, ref myMatch.portcullisActive, ref myMatch.chevalActive);
//			addButton_pregame (moatImage, rampartsImage, ref myMatch.moatActive, ref myMatch.rampartsActive);
//			addButton_pregame (drawbridgeImage, sallyPortImage, ref myMatch.drawbridgeActive, ref myMatch.sallyPortActive);
//			addButton_pregame (rockWallImage, roughTerrainImage, ref myMatch.rockWallActive, ref myMatch.roughTerrainActive);
//			GUI.Label (new Rect (0, Screen.height - 75, 100, 25), "Team Number: ");
//			teamNumber = GUI.TextField (new Rect (0, Screen.height - 50, 100, 30), teamNumber);
//			GUI.Label (new Rect (125, Screen.height - 75, 100, 25), "Match Number: ");
//			matchNumber = GUI.TextField (new Rect (125, Screen.height - 50, 100, 30), matchNumber);
//
//			if (GUI.Button (new Rect (250, Screen.height - 50, 100, 50), "Add")) {
//				this.addMatch (int.Parse (teamNumber), int.Parse (matchNumber));
//				foreach (Team testTeam in teams) {
//					print ("Team object: " + testTeam);
//				}
//			}
//
//			GUI.Label (new Rect (375, Screen.height - 50, 100, 50), "Loaded - Team: " + myTeam.teamNumber + " Match: " + myMatch.getMatchNumber (), bigStyle);
//		} else if (screen == 2) {
//			if (addMode) {
//				if (GUI.Button (new Rect (0, 0, 150, 50), "Current Mode: Add")) {
//					addMode = !addMode;
//				}
//			} else {
//				if (GUI.Button (new Rect (0, 0, 150, 50), "Current Mode: Sub")) {
//					addMode = !addMode;
//				}
//			}
//			GUI.Label (new Rect (175, 0, 100, 25), "Auto Mode", bigStyle);
//
//			addButton_midgame (lowBarImage, ref myMatch.autoLowBarCount);
//			if (myMatch.chevalActive) {
//				addButton_midgame (chevalImage, ref myMatch.autoChevalCount);
//			} else if (myMatch.portcullisActive) {
//				addButton_midgame (portcullisImage, ref myMatch.autoPortcullisCount);
//			}
//
//			if (myMatch.moatActive) {
//				addButton_midgame (moatImage, ref myMatch.autoMoatCount);
//			} else if (myMatch.rampartsActive) {
//				addButton_midgame (rampartsImage, ref myMatch.autoRampartsCount);
//			}
//
//			if (myMatch.drawbridgeActive) {
//				addButton_midgame (drawbridgeImage, ref myMatch.autoDrawbridgeCount);
//			} else if (myMatch.sallyPortActive) {
//				addButton_midgame (sallyPortImage, ref myMatch.autoSallyPortCount);
//			}
//
//			if (myMatch.rockWallActive) {
//				addButton_midgame (rockWallImage, ref myMatch.autoRockWallCount);
//			} else if (myMatch.roughTerrainActive) {
//				addButton_midgame (roughTerrainImage, ref myMatch.autoRoughTerrainCount);
//			}
//		} else if (screen == 3) {
//			if (addMode) {
//				if (GUI.Button (new Rect (0, 0, 150, 50), "Current Mode: Add")) {
//					addMode = !addMode;
//				}
//			} else {
//				if (GUI.Button (new Rect (0, 0, 150, 50), "Current Mode: Sub")) {
//					addMode = !addMode;
//				}
//			}
//			GUI.Label (new Rect (175, 0, 100, 25), "Tele Mode", bigStyle);
//
//			addButton_midgame (lowBarImage, ref myMatch.teleLowBarCount);
//			if (myMatch.chevalActive) {
//				addButton_midgame (chevalImage, ref myMatch.teleChevalCount);
//			} else if (myMatch.portcullisActive) {
//				addButton_midgame (portcullisImage, ref myMatch.telePortcullisCount);
//			}
//
//			if (myMatch.moatActive) {
//				addButton_midgame (moatImage, ref myMatch.teleMoatCount);
//			} else if (myMatch.rampartsActive) {
//				addButton_midgame (rampartsImage, ref myMatch.teleRampartsCount);
//			}
//
//			if (myMatch.drawbridgeActive) {
//				addButton_midgame (drawbridgeImage, ref myMatch.teleDrawbridgeCount);
//			} else if (myMatch.sallyPortActive) {
//				addButton_midgame (sallyPortImage, ref myMatch.teleSallyPortCount);
//			}
//
//			if (myMatch.rockWallActive) {
//				addButton_midgame (rockWallImage, ref myMatch.teleRockWallCount);
//			} else if (myMatch.roughTerrainActive) {
//				addButton_midgame (roughTerrainImage, ref myMatch.teleRoughTerrainCount);
//			}
//		} else if (screen == 4) {
//			GUI.Label (new Rect (10, 10, 100, 25), "Comments:");
//			myMatch.comment = GUI.TextArea(new Rect(25,25,200,200), myMatch.comment);
//			GUI.Label (new Rect (125, Screen.height - 50, 100, 50), "Will Submit - Team: " + myTeam.teamNumber + " Match: " + myMatch.getMatchNumber (), bigStyle);
//			if (GUI.Button (new Rect (Screen.width - 100, Screen.height - 50, 100, 50), "Submit")) {
//				myMatch.submitMatch ();
//				myTeam = (Team)teams [0];
//				myMatch = myTeam.getMatch (0);
//				//TODO submit the team to a json object
//			}
//		}
//		backScreenButton ();
//		nextScreenButton ();
//		currPosX = 25;
////		if (addMode) { TODO add textures for add and sub and create an add button above the low bar
////			if(GUI.Button(new Rect))
////		} else {
////		}
////		addButton(lowBarImage, chevalCount, false);
//	}
//
//	void addButton_pregame(Texture topTexture, Texture bottomTexture, ref bool topActive, ref bool bottomActive){
//		if (topActive) {
//			GUI.Label (new Rect ((float)(currPosX + (topTexture.width * imageScaling / 2.0)), (float)(preGame_defensesPosY - ((topTexture.height * imageScaling) + padding + 20)), 100.0f, 20.0f), "Enabled");
//		} else {
//			GUI.Label(new Rect((float)(currPosX+(topTexture.width*imageScaling/2.0)),(float)(preGame_defensesPosY-((topTexture.height*imageScaling)+padding+20)),100.0f,20.0f), "Disabled");
//		}
//
//		if(GUI.Button (new Rect((float)currPosX,(float)(preGame_defensesPosY-(topTexture.height*imageScaling+padding)),(float)(topTexture.width*imageScaling),(float)(topTexture.height*imageScaling)), topTexture) ) {
//			topActive = true;
//			bottomActive = false;
//		}
//
//		if (bottomActive) {
//			GUI.Label (new Rect ((float)(currPosX + (bottomTexture.width * imageScaling / 2.0)), (float)(preGame_defensesPosY + ((bottomTexture.height * imageScaling) + padding)), 100.0f, 20.0f), "Enabled");
//		} else {
//			GUI.Label (new Rect ((float)(currPosX + (bottomTexture.width * imageScaling / 2.0)), (float)(preGame_defensesPosY + ((bottomTexture.height * imageScaling) + padding)), 100.0f, 20.0f), "Disabled");
//		}
//
//		if(GUI.Button (new Rect((float)currPosX,(float)preGame_defensesPosY,(float)(bottomTexture.width*imageScaling),(float)(bottomTexture.height*imageScaling)), bottomTexture) ) {
//			topActive = false;
//			bottomActive = true;
//		}
//		currPosX += (int)(bottomTexture.width*imageScaling + padding);
//	}
//
//	void addButton_midgame(Texture myTexture, ref int myCount){
//		GUI.Label(new Rect((float)(currPosX+(myTexture.width*imageScaling/2.0)),(float)(midGame_defensesPosY-(20+padding)),100.0f,20.0f), ""+myCount);
//		if(GUI.Button (new Rect((float)currPosX,(float)midGame_defensesPosY,(float)(myTexture.width*imageScaling),(float)(myTexture.height*imageScaling)), myTexture) ) {
//			if (addMode) {
//				myCount++;
//			} else {
//				myCount--;
//			}
//		}
//		currPosX += (int)(myTexture.width*imageScaling + padding);
//	}
//
//	void nextScreenButton(){
//		if (screen != 4) {
//			if (GUI.Button (new Rect (Screen.width - 100, Screen.height - 50, 100, 50), "Next")) {
//				screen++;
//			}
//		}
//	}
//
//	void backScreenButton(){
//		if (screen != 1) {
//			if (GUI.Button (new Rect (0, Screen.height - 50, 100, 50), "Back")) {
//				screen--;
//			}
//		}
//	}
//
//	void addMatch(int teamNumber, int matchNumber){
//		bool teamFound = false;
//		foreach (Team checkTeam in teams) {
//			if (checkTeam.teamNumber == teamNumber) {
//				teamFound = true;
//				if (checkTeam.getMatch (matchNumber) == null) {
//					checkTeam.createMatch (matchNumber);
//					myTeam = checkTeam;
//					myMatch = checkTeam.getMatch (matchNumber);
//				} else {
//					//TODO error the team already contains the given match
//				}
//			}
//		}
//
//		if (!teamFound) {
//			Team tempTeam = new Team ();
//			tempTeam.createTeam (teamNumber);
//			tempTeam.createMatch (0);
//			myTeam = tempTeam;
//			myMatch = tempTeam.getMatch (matchNumber);
//		}
//	}
//
//	// Update is called once per frame
//	void Update () {
//	
//	}
//}
