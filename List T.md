### List<T> 類別

表示可以依照索引存取的強類型物件清單。 提供搜尋、排序和管理清單的方法。

宣告List 時，不必事先宣告List 大小(或長度)，有點像是不用宣告長度的陣列(Array)

``` bash

// 以下List 裡int 型態
List<int> myIntLists = new List<int>();


// 在List 裡新增int 整數
myIntLists.Add(123456);


// 可用foreach 取出List 裡的值
foreach(string myStringList in myStringLists)
{
        Console.WriteLine(myStringList);
}

```

### Sort

``` bash

//這比較重要,使用 LINQ 和 sort 的屬性來做排序, 以下是以字長短來排列

 List<string> list = new List<string>();
 list.Add("mississippi"); // 最長值
 list.Add("indus");
 list.Add("danube");
 list.Add("nile"); // 最短值

 var lengths = from element in list
        orderby element.Length
        select element;


 foreach (string value in lengths)
 {
     Console.WriteLine(value);
 }

```

### Array to List

``` bash

int[] arr = new int[3]; 
 arr[0] = 2;
 arr[1] = 3;
 arr[2] = 5;
 List<int> list = new List<int>(arr); 

```


### Find

``` bash

List<int> list = new List<int>(new int[] { 19, 23, 29 });

// 找大於20
 
int result = list.Find(item => item > 20);

```

### Join List to string

``` bash

List<string> cities = new List<string>();
 cities.Add("New York");
 cities.Add("Mumbai");
 cities.Add("Berlin");
 cities.Add("Istanbul");
 

// Join strings into one CSV line
 string line = string.Join(",", cities.ToArray());
 Console.WriteLine(line);

```

### Insert

``` bash

List<string> dogs = new List<string>(); 

 dogs.Add("A dog");         // 內容: A
 dogs.Add("B dog");         // 內容: A, B


 dogs.Insert(1, "C dog");   // 內容: A, C, B
 
```

### Remove

``` bash

List<string> animals = new List<string>();
 animals.Add("狗");    
 animals.Add("貓"); 
 animals.Add("魚"); 
 animals.Add("蜘蛛");    
 animals.Add("螞蟻");    

animals.Remove("螞蟻"); // 移除螞蟻,它好像不是動物...

animals.RemoveAt(3);  // 移除蜘蛛,它好像也不是動物...

animals.RemoveRange(0, 2);  // 移除0-2
 
```