## ASP.NET Web API 2

> Web API 路由非常類似MVC 路由系統，差異在於Web API 使用HTTP Method，而不是MVC 的URL 路徑來選擇Action

### RESTful 

> RESTful API 是一種設計風格，這種風格使API設計具有整體一致性，易於維護、擴展，並充分利用HTTP協定的特點


### CRUD Request (POST / GET / PUT / DELETE)

||POST|GET|PUT|DELETE|
|:-----|:----- |:-------|:-----|----- |
|用途|新增資料|取得資料|更新資料|刪除資料
|資料傳遞方式|Entity Body|URL |Entity Body / URL|	URL
|對應SQL|Insert|Select|Update|Delete
|安全性|中|高|低|低
> 簡單的四個操作，分別代表我們最常對資料所做的四種行為，新增、搜尋、修改、刪除

### ROUTING

|動作|HTTP方法|路由|URI|
|:-----|:----- |:-------|:-----|
|取得全部使用者資料	|GET	|/api/users|/api/users|
|取得特定使用者資料	|GET	|/api/users/{Id}|/api/users?id=a123456789|
|新增資料	|POST	|/api/users	|/api/users|
|更新資料	|PUT	|/api/users/{id}|/api/users/a123456789|
|刪除資料	|DELETE	|/api/users/{id}|/api/users/a123456789|

### 建立專案

![](https://i.imgur.com/7dTkHpX.png)

### 專案結構

![](https://i.imgur.com/4nbeDny.png)

+ App_Data：專案會使用到的資料檔，包含如MDF、XLSX、XML、JSON...等。
+ App_Start：預設在這個資料夾中有一個WebApiConfig.cs檔，他記錄了Web API的Routing設定，工程師也可以在這裡去設計自己的Routing。
+ Controllers：放置控制器的所在地，也就是所有商業邏輯、演算法...等程式放置的地方。
+ Models：定義資料模型、處理資料(操作資料庫、檔案)程式都放在這邊。
+ Global.asax：用於設計回應HTTPModules所對應的應用程式層級事件的程式碼，如設定對應的Routing...等。
+ Web.config：整個專案的設定檔。

### Ashx  與 Web API 2的差異

![](https://i.imgur.com/pkc1X4b.png)

