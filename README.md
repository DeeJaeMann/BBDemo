# BBDemo
 Reproduction of Python OOP Assessment in Unity
 Here are the original assessment requirements:
 
 ## Challenge

_Back in the day_, humans would actually leave their homes to go rent a physical video copy of movies (what a strange concept, right?). Blockbuster was the leading video rental company in this era. Today, there is only one Blockbuster location left which is located in Bend, Oregon. We are going to ask you to build a video inventory application for this Blockbuster!

Your Video Inventory Management application should manage the following data:

- Load cutomer and video inventory data from the csv files provided
- Manage customer information:
  - customer id
  - customer account type (sx/px/sf/pf)
    - "sx" = standard account: max 1 rental out at a time
    - "px" = premium account: max 3 rentals out at a time
    - "sf" = standard family account: max 1 rental out at a time AND can not rent any "R" rated movies
    - "pf" = premium family account: max 3 rentals out at a time AND can not rent any "R" rated movies
  - customer first name
  - customer last name
  - current list of video rentals (_by title_), each title separated by a forward slash "/"
- Manage the store's video inventory:
  - video id
  - video title
  - video rating
  - video release year
  - number of copies currently available in-store

Your application should allow:

- Viewing the current video inventory for the store
- Viewing a customer's current rented videos
  - Get a customer _by id_
  - Display a list of currently rented titles
- Adding a new customer
  - You should not have an initial list of video rentals assigned to a newly created customer
  - No duplicate ID's
- Renting a video out to a customer
  - Get video _by title_
  - Decriment video copies
- Returning a video from a customer
  - Get video _by title_
  - Incriment video copies
- Exiting the application
- **IMPORTANT:** Customers should be limited based on their account type. Your application should enforce these limitations when attempting to rent a video!

Be sure to give careful consideration into what data structures & data types (including classes) you might need to use in your application logic.

Your menu should look like this:

```bash
== Welcome to Code Platoon Video! ==
1. View store video inventory
2. View customer rented videos
3. Add new customer
4. Rent video
5. Return video
6. Exit
```

## Class Breakdown

### Customer

Attributes

| attribute            | type           | example data      | cls or inst |
| ---------------- | -------------- | ----------------- | --- |
| customers   | dict | {1: Customer(1)}  | cls |
| _id               | int            | 1                 | inst |
| first_name           | str            | John          | inst |
| last_name           | str            | Brawn           | inst |
| _account_type    | str           | sx             | inst |
| _current_video_rentals | list           | ['Toy Story'] | inst |

Getters and Setters

| property     | type   | parent | input |
|--------------|--------|-------|----|
| id           | getter | _id | N/A   |
| current_video_rentals| getter | _current_video_rentals| N/A |
| rent_a_video | setter | _current_video_rentals|("Toy Story", "G")|
| return_a_video | setter |_current_video_rentals| "Toy Story" |

Methods

| methods            | return type    | example return  | cls or inst | input |
| ---------------- | -------------- | ----------------- | --- | ---- |
| get_customer_by_id | Customer Class inst | Customer(1) | cls | N/A |
| get_customer_rented_videos   | str | f"{self.first_name} has the following rentals:\n{self.current_video_rentals}" | inst | N/A|
| create_customer  | dict   | {'id':7,'first_name':str, 'last_name':str, 'account_type':str}| cls | N/A |

### Customer_pf

- Inherits all attributes and methods from the `Customer` class
- Overrides `rent_a_video` method to meet account conditions

### Customer_sf

- Inherits all attributes and methods from the `Customer` class
- Overrides `rent_a_video` method to meet account conditions

### Customer_sx

- Inherits all attributes and methods from the `Customer` class
- Overrides `rent_a_video` method to meet account conditions

### Customer_px

- Inherits all attributes and methods from the `Customer` class
- Utilizes inherited `rent_a_video` method that already meets account conditions

### Video

Attributes

| attribute            | type           | example data      | cls or inst |
| ---------------- | -------------- | ----------------- | --- |
| videos   | dict | {"Toy Story":Video Object(1),} | cls |
| _id               | int            | 1                 | inst |
| _title            | str            | Up                | inst |
| _rating           | str            | PG                | inst |
| release_year     | int            | 2014              | inst |
| _copies_available | int            | 1                 | inst |

Getters and Setters

| property     | type   | parent | input |
|--------------|--------|-------|----|
| id           | getter | _id | N/A   |
| title          | getter | _title | N/A   |
| rating           | getter | _rating | N/A   |
| copies_available | getter | _copies_available | N/A   |
| rent_a_video | setter | _copies_available|int|
| return_a_video | setter |_copies_available| int |

Methods

| methods            | type           | example return  | cls or inst | input |
| ---------------- | -------------- | ----------------- | --- | ---- |
| get_a_video_by_title | Video Class inst | Video Object(1) | cls | N/A|
| list_inventory| None | Prints each videos _str | cls | N/A |

## Store

Attributes

| attribute            | type           | example data      | cls or inst |
| ---------------- | -------------- | ----------------- | --- |
| name   | str | Code Platoon | inst |

Methods

| methods            | type           | input | example return  | cls or inst |
| ---------------- | -------------- | ------|----------- | --- |
| customer_type_maker | Customer Class inst | {'id':7,'first_name':str, 'last_name':str, 'account_type':str}| Customer Object(1) | inst |
| load_data| None | file name i.e. inventory or customer | None| inst |
| run_the_store | str | None |Thank you, please come again!| inst |
