<Query Kind="Program" />

void Main()
{
	IDatabase cust = new Customer();
	
	cust.Add();
	
	cust.Read(); // 新的用法，在 Main() 底下不需要執行 Add() 方法
}

// Define other methods and classes here

interface IDatabase
{
	void Add();  // 原本的 client 只用的到 Add() 的方法而已
	
	void Read(); // 全新加入的新 client 才會用到 Read() 方法
}

class Customer : IDatabase
{
	public void Add()
	{
		Console.WriteLine("Add something");
	}
	
	public void Read()
	{
		Console.WriteLine("Read something");
	}
}