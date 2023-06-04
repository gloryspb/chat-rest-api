namespace udp_chat_server.Models;

public class ChatMessage
{
    public string Id { get; set; }
    public string Sender { get; set; }
    public string Text { get; set; }
}