<Query Kind="Program" />

void Main()
{
	var o = new Customer(LoggerType.Email);
	o.Add();
}

// Define other methods and classes here

class Customer
{
	// LSP
	private ILogger obj = new FileLogger();

	private LoggerType logtype = LoggerType.File;

	public Customer(LoggerType type)
	{
		this.logtype = type;
	}

	public virtual void Add()
	{
		try
		{
			// Database code goes here
		}
		catch (Exception ex)
		{
			if (this.logtype == LoggerType.Email)
			{
				this.obj = new EmailLogger();
			}
			else if (this.logtype == LoggerType.EventLog)
			{
				this.obj = new EventLogLogger();
			}
			else
			{
				this.obj.Handle(ex.Message.ToString());
			}
		}
	}
}

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

class EmailLogger : ILogger
{
	public void Handle(string error)
	{
		// send errors in email
	}
}

class EventLogLogger : ILogger
{
	public void Handle(string error)
	{
		// log errors to event viewer
	}
}

enum LoggerType {
	File,
	Email,
	EventLog
}