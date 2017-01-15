# TechnicalTestLotteryAPI

Technical test for SiS - Copyright (c) 2017 - Adrian Heathcote. All Rights Reserved.

The test only comprises the API, I do not have any real experience of Angular and none of React so it seemed sensible to concentrate on the areas I'm more comforable with.

I have included a few integration tests and some unit tests. This is no way near the coverage that should be achieved in a normal project. It does not fully test the system and therefore bugs may exist in the code, but it's enough to show the level I'm at within unit testing and integration testing.

There is a simple debug tracer included which will occasionally write some logs to the output window. Again this is only to show how I'd go about writing a tracer. The tracer component can easily be switched at a later date or additional tracers can be included which may or may not be controlled a configuration option.

I am very used to using Autofac and IoC and as such the API has been coded accordingly.

An assumption was made whilst reading the spec that Total amount of primary numbers should have equated to 5 in the example. This has been carried forward and implemented within the system, so my apologies if this has been misinterpreted.

In order to test the API - Simply run the studio project:

Create entry [Post]: http://localhost:52510/Api/LotteryDraw

Payload:

{
  "Name": "49s",
  "Description": "49s Lottery",
  "DateOfDraw": "2016-11-23T16:32:48.7297009+00:00",
  "TotalPrimaryNumbers": 5,
  "RangePrimary": {
    "Minimum": 1,
    "Maximum": 49
  },
  "TotalSecondaryNumbers": 2,
  "RangeSecondary": {
    "Minimum": 1,
    "Maximum": 10
  }
}

Get entry(ies) [Get]: http://localhost:52510/Api/LotteryDraw?dateTime=2016-11-23

Currently the call expects one date, you cannot enter a "from to" clause, but this funtionallity could easily be added at a later date.

Update existing entry [Put]: http://localhost:52510/Api/LotteryDraw?name=49s

Payload:

{
      "WinningPrimaryNumbers": [1,2,3,4,5,6],
      "WinningSecondaryNumbers": [1,2]
}

It is also possible to delete entries as well: [Delete] http://localhost:52510/Api/LotteryDraw?name=49s

All responses (unless 500 internal server error) will be a simple data object comprising:

IsSuccessful
HasError
ErrorMessage

e.g.
{
  "IsSuccessful": false,
  "HasError": true,
  "ErrorMessage": "Primary winning numbers mismatch. Expected 5 but was given 6"
}

with the exception of the Get which return a more complex object which is the LotteryDrawWithResults object:

e.g.

{
  "IsSuccessful": true,
  "HasError": false,
  "ErrorMessage": null,
  "LotteryDraws": [
    {
      "Name": "49s",
      "Description": "49s Lottery",
      "DateOfDraw": "2017-01-14T16:32:48.7297009+00:00",
      "TotalPrimaryNumbers": 5,
      "RangePrimary": {
        "Minimum": 1,
        "Maximum": 49
      },
      "TotalSecondaryNumbers": 2,
      "RangeSecondary": {
        "Minimum": 1,
        "Maximum": 10
      },
      "WinningPrimaryNumbers": [
        1,
        2,
        3,
        4,
        5
      ],
      "WinningSecondaryNumbers": [
        1,
        2
      ]
    }
  ]
}
