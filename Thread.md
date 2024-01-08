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

## 執行緒安全 (Thread-safe)

程式設計為了提升效能，通常採用多執行緒的方式執行，但若沒有注意執行緒安全，往往會造成意想不到的錯誤。

最直接的例子就是資料庫，在現實中的 app 裡，我們可能有很多的執行緒同時在讀取跟寫入，在這個情況下同時讀取寫入就會造成資料庫的 exception 進而讓 app 閃退。一個比較好的作法可能是寫入的時候一個一個寫入，讀取等到所有的寫入完成後才從資料庫讀取最新的資料出來，如此一來讀取時就不會讀取到寫入到一半的資料，或者讀取到舊的資料了。

+ lock 保護不會被其他Thread中斷

## async/await
非同步(Asynchronous)不在於提高效能(Performance)，而是增加產能(Throughput)
非同步追求的是在相同時間內處理更多請求，而非以更快的速度處理掉一個請求。總體來看，同樣的請求量在更短時間內做完，說成「效能變好」也不算錯，但要記住，非同步的核心精神在於減少等待，讓執行緒同時處理更多作業藉以提升產能。
