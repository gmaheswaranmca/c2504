//v1, we define first fields and define properties for the fields
class Flight
{
    private string number;
    private int capacity;
    public string Number
    {
        set { number = value; }
        get { return number;  }
    }
    public int Capacity
    {
        set { capacity = value; }
        get { return capacity; }
    }
}
//v2, if fields only setting/getting, go for auto properties from modern day C#
class Flight
{
    public string Number{set;get;}
    public int Capacity { set; get; }

    //only whereever we define logic either at setting or at getting, there you go for "field based proeprty"
    private float ticketPrice;
    public float TicketPrice {
        set { /*logic*/ ticketPrice = value;}
        get { return ticketPrice;}
    }
}