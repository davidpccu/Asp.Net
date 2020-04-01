## Web Service
1. 基於SOAP協議，存儲格式為XML
2. 只支援HTTP通訊協定，透過WSDL定義接口
3. 非開源，但可以被任何一個了解XML的人使用
4. 只能佈署在IIS上面

## WCF
1. 初始一樣為SOAP，存儲格式為XML
2. 為Web Service進化版，可支援像TCP，HTTP，HTTPS，Named Pipes, MSMQ等等通訊協定
3. 非開源，但可以被任何一個了解XML的人使用
4. 可以佈署在應用程式、IIS、Windows服務中
5. 缺點為設定方式繁瑣

## Web API
1. 為一種建立HTTP服務的新框架
2. 在.net平台上，Web API是一種用來建立理想的、開源的REST-ful的技術
3. 不像WCF REST Service，它可以使用HTTP的全部特點（比如URIs、Request/Response Header，暫存，版本控制，多種內容格式）
4. 它也支持MVC的特徵，像Route、Controller、Action、Filter、Model-Binding、控制反轉（IOC）或依賴注入（DI），單元測試。這些可以使程式更簡單、更健壯
5. 它可以部署在應用程序和IIS上
6. 為一個輕量級的框架，並且對限制頻寬的設備如智慧型手機支援良好
7. Response可以被Web API的MediaTypeFormatter轉換成Json、XML 或者任何想轉換的格式。

### 使用時機

1. 當你想建立一個支援訊息、訊息佇列、雙工通訊的服務時，你應該選擇WCF
2. 當你想建立一個服務，可以用更快速的傳輸通道時，像TCP、Named Pipes或者甚至是UDP（在WCF4.5中）,在其他傳輸通道不可用的時候也可以支援HTTP。
3. 當你想建立一個基於HTTP的面向資源的服務並且可以使用HTTP的全部特徵時（比如URIs、request/response頭，快取，版本控制，多種內容格式），你應該選擇Web API
4. 當你想讓你的服務用於瀏覽器、手機、iPhone和平板電腦時，你應該選擇Web API
