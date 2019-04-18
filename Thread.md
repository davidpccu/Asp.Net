## Thread 執行緒 

一個處理序可能同時存在著一個以上的執行緒，你可以將其視為處理序所執行的工作。

多執行緒通常被應用在以下幾種狀況：

+ 耗時的運算工作：例如複雜的演算法，建立新的執行緒物件，可以讓程式進行運算同時，也可以指定其他工作，避免程式呆滯。
+ 等待回應訊息：例如讀取或是下載大量的檔案，當你等待這些工作完成之前，可以讓處理器執行其他工作，一旦接收到完成的回應事件時，才回來進行未完成的工作。

建立 Thread 物件時，傳入建構函式的委派有兩種版本。
一種是 ThreadStart，另一種是 ParameterizedThreadStart。以下是這兩種委派型別的宣告：

``` C#
public delegate void ThreadStart();
public delegate void ParameterizedThreadStart(Object obj);
```

如果在啟動工作執行緒時需要額外傳入一些資料，就可以使用第二種委派型別： ParameterizedThreadStart。參考以下範例：

``` C#
static void Main(string[] args)
    {
        Thread t1 = new Thread(MyBackgroundTask);
        Thread t2 = new Thread(MyBackgroundTask);
        Thread t3 = new Thread(MyBackgroundTask);

        t1.Start("X");
        t2.Start("Y");
        t3.Start("Z");

        for (int i = 0; i < 500; i++)
        {
            Console.Write(".");
        }
    }

    static void MyBackgroundTask(object param)
    {
        for (int i = 0; i < 500; i++)
        {
            Console.Write(param);
        }
    }
```
