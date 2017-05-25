webManAPI is an SDK used to interact with a PlayStation 3 over the network. It requires a jailbroken PlayStation 3 with webMAN MOD.
It's developed on the .net framework 4.5.2 and supports the Asynchronous Task API.

Features
========
* You can list your games
* Mount, unmount and then launch games/apps.
* You can Shutdown and Restart your console.
* Start up your console remotely using Wake-on-LAN.
* Remote Controller Pad

How it works
============
Connects to a PlayStation 3 via the network and interacts with webMAN MODs Web Server to perform functions. Because there is no API specifically for remote control some pages need to be scraped and parsed to get the required data.

How to use this Library
=======================
There is an example project called "webManAPI Library Test" in the solution that tests the libraries functionality using Asynchronous Tasks.

Future Developments
===================
There are still some items that could be implemented into this library:
* File Browser.
* Message Notification
* Beep
* Light

Am happy to accept pull requests for any bug fixes or feature requests.
