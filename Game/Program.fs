let ListCoordinatesAlongXForGivenY xRange y = 
    //let yRange = List.replicate (List.length xRange) y // fill all positions with same number
    List.replicate (List.length xRange) y |> (List.zip xRange)

let CreateCoordinateList x_start x_final y_start y_final =
    // Create coordinate list row by row, then zip together
    [y_start..y_final] |> List.map (fun y -> 
            ListCoordinatesAlongXForGivenY [x_start..x_final] y
    ) |> List.concat

let CreateBoard rows columns =
    CreateCoordinateList 0 (columns-1) 0 (rows-1)

let GetCellsWithinCoordinateRange refList testList = 
    Set.intersect (Set.ofList testList) (Set.ofList refList) 
    |> Set.toList |> List.sortBy (fun (_,y) -> y)

let GetNeighbours cellAlive = 
    let (x,y) = cellAlive 
    CreateCoordinateList (x-1) (x+1) (y-1) (y+1) 
    |> List.filter (fun x -> x <> cellAlive)
    
let GetNeighboursOnBoard board cellAlive =
    GetNeighbours cellAlive |> GetCellsWithinCoordinateRange board

let generateStackedOccurencesOfNeighbourCells board livingCells = 
    livingCells |> List.map (GetNeighboursOnBoard board) |> List.concat

let zipCellsAndNumNeighbours stackedCells = 
    stackedCells |> List.countBy id

let listCellsToBeBornFromNeighbourList cellListWithNeighbourCount =
    let cells, _ = cellListWithNeighbourCount |> List.filter (fun ((_,_),count) -> count = 3) |> List.unzip
    cells

let listCellsToKeepAliveFromNeighbourList cellsAlive cellListWithNeighbourCount  =
    let shouldStayAlive, _ = cellListWithNeighbourCount |> List.filter (fun ((_,_),count) -> count = 2) |> List.unzip
    GetCellsWithinCoordinateRange shouldStayAlive cellsAlive

let listCellsToKeepAlive board cellsAlive =
    generateStackedOccurencesOfNeighbourCells board cellsAlive
    |> zipCellsAndNumNeighbours
    |> listCellsToKeepAliveFromNeighbourList cellsAlive

let listCellsToBeBorn board cellsAlive =
    generateStackedOccurencesOfNeighbourCells board cellsAlive 
    |> zipCellsAndNumNeighbours
    |> listCellsToBeBornFromNeighbourList

let refreshCells board cellsAlive =
    let beBorn = listCellsToBeBorn board cellsAlive 
    let keepAlive = listCellsToKeepAlive board cellsAlive 
    beBorn @ keepAlive 

(*
Testscript
let board = CreateBoard 3 3;;
let cellsAlive = [(0,1);(1,1);(2,1)];;
let allNeighbours = generateStackedOccurencesOfNeighbourCells board cellsAlive;;
let cellsAndCount = zipCellsAndNumNeighbours allNeighbours
let cellsToBeBorn = listCellsToBeBorn cellsAndCount 
*)