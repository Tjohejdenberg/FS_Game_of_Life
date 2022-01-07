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

[<Test>]
let Test_GetNeighboursOfLoneCell () =
    let cellAlive = (1,1)
    let expected = [
        (0,0);(1,0);(2,0)
        (0,1);      (2,1)
        (0,2);(1,2);(2,2)
    ]
    let actual = GetNeighbours cellAlive
    Assert.That(actual, Is.EqualTo(expected)) 

[<Test>]
let Test_GetNeighboursOfLoneCell2 () =
    let cellAlive = (0,-3)
    let expected = [
        (-1,-4);(0,-4);(1,-4)
        (-1,-3);      (1,-3)
        (-1,-2);(0,-2);(1,-2)
    ]
    let actual = GetNeighbours cellAlive
    Assert.That(actual, Is.EqualTo(expected)) 
   

[<Test>]
let Test_GetNeighboursOfCellOnEdgeOfBoard () =
    let board = CreateBoard 3 3
    let cellAlive = (2,0)
    let expected = [
        (1,0);
        (1,1);(2,1)
    ]
    let actual = GetNeighboursOnBoard board cellAlive 
    Assert.That(actual, Is.EqualTo(expected))   

[<Test>]
let Test_GetNeighboursOfCellOnEdgeOfBoard2 () =
    let board = CreateBoard 3 3
    let cellAlive = (0,0)
    let expected = [
        (1,0);
        (0,1);(1,1)
    ]
    let actual = GetNeighboursOnBoard board cellAlive 
    Assert.That(actual, Is.EqualTo(expected))   

[<Test>]
let Test_GetNeighboursOfCellOnEdgeOfBoard3 () =
    let board = CreateBoard 3 3
    let cellAlive = (2,1)
    let expected = [
        (1,0);(2,0)
        (1,1);
        (1,2);(2,2)
    ]
    let actual = GetNeighboursOnBoard board cellAlive 
    Assert.That(actual, Is.EqualTo(expected))  

[<Test>]
let Test_GetNeighboursOfCellOnEdgeOfBoard4 () =
    let board = CreateBoard 3 3
    let cellAlive = (1,2)
    let expected = [
        (0,1);(1,1);(2,1)
        (0,2);      (2,2)
    ]
    let actual = GetNeighboursOnBoard board cellAlive 
    Assert.That(actual, Is.EqualTo(expected))  

[<Test>]
let Test_GetNeighboursForPointCount () =
    let board = CreateBoard 3 3
    let cellsAlive = [(0,0);(1,0)]
    let expected = [
        (1,0)
        (0,1)
        (1,1)
        (0,0)
        (2,0)
        (0,1)
        (1,1)
        (2,1)
    ]
    let actual = generateStackedOccurencesOfNeighbourCells board cellsAlive 
    Assert.That(actual, Is.EqualTo(expected)) 

[<Test>]
let Test_GetNeighboursForPointCount2 () =
    let board = CreateBoard 3 3
    let cellsAlive = [(0,0);(1,0);(0,2)]
    let expected = [
        (1,0)
        (0,1)
        (1,1)
        (0,0)
        (2,0)
        (0,1)
        (1,1)
        (2,1)
        (0,1)
        (1,1)
        (1,2)
    ]
    let actual = generateStackedOccurencesOfNeighbourCells board cellsAlive 
    Assert.That(actual, Is.EqualTo(expected))