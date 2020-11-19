<Query Kind="Program" />

void Main()
{
	Console.WriteLine("\n\nOpen Close Principle Demo ");

	DataProvider DataProviderObject = new SqlDataProvider();
	DataProviderObject.OpenConnection();
	DataProviderObject.ExecuteCommand();
	DataProviderObject.CloseConnection();

	DataProviderObject = new OracleDataProvider();
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
}
class OracleDataProvider : DataProvider
{
	public int OpenConnection()
	{
		Console.WriteLine("Oracle Connection opened successfully");
		return 1;
	}
	public int CloseConnection()
	{
		Console.WriteLine("Oracle Connection closed successfully");
		return 1;
	}
	public int ExecuteCommand()
	{
		Console.WriteLine("Oracle Command Executed successfully");
		return 1;
	}
}

class OledbDataProvider : DataProvider
{
	public int OpenConnection()
	{
		Console.WriteLine("OLEDB Connection opened successfully");
		return 1;
	}
	public int CloseConnection()
	{
		Console.WriteLine("OLEDB Connection closed successfully");
		return 1;
	}
	public int ExecuteCommand()
	{
		Console.WriteLine("OEDB Command Executed successfully");
		return 1;
	}
}