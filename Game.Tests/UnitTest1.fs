module Game.Tests

open NUnit.Framework
open Program

[<SetUp>]
let Setup () =
    ()

[<Test>]
let Test_CreateQuadraticBoard () =
    let expected = [
        (0,0);(1,0);(2,0)
        (0,1);(1,1);(2,1)
        (0,2);(1,2);(2,2)
    ]
    let actual = CreateBoard 3 3
    Assert.That(actual, Is.EqualTo(expected))

[<Test>]
let Test_CreateRectangularBoard () =
    let expected = [
        (0,0);(1,0);(2,0);(3,0)
        (0,1);(1,1);(2,1);(3,1)
        (0,2);(1,2);(2,2);(3,2)
    ]
    let actual = CreateBoard 3 4
    Assert.That(actual, Is.EqualTo(expected))
(*
[<Test>]
let Test_GetNeighboursOfLoneCell () =
    let CellAlive = [(1,1)]
    let expected = [
        (0,0);(1,0);(2,0)
        (0,1);      (2,1)
        (0,2);(1,2);(2,2)
    ]
    let actual = GetNeighours CellAlive
    Assert.That(actual, Is.EqualTo(expected)) 
*)
   