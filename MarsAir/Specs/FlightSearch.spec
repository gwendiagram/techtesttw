﻿Flight Search
==========================

As a MarsAir customer
I want to search flights
So that I can see if there are seats available for my trip to Mars

Find available flight
-------------------

* Navigate to MarsAir homepage "http://gdiagram.marsair.tw/"
* Select "July" from the "departing" field
* Select "December (two years from now)" from the "returning" field
 Press search
 Assert user is informed, "Call now on 0800 MARSAIR to book!"

Find unavailable flight
-----------------------

 Navigate to MarsAir homepage "http://gdiagram.marsair.tw/"
 Select "December" from the departing field
 Select "December (next year) from the returning field"
 Press search
 Assert user is informed, "Sorry, there are no more seats available."
