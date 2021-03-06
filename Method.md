用 參數 控制函式行為的，就叫 "多載"。
用 類別 控制函式行為的，就叫 "多型"。

### Overload 多載

相同的模樣，擁有不同的行為

簡單說就是相同的方法但是有可能所帶入的參數不同，有的代入 int 或是string

也就是相同的 方法名稱，擁有不同的 實作。

``` C#

void test();
void test(int i);
void test(char c);
void test(String s, int i);
void test(String s, String s2);

```

### Polymorphism 多型

《多型》與繼承息息相關，繼承了父類別的方法並且覆寫成新的方法

一個訊息（message or event or stimulus）的意義是由接收者（接收到這個訊息的物件）來解釋，而不是由訊息發出者（sender）來解釋。所以，在runtime時只要接受者換成不同的物件或是instance，系統的行為就會改變。具有這樣的特性就稱之為polymorphism。

搞笑一點的解釋就是 :

Teddy（sender，等一下準備送出信息的物件）走在路上看到前方有兩位名人，分別是「林志玲」與「阿美姐」（等一下準備接收訊息的兩個物件），於是大喊一聲「美女請留步（訊息）」。理論上Teddy期待只有「林志玲」會「回頭」（訊息接收者的行為），沒想到「阿美姐」也回頭了...XD。所以說，一個訊息的解釋是由接收者來決定的，而不是送出者。如果一個系統具有這樣的特性，那麼我們就說這個系統具備多型的行為。


``` C#

public class Program
{
    public static void Main()
    {
        Parent cObj = new Child();
        cObj.Name = "ccc";
        cObj.Print();
    }
}

public class Parent
{
    public string Name { get; set; }   

    public void Print()
    {
        Console.WriteLine("Parent Name: " + this.Name );
    }     
}

public class Child : Parent
{
    new public void Print()
    {
        Console.WriteLine("Child Name: " + this.Name );
    }     
}

//output: Child Name: ccc

```
### Override 複寫

父類別為Class1(基底類別)，子類別為Class2(衍生類別)

Class2繼承Class1時，子類別的方法名可能會和父類別的方法名稱相同，但其實裡面的邏輯不同

而這個時候，我們就可以在父類別的方法裡面加上Virtual，子類別裡面的方法加上override，來進行方法邏輯複寫的動作

``` C#

namespace ConsoleApplication1
{
    public class Class1
    {
        //多加一個方法
        public void PreTest()
        {
            Console.WriteLine("PreTest()");
            Test();
        }
        //
        public virtual void Test()
        {
            Console.WriteLine("Class1.Test()");
        }
    }

    public class Class2 : Class1
    {
        //使用override
        public override void Test()
        {
            Console.WriteLine("Class2.Test()");
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            
            Class2 c = new Class2();
            //改成呼叫c.PreTest()
            c.PreTest();//出現的是Class2.Test()

            //讓畫面可以暫停。
            Console.ReadLine();
        }
    }
}

```

### new

new關鍵字會保留產生該輸出的關聯性，但是它會隱藏警告，隱藏繼承自基底類別的成員

``` C#

namespace ConsoleApplication1
{
    public class Class1
    {
        //多加一個方法
        public void PreTest()
        {
            Console.WriteLine("PreTest()");
            Test();
        }
        //
        public void Test()
        {
            Console.WriteLine("Class1.Test()");
        }
    }

    public class Class2 : Class1
    {
        //使用new關鍵字，讓編譯器開心一點。
        public new void Test()
        {
            Console.WriteLine("Class2.Test()");
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            
            Class2 c = new Class2();
            //改成呼叫c.PreTest()
            c.PreTest();//出現卻是Class1.Test()!!?

            //讓畫面可以暫停。
            Console.ReadLine();
        }
    }
}

```

無論是Class1或是Class2都還存著各自的Test方法

而C#的機制，當繼承的Class2並無特別的撰寫PreTest方法，所以會回到Class1裡面去執行PreTest

當執行到Test()這行的時候，又因為Class2不是使用Override的方式來複寫Class1的Test方法，所以就會直接使用Class1的方法

所以如果真的要執行Class2的Test方法，就必須要使用Override

[參考](https://dotblogs.com.tw/skychang/2012/05/10/72114)

### 多型後的override

``` C#

namespace ConsoleApplication1
{
    public class Class1
    {
        //因為要使用override所以加上Virtual
        public virtual void Test()
        {
            Console.WriteLine("Class1.Test()");
        }
    }

    public class Class2 : Class1
    {
        //使用override關鍵字來複寫
        public override void Test()
        {
            Console.WriteLine("Class2.Test()");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //我們用個多型吧!
            Class1 c = new Class2();
            c.Test();//結果並不易外，出現的是Class2.Test()

            //讓畫面可以暫停。
            Console.ReadLine();
        }
    }
}

```

Class2複寫了Class1的Test方法，所以呼叫c.Test()的時候，因為知道Class2有加上override關鍵字，所以實際是呼叫Class2的Test方法。

#### 多形後的new

``` C#

namespace ConsoleApplication1
{
    public class Class1
    {
        //使用new，就可以不加上virtual
        public void Test()
        {
            Console.WriteLine("Class1.Test()");
        }
    }

    public class Class2 : Class1
    {
        //使用new關鍵字
        public new void Test()
        {
            Console.WriteLine("Class2.Test()");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //我們用個多型吧!
            Class1 c = new Class2();
            c.Test();//結果超易外，出現的是Class1.Test()

            //讓畫面可以暫停。
            Console.ReadLine();
        }
    }
}

```

C#預設的情況下，會先處理變數型別的方法，例如上面的程式碼，變數型別為Class1

所以預設如果執行c.Test()，則會進行Class1的Test方法，除非Class2的Test有明確的加上override關鍵字，這時候，才會進行Class2的Test方法。


> new 和 override結論

> 會有這樣的機制，是為了擴充上的彈性，假設目前的架構是Class1裡面沒有任何方法，而Class2裡面有寫一個Test方法，過了一段時間，可能Class1也加上了Test方法，這時候Class1和Class2也都有了Test方法了，此時，就算編譯，依然是沒有任何的問題的，如下。

``` C#

c1.Test();
Class2 c2 = new Class2();//不影響，還是呼叫Class2的Test
c2.Test();
Class1 c3 = new Class2();//不影響，在Class1加上Test之前，是不可能這樣寫的
c3.Test();
Class2 c4 = new Class1();//怎麼可能會有這種寫法勒...

```

