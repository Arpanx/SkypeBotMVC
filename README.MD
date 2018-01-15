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

![Alt text](https://github.com/Arpanx/SkypeBotMVC/blob/master/SKYPE/docs/1.jpg "ngrok")

5) Add into Skype contacts  https://join.skype.com/bot/505b3669-e6be-49cd-8877-60c5525a2ccc
The program must be running and accessible via HTTPS on the Internet
Bot expects the program to be accessible at https://1277d8e6.ngrok.io/api/messages 
If the address is different, you need to change it in the bot settings.
https://dev.botframework.com/bots?id=Arpanx4

6) Set the Skype login in the top field and press the Set button
Now you can write a message and send the user whom you specified, you can exchange messages and see a dialog

https://ngrok.com/ need for proxy
ngrok http -host-header=rewrite 52901 

# It is necessary to create an MS Bot account
1)  https://dev.botframework.com/bots/new