using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WebSocketSharp;

public class WebsocketConnection : MonoBehaviour
{
    WebSocket ws;
    public void Start()
    {
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

        ws.Connect();
    }
    public void Update()
    {
        if (ws == null)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            WebsocketSendText("Ping");
        }
    }

    private void WebsocketSendText(string text)
    {
        ws.Send(text);
    }

    private void WebsocketSendText(string text)
    {
        ws.Send(text);
    }
}