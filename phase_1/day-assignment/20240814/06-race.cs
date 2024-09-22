class RaceTrack
{
    public int Distance { set; get; }

    public RaceTrack(int _distance)
    {
        this.Distance = _distance;
    }
    public bool IsGt(RaceTrack other)
    {
        return this.Distance > other.Distance;
    }
    public bool IsEq(RaceTrack other)
    {
        return this.Distance == other.Distance;
    }
    /*public override bool Equals(object obj)
    {
        //return base.Equals(obj);
        return this.IsEq((RaceTrack)obj);
    }
    public override int GetHashCode()
    {
        return this.Distance.GetHashCode(); // ^ op
    }*/
    public override string ToString()
    {
        return $"[Distance={this.Distance}]";
    }

}
internal class Program
{
    static void Main(string[] args)
    {
        RaceTrack firstTrack = new RaceTrack(500);
        RaceTrack secondTrack = new RaceTrack(500);//1000
        if (firstTrack.IsGt(secondTrack))
        {
            Console.WriteLine($"first track {firstTrack} is greater than second track {secondTrack}");
        }
        else if (firstTrack.IsEq(secondTrack  // working for programmer's method
        //else if (firstTrack.Equals(secondTrack)) // working only with Equals overridden
        {
            Console.WriteLine($"first track {firstTrack} is equal to second track {secondTrack}");
        }
        else
        {
            Console.WriteLine($"first track {firstTrack} is less than to second track {secondTrack}");
        }
    }
}