// using UnityEngine;
// using System.Collections;

// namespace LostPolygon.AndroidBluetoothMultiplayer {
// 	public class Bluetooth {

// 		private string uuid = "d49ef938-3050-4a65-82e7-8e712403b447";

// 		private const string kLocalIp = "127.0.0.1"; // An IP for Network.Connect(), must always be 127.0.0.1
//         private const int kPort = 28000; // Local server IP. Must be the same for client and server

//         private bool _initResult;
//         private BluetoothMultiplayerMode _desiredMode = BluetoothMultiplayerMode.None;

// 		// Use this for initialization
// 		static void init(){
// 			Init(uuid);
// 		}

// 		private void Awake(){
// 			_initResult = AndroidBluetoothMultiplayer.Initialize(uuid);

//             // Enabling verbose logging. See log cat!
//             AndroidBluetoothMultiplayer.SetVerboseLog(true);

//             AndroidBluetoothMultiplayer.ListeningStarted += OnBluetoothListeningStarted;
//             AndroidBluetoothMultiplayer.ListeningStopped += OnBluetoothListeningStopped;
//             AndroidBluetoothMultiplayer.AdapterEnabled += OnBluetoothAdapterEnabled;
//             AndroidBluetoothMultiplayer.AdapterEnableFailed += OnBluetoothAdapterEnableFailed;
//             AndroidBluetoothMultiplayer.AdapterDisabled += OnBluetoothAdapterDisabled;
//             AndroidBluetoothMultiplayer.DiscoverabilityEnabled += OnBluetoothDiscoverabilityEnabled;
//             AndroidBluetoothMultiplayer.DiscoverabilityEnableFailed += OnBluetoothDiscoverabilityEnableFailed;
//             AndroidBluetoothMultiplayer.ConnectedToServer += OnBluetoothConnectedToServer;
//             AndroidBluetoothMultiplayer.ConnectionToServerFailed += OnBluetoothConnectionToServerFailed;
//             AndroidBluetoothMultiplayer.DisconnectedFromServer += OnBluetoothDisconnectedFromServer;
//             AndroidBluetoothMultiplayer.ClientConnected += OnBluetoothClientConnected;
//             AndroidBluetoothMultiplayer.ClientDisconnected += OnBluetoothClientDisconnected;
//             AndroidBluetoothMultiplayer.DevicePicked += OnBluetoothDevicePicked;
// 		}

// 		protected override void OnDestroy() {
//             base.OnDestroy();

//             AndroidBluetoothMultiplayer.ListeningStarted -= OnBluetoothListeningStarted;
//             AndroidBluetoothMultiplayer.ListeningStopped -= OnBluetoothListeningStopped;
//             AndroidBluetoothMultiplayer.AdapterEnabled -= OnBluetoothAdapterEnabled;
//             AndroidBluetoothMultiplayer.AdapterEnableFailed -= OnBluetoothAdapterEnableFailed;
//             AndroidBluetoothMultiplayer.AdapterDisabled -= OnBluetoothAdapterDisabled;
//             AndroidBluetoothMultiplayer.DiscoverabilityEnabled -= OnBluetoothDiscoverabilityEnabled;
//             AndroidBluetoothMultiplayer.DiscoverabilityEnableFailed -= OnBluetoothDiscoverabilityEnableFailed;
//             AndroidBluetoothMultiplayer.ConnectedToServer -= OnBluetoothConnectedToServer;
//             AndroidBluetoothMultiplayer.ConnectionToServerFailed -= OnBluetoothConnectionToServerFailed;
//             AndroidBluetoothMultiplayer.DisconnectedFromServer -= OnBluetoothDisconnectedFromServer;
//             AndroidBluetoothMultiplayer.ClientConnected -= OnBluetoothClientConnected;
//             AndroidBluetoothMultiplayer.ClientDisconnected -= OnBluetoothClientDisconnected;
//             AndroidBluetoothMultiplayer.DevicePicked -= OnBluetoothDevicePicked;
//         }
// 	}
// }
