<Query Kind="Program" />

void Main()
{
	List<Customer> Customers = new List<Customer>();
	Customers.Add(new SilverCustomer());
	Customers.Add(new GoldCustomer());
	// Customers.Add(new Enquiry());

	foreach (Customer o in Customers)
	{
		o.Add();
	}
}

// Define other methods and classes here

interface IDiscount
{
	double getDiscount(double TotalSales);
}

interface IDatabase
{
	void Add();
}

class Customer : IDiscount, IDatabase
{
	public virtual double getDiscount(double TotalSales)
	{
		return TotalSales;
	}

	public virtual void Add()
	{
	}
}

class GoldCustomer : Customer
{
	public override double getDiscount(double TotalSales)
	{
		return base.getDiscount(TotalSales) - 5;
	}

	public override void Add()
	{
		Console.WriteLine("GoldCustomer: Add");
	}
}


class SilverCustomer : Customer
{
	public override double getDiscount(double TotalSales)
	{
		return base.getDiscount(TotalSales) - 5;
	}

	public override void Add()
	{
		Console.WriteLine("SilverCustomer: Add");
	}
}

class Enquiry : IDiscount
{
	public double getDiscount(double TotalSales)
	{
		return TotalSales - 5;
	}
}
