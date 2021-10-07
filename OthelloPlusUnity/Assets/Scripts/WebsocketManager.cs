using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WebSocketSharp;

public class WebsocketManager : MonoBehaviour
{
    public static WebsocketManager Connection = null;
    private static WebSocket ws;


    public void Start()
    {
        if (Connection == null)
        {
            Connection = this;
        }
        else if (Connection != this)
        {
            Destroy(gameObject);
            return;
        }
        Debug.Log("Creating websocket");
        ws = new WebSocket("wss://othellotestserver.bw55555.repl.co");
        ws.SslConfiguration.EnabledSslProtocols = System.Security.Authentication.SslProtocols.Tls12;
        ws.OnMessage += (sender, e) =>
        {
            Debug.Log($"Received {e.Data} from server");
            Debug.Log($"Sender: {((WebSocket)sender).Url}");
        };
        ws.OnError += (sender, e) => {
            Debug.Log($"Websocket Error: {e.Message}");
        };
        ws.OnClose += (sender, e) => {
            Debug.Log($"Websocket Closed: {e.Reason}");
        };
        ws.Connect();
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            WebsocketSendText("Ping");
        }
    }

    public static void WebsocketSendText(string text)
    {
        if (ws == null) { Debug.Log("Hi3"); return; }
        ws.Send(text);
    }
}