<Query Kind="Program" />

void Main()
{
	var o = new Customer();
	o.Add();
}

// Define other methods and classes here

class Customer
{
	// LSP
	private ILogger obj = new FileLogger();
	
	public virtual void Add()
	{
		try
		{
			// Database code goes here
		}
		catch (Exception ex)
		{
			this.obj.Handle(ex.ToString());
		}
	}
}

// ISP + OCP + SRP
interface ILogger
{
	void Handle(string error);
}

class FileLogger : ILogger
{
	public void Handle(string error)
	{
		System.IO.File.WriteAllText(@"c:\Error.txt", error);
	}
}
