Discounts
==========================

As a MarsAir customer
I want to be able to apply a discount
So that I can purchase cheap tickets to Mars

Apply valid discount
-------------------

* A user searches for an available flight
* The user enters a discount for a promotional code and is advised the discount is valid
|discountnumber|discountpercent|
|1|10|
|2|20|
|3|30|
|4|40|
|5|50|
|6|60|
|7|70|
|8|80|
|9|90|


Apply invalid discount
----------------------
* A user searches for an available flight
* The user enters an invalid discount for a promotional code and is advised the discount is invalid
|discountcode|
|x|
|£|
|五|
||

