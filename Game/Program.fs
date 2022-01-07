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
    
let GetNeighboursOnBoard cellAlive board =
    GetNeighbours cellAlive |> GetCellsWithinCoordinateRange board