// Learn more about F# at http://fsharp.net
// See the 'F# Tutorial' project for more help.

module Person =
    type X = Foo | Bar

    let prt x =
        match x with
        | Foo -> printfn "%d" 1
        | Bar -> printfn "%d" 2

[<EntryPoint>]
let main argv =
    let rec sum acc list =
        match list with
        | x::x'::y::y'::xs -> sum (acc + x + x') xs
        | x::x'::xs -> acc + x + x'
        | [x] -> acc + x
        | [] -> acc

    let rec skip n xs =
        match (n, xs) with
        | 0, _ -> xs
        | _, [] -> []
        | n, _::xs -> skip (n-1) xs

//    let skills = [2; 3; 10; 5; 8; 9; 7; 3; 5; 2]
//    let skills = [1; 1; 1; 1; 1; 1; 1; 1; 1; 9]
    let skills = [8; 87; 100; 28; 67; 68; 41; 67; 1]
    let sorted = List.rev <| List.sort skills

    let a = sorted.Head + (sum 0 <| skip 3 sorted)
    let b = sum 0 <| skip 1 sorted


    printfn "%A" argv
    0 // return an integer exit code
