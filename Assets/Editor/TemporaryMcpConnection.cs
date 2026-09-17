using UnityEditor;
[InitializeOnLoad]
internal static class TemporaryMcpConnection
{
    static TemporaryMcpConnection()
    {
        EditorApplication.delayCall += () =>
        {
            MCPForUnity.Editor.Services.Transport.Transports.StdioBridgeHost.Start();
        };
    }
}
