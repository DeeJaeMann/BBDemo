using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer
{
    public static Dictionary<int, Customer> customers = new();

    public int id;
    public string accountType;
    public string firstName;
    public string lastName;
    public string currentVideoRentals;

    public Customer(int id, string accountType, string firstName, string lastName, string currentVideoRentals)
    {
        this.id = id;
        this.accountType = accountType;
        this.firstName = firstName;
        this.lastName = lastName;
        this.currentVideoRentals = currentVideoRentals;

    }

    public string PrintData()
    {
        return $"Id: {this.id} - Account Type: {this.accountType} - Name: {this.firstName} {this.lastName} - Video Rentals: {this.currentVideoRentals}";
    }
}
