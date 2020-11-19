<Query Kind="Program" />

void Main()
{
	Console.WriteLine("\n\nOpen Close Principle Demo ");

	IWritable Logger = new Logger();
	Logger.Write();
	Logger.Read(); // not exist
}

interface IReadAndWrite : IReadable, IWritable {
}

interface IReadable {
	string Read();
}

interface IWritable {
	void Write();
}

class Logger : IReadAndWrite, IReadable, IWritable {
	public string Read(){ return "";}
	public void Write() { }
}