using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Grpc.Core;
using Protocolor;

public class ColorClient : MonoBehaviour
{
    private readonly ColorGenerator.ColorGeneratorClient _client;
    private readonly Channel _channel;
    private readonly string _server = "127.0.0.1:50051";

    internal string GetRandomColor(string currentColor)
    {
        var randomColor = _client.GetRandomColor(new CurrentColor { Color = currentColor });
        Debug.Log("Client is currently using color: " + currentColor +
                  " switching to: " + randomColor.Color);

        return randomColor.Color;
    }
    internal ColorClient()
    {
        _channel = new Channel(_server, ChannelCredentials.Insecure);
        _client = new ColorGenerator.ColorGeneratorClient(_channel);
    }
    // Start is called before the first frame update
    void Start()
    {
    }
    private void OnDisable()
    {
        _channel.ShutdownAsync().Wait();
    }
// Update is called once per frame
void Update()
    {
        
    }
}
