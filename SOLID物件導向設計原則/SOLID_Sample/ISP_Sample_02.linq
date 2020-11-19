<Query Kind="Program" />

void Main()
{
	Console.WriteLine("\n\nOpen Close Principle Demo ");

	IReadAndWrite Logger = new Logger();
	Logger.Write();
	Logger.Read();
}

interface IReadAndWrite {
	string Read();
	void Write();
}

class Logger : IReadAndWrite {
	public string Read(){ return "";}
	public void Write() {}
}