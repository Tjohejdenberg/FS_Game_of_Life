let ListCoordinatesAlongXForGivenY xRange y = 
    let yRange = List.replicate (List.length xRange) y // fill all positions with same number
    List.zip xRange yRange

let CreateCoordinateList x_start x_final y_start y_final =
    // Create coordinate list row by row, then zip together
    [y_start..y_final] |> List.map (fun y -> 
            ListCoordinatesAlongXForGivenY [x_start..x_final] y
    ) |> List.concat

let CreateBoard rows columns =
    CreateCoordinateList 0 (columns-1) 0 (rows-1)

//let IsWithinCoordinateRange testRange refRange = 

let GetNeighours cellAlive = 
    let (x,y) = cellAlive 
    CreateCoordinateList (x-1) (x+1) (y-1) (y+1) 
    |> List.filter (fun x -> x <> cellAlive)