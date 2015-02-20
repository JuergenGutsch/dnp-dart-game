using System;

public class Player
{
    private string v;
    
    public Player(string name)
    {
        Name = name;
        Score = 501;
    }

    public string Name { get; set; }
    public int Score { get; set; }
}
