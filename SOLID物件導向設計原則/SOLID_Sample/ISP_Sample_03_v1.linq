<Query Kind="Program" />

void Main()
{
	IDatabase cust = new Customer();
	
	cust.Add();
}

// Define other methods and classes here

interface IDatabase
{
	void Add();  // 原本的 client 只用的到 Add() 的方法而已
}

class Customer : IDatabase
{
	public void Add()
	{
		Console.WriteLine("Add something");
	}
}