using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityOSC;


public class oscControl : MonoBehaviour {

	#region Network Settings //----------追記
	public string serverName;
	public int inComingPort; //----------追記
	#endregion //----------追記

	private Dictionary<string, ServerLog> servers;

	// Script initialization
	void Start() {
		OSCHandler.Instance.serverInit(serverName,inComingPort); //init OSC　//----------変更
		servers = new Dictionary<string, ServerLog>();
		
	}

	// NOTE: The received messages at each server are updated here
	// Hence, this update depends on your application architecture
	// How many frames per second or Update() calls per frame?
	void Update() {
		
		OSCHandler.Instance.UpdateLogs();
		servers = OSCHandler.Instance.Servers;
		

		foreach( KeyValuePair<string, ServerLog> item in servers ){
			// If we have received at least one packet,
			// show the last received from the log in the Debug console
			if(item.Value.log.Count > 0){
				int lastPacketIndex = item.Value.packets.Count - 1;

				// UnityEngine.Debug.Log(String.Format("SERVER: {0} ADDRESS: {1} VALUE 0: {2}",
				// 	item.Key, // Server name
				// 	item.Value.packets[lastPacketIndex].Address, // OSC address
				// 	item.Value.packets[lastPacketIndex].Data[0].ToString())); //First data value

				Vector3 p = new Vector3((float)item.Value.packets[lastPacketIndex].Data[0],(float)item.Value.packets[lastPacketIndex].Data[1],(float)item.Value.packets[lastPacketIndex].Data[2]);
				transform.position = p;
				String str_x = item.Value.packets[lastPacketIndex].Data[0].ToString();
				String str_y = item.Value.packets[lastPacketIndex].Data[1].ToString();
				String str_z = item.Value.packets[lastPacketIndex].Data[2].ToString();
				Debug.Log("sub_x:" + str_x);
				Debug.Log("sub_y:" + str_y);
				Debug.Log("sub_z:" + str_z);

				//t.text = String.Format("SERVER: {0} ADDRESS: {1} VALUE 0: {2}",
				//	item.Key, // Server name
				//	item.Value.packets[lastPacketIndex].Address, // OSC address
				//	item.Value.packets[lastPacketIndex].Data[0].ToString());
			}
		}
	}
}