<Query Kind="Program" />

void Main()
{
	Console.WriteLine("\n\nOpen Close Principle Demo ");

	DataProvider DataProviderObject = new SqlDataProvider();
	DataProviderObject.OpenConnection();
	DataProviderObject.ExecuteCommand();
	DataProviderObject.CloseConnection();
}

// Define other methods and classes here

interface DataProvider
{
	int OpenConnection();
	int CloseConnection();
	int ExecuteCommand();
	int BeginTransaction();
}
class SqlDataProvider : DataProvider
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