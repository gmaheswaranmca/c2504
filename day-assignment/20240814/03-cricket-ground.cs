class Cricket
{
    public int LegSide { set; get; }
    public int OffSide { set; get; }
    public int Straight { set; get; }
    public int ThirdMan { set; get; }
    public Cricket(int _legside, int _offside, int _straight, int _thirdman)
    {
        this.LegSide = _legside;
        this.OffSide = _offside;
        this.Straight = _straight;
        this.ThirdMan = _thirdman;
    }
    public int FindShortestDistance()
    {
        return Math.Min(Math.Min(LegSide, OffSide), Math.Min(Straight, ThirdMan));
    }
    public bool GetSuitableGroundGt(Cricket other)
    {
        return this.FindShortestDistance() > other.FindShortestDistance();
    }
    public bool GetSuitableGroundEq(Cricket other)
    {
        return this.FindShortestDistance() == other.FindShortestDistance();
    }
    /*public override bool Equals(object obj)
    {
        return this.GetSuitableGroundEq((Cricket)obj);
    }
    public override int GetHashCode()
    {
        return this.LegSide.GetHashCode() ^ this.OffSide.GetHashCode() ^ this.Straight.GetHashCode() ^ this.ThirdMan.GetHashCode();
    }*/
    public override string ToString()
    {
        return $"[LegSide={this.LegSide},OffSide={this.OffSide},Straight={this.Straight},ThirdMan={this.ThirdMan},ShortestDistance={this.FindShortestDistance()}]";
    }

}
internal class Program
{
    static void Main(string[] args)
    {
        Cricket firstGround = new Cricket(65, 70, 75, 60);//60
        //Cricket secondGround = new Cricket(70, 68, 80, 65);//65
        Cricket secondGround = new Cricket(65, 70, 75, 60);//60
        if (firstGround.GetSuitableGroundGt(secondGround))
        {
            Console.WriteLine($"first ground {firstGround} is greater than second ground {secondGround}");
        }
        else if (firstGround.GetSuitableGroundEq(secondGround))
        //else if (firstGround.Equals(secondGround))
        {
            Console.WriteLine($"first ground {firstGround} is equal to second ground {secondGround}");

        }
        else
        {
            Console.WriteLine($"first ground {firstGround} is less than to second ground {secondGround}");

        }
    }
}