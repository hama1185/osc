using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityOSC;


public class oscClient : MonoBehaviour
{
    #region Network Settings //----------追記
	public string clientId;
    public string ip;
    public int port;
	#endregion //----------追記
    // Start is called before the first frame update
    void Start(){
        OSCHandler.Instance.clientInit(clientId, ip,port);//ipには接続先のipアドレスの文字列を入れる。
    }

    // Update is called once per frame
    void Update(){
        List<float> xylist = new List<float>();
        xylist.Add(transform.position.x);
        xylist.Add(transform.position.y);
        xylist.Add(transform.position.z);
        OSCHandler.Instance.SendMessageToClient("Akaoni","/position",xylist);//Akaoniでいいのかな
    }
}
