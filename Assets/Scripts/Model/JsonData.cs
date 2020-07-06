using System.Collections.Generic;
using System;
using UnityEngine;


public class JsonHelper
{
    public static T[] getJsonArray<T>(string json)
    {
        string newJson = "{ \"array\": " + json + "}";
        Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(newJson);
        return wrapper.array;
    }

    public static string ToJson<T>(T[] items)
    {
        Wrapper<T> wrapper = new Wrapper<T>();
        wrapper.array = items;
        return JsonUtility.ToJson(wrapper);
    }

    public static string ToJson<T>(T[] items, bool prettyPrint)
    {
        Wrapper<T> wrapper = new Wrapper<T>();
        wrapper.array = items;
        return JsonUtility.ToJson(wrapper, prettyPrint);
    }

    public static List<T> FromJson<T>(string json)
    {
        Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
        return wrapper.result;
    }



    [Serializable]
    private class Wrapper<T>
    {
#pragma warning disable
        public T[] array;
        public List<T> result;
#pragma warning restore
    }
}


[Serializable]
public class RootObject
{
    public int id;
    public int daily_payment; 
    public string name; 
    public int id_type; 
    public int has_custom_business_hours; 
    public string address; 
    public int is_payment_enabled; 
    public object vendor_parking_lot_id; 
    public int ppk_only; 
    public object description; 
    public int capacity;
    public int capacity_handicap;
    public int capacity_taxi; 
    public int capacity_reserved; 
    public int capacity_echarge; 
    public double lat; 
    public double lng; 
    public int is_active; 
    public object zoneId; 
    public object zone; 
    public object price; 
    public object price_extra; 
    public object daily_price; 
    public object period; 
    public object sms_number;
    public object color_hex; 
    public object max_duration; 
    public int has_sensors;
    public object lot_daily_price; 
    public int normal_available; 
    public int normal_occupied; 
    public int handicap_available; 
    public int handicap_occupied; 
    public object open_time; 
    public object close_time; 
    public string type; 
    public int capacity_normal; 
    public List<ParkingSpace> parkingSpaces; 
}

[Serializable]
public class ParkingSpace
{
    public int id; 
    public int id_parking_lot; 
    public int id_parking_type; 
    public int occupied; 
    public double lat; 
    public double lng; 
    public DateTime updated_at; 
    public string parking_space_name; 
    public DateTime last_event; 
    public string type; 
    public int is_visible; 

}