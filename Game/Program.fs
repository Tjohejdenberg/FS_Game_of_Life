
let CreateBoard rows columns =
    // Create coordinate list row by row, then zip together
    [0..(rows-1)] |> List.map (fun y ->
        let x_row = [0..columns-1] 
        let y_row = List.init columns (fun z -> y) // fill all positions with same number
        List.zip x_row y_row
    ) |> List.concat
