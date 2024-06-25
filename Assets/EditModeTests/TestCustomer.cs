using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using JetBrains.Annotations;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TestCustomer
{
    
    [SetUp]
    public void SetupCustomers()
    {
        Store testStore = new("Block Buster");

        testStore.LoadData("customers");
        testStore.LoadData("inventory");
    }

    // A Test behaves as an ordinary method
    [Test]
    public void TestDataUnpackedFromCSVCustomers()
    {
        // Arrange
        int expectedCount = 6;

        // Act
        int actualCount = Customer.customers.Count;
        // Use the Assert class to test conditions

        Assert.That(actualCount, Is.EqualTo(expectedCount));
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator TestCustomerWithEnumeratorPasses()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;
    }
    
}
