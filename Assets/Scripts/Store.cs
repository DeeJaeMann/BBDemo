using Codice.Client.Common.GameUI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Store
{
    public string name;

    public Store(string name)
    {
        this.name = name;
    }

    public void LoadData(string name)
    {
        // Load the asset as a TextAsset
        TextAsset dataset = Resources.Load<TextAsset>(name);
        // Split each line of the CSV
        string[] dataLines = dataset.text.Split('\n');

        // Loop through each row
        // Starts at 1 to skip the first line (header)
        for (int row = 1; row < dataLines.Length; row++)
        {
            // Split the columns
            string[] data = dataLines[row].Split(",");

            // Loop through the columns of the line
            /*
            for ( int column = 0; column < data.Length; column++)
            {
                Debug.LogFormat($"Index {row} Col {data[column]}");
               
            }
            */
            Dictionary<string,string> thisRecord = new();

            // Customers
            if ( name == "customers")
            {
                thisRecord["id"] = data[0];
                thisRecord["accountType"] = data[1];
                thisRecord["firstName"] = data[2];
                thisRecord["lastName"] = data[3];
                thisRecord["currentVideoRentals"] = data[4];

                // Run a switch on the accountType to use the correct customer class for object creation

                // This is just for testing

                switch (thisRecord["accountType"]) 
                {
                    case "sf" :
                        CustomerSf thisCustomerSf = new(int.Parse(thisRecord["id"]), thisRecord["accountType"], thisRecord["firstName"], thisRecord["lastName"], thisRecord["currentVideoRentals"]);
                        Customer.customers.Add(int.Parse(thisRecord["id"]), thisCustomerSf);
                        break;
                    case "sx" :
                        CustomerSx thisCustomerSx = new(int.Parse(thisRecord["id"]), thisRecord["accountType"], thisRecord["firstName"], thisRecord["lastName"], thisRecord["currentVideoRentals"]);
                        Customer.customers.Add(int.Parse(thisRecord["id"]), thisCustomerSx);
                        break;
                    case "pf" :
                        CustomerPf thisCustomerPf  = new(int.Parse(thisRecord["id"]), thisRecord["accountType"], thisRecord["firstName"], thisRecord["lastName"], thisRecord["currentVideoRentals"]);
                        Customer.customers.Add(int.Parse(thisRecord["id"]), thisCustomerPf);
                        break;
                    default : 
                        CustomerPx thisCustomerPx = new(int.Parse(thisRecord["id"]), thisRecord["accountType"], thisRecord["firstName"], thisRecord["lastName"], thisRecord["currentVideoRentals"]);
                        Customer.customers.Add(int.Parse(thisRecord["id"]), thisCustomerPx);
                        break;
                }
    
            }
            // Videos
            else
            {
                Debug.LogFormat($"Video Load Not Implemented Yet");
            }

        }

        //Debug.LogFormat($"Lines: {dataLines}");
    }
}
