using System;

[System.Serializable]
public class Reservation
{
    public string parking;
    public string datum; //DateTime
    public string time;
    public string quantity;

    public Reservation()
    {
     string parking = this.parking;
     string datum = this.datum; //DateTime
     string time = this.time;
     string quantity = this.quantity;
}

}
