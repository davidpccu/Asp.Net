interface , abstract , virtual 這幾個東西其實都很像,簡單來說都可以讓後面繼承的對像自己去實作 or 修改 method

+ abstract 和 virtual 用在基礎類別(父類別)中
+ override 和 new 用在派(衍)生類別（子類別）中

### interface 介面

```C#

namespace MySample
{
    interface SampleInterFace
    {
        void testMethod();

        //下面反註解掉會編譯錯誤,介面的method被實做必定得是public屬性,但本身不能宣告屬性
        //public void testMethod();

        //下面反註解掉會編譯錯誤,介面裡頭不能宣告fields
        //int test;

        //下面反註解掉會編譯錯誤,介面裡頭不能有任何真正實做
        //void testMethod() { }
    }
    
    class test1 : SampleInterFace
    {
        //若沒這下面實作,會編譯報錯
        public void testMethod()
        {
            throw new NotImplementedException();
        }
    }
}

```

### abstract 抽象

+ abstract 抽象方法，是空的方法，沒有方法實體，派(衍)生類必須以 override 實現此方法。

```C#

namespace MySample
{
    abstract class Sampleabstract
    {
        abstract public void testMethod();

        //下面反註解掉會編譯錯誤,抽像類別中無實作的method一定得加上abstract關鍵字
        //public void testMethod2();

        //抽像類別中可以實作method
        public void testMetod2()
        {
            Console.WriteLine("hello");
        }

        //抽像類別中可以定義fields
        int test = 0;
    }


    class test2 : Sampleabstract
    {
        //有abstract關鍵字的methed "一定需要用" override實作
        public override void testMethod()
        {
            throw new NotImplementedException();
        }
    }
}

```

### virtual 虛擬

+ virtual 虛擬方法，若希望或預料到基礎類別的這個方法在將來的派(衍)生類別中會被覆寫（override 或 new），則此方法必須被聲明為 virtual。

```C#

namespace MySample
{
    class Sampleclass
    {
        virtual public void testMethod()
        {
            Console.WriteLine("hello");
        }

        //下面反註解掉會編譯錯誤,virtual必定需要為public屬性
        //virtual void testMethod() { }

        //下面反註解掉會編譯錯誤,virtual必定需要實作
        //virtual public void testMethod();
    }

    class test3:Sampleclass
    {
        //有virtual關鍵字的methed "可以用"  override實作
        public override void testMethod()
        {
            throw new NotImplementedException();
        }
    }
}

```
