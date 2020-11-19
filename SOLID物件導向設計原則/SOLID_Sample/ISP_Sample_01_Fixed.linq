<Query Kind="Program" />

void Main()
{
	Console.WriteLine("\n\nOpen Close Principle Demo ");

	DataProviderWithoutTransaction DataProviderObject = new SqlDataProvider();
	DataProviderObject.OpenConnection();
	DataProviderObject.ExecuteCommand();
	DataProviderObject.CloseConnection();
}

// Define other methods and classes here

interface DataProviderWithoutTransaction
{
	int OpenConnection();
	int CloseConnection();
	int ExecuteCommand();
}

interface DataProvider : DataProviderWithoutTransaction
{
	int BeginTransaction();
}

class SqlDataProvider : DataProvider, DataProviderWithoutTransaction
{
	public int OpenConnection()
	{
		Console.WriteLine("\nSql Connection opened successfully");
		return 1;
	}
	public int CloseConnection()
	{
		Console.WriteLine("Sql Connection closed successfully");
		return 1;
	}
	public int ExecuteCommand()
	{
		Console.WriteLine("Sql Command Executed successfully");
		return 1;
	}
	public int BeginTransaction()
	{
		Console.WriteLine("Sql BeginTransaction started");
		return 1;
	}
}