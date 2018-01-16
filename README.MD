# SkypeBotMVC ASP.NET Core SignalR  MS Bot SKYPE

Demo video https://www.youtube.com/watch?v=npWNxS_Dnv0

1) git clone https://github.com/Arpanx/SkypeBotMVC.git
2) cd SKYPE/
3) dotnet  build
4) dotnet run

The program was launched at "http://localhost:52901/"
Now we need to make this site available on the external Internet via HTTPS

https://ngrok.com/download  ngrok.exe need for proxy
download this file and run by specifying such parameters on the command line

ngrok.exe http -host-header=rewrite 52901
The program must be running and accessible via HTTPS on the Internet
Bot expects the program to be accessible at  https://1277d8e6.ngrok.io/api/messages
(Set your current address where the program is available)

![Alt text](https://github.com/Arpanx/SkypeBotMVC/blob/master/docs/1.jpg "ngrok")

# It is necessary to create an MS Bot account
5)  https://dev.botframework.com/bots/new
6) The name is any convenient (not important)
![Alt text](https://github.com/Arpanx/SkypeBotMVC/blob/master/docs/2.jpg "Edit BotName")
7) Create AppID & password
![Alt text](https://github.com/Arpanx/SkypeBotMVC/blob/master/SKYPE/docs/3.jpg "Create AppID & password")
8) Finish registration
![Alt text](https://github.com/Arpanx/SkypeBotMVC/blob/master/SKYPE/docs/4.jpg "Finish")
9) add a Skype messenger
![Alt text](https://github.com/Arpanx/SkypeBotMVC/blob/master/SKYPE/docs/5.jpg "add a Skype")
10) We go to the messaging tab, we look that the message is allowed to be sent.
!! It's important not to publish Bot. (While he will wait for confirmation of publication, will not work.)
In the preview mode it works great
![Alt text](https://github.com/Arpanx/SkypeBotMVC/blob/master/SKYPE/docs/6.jpg "Finish")

11) Add into Skype contacts  https://join.skype.com/bot/xxxxxxxxx-e6be-49xx-8xx7-60xxxxx5a2ccc   <- your App ID

12) Сheck you appsetting.json

"MicrosoftAppId": "50.......9-e6be-49cd-8877-6......2ccc",
  "MicrosoftAppPassword": "arkEW7........G005*{",
  "SkypeApiURL": "https://smba.trafficmanager.net/apis/",
  "LocalHubSignalrURL": "http://localhost:52901/chat"

13) Set the Skype login in the top field and press the Set button
Now you can write a message and send the user whom you specified, you can exchange messages and see a dialog

14) I used examples from the documentation, SO, GitHub Issue
 https://docs.microsoft.com/en-us/bot-framework/
 https://github.com/Microsoft/BotBuilder
