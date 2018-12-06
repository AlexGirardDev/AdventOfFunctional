// Learn more about F# at http://fsharp.org

open System
open System.IO


module day1=
    let day1_1() =
        File.ReadAllLines("Day1.txt") 
        |> Array.toList
        |> List.map(fun x-> x |> int)
        |> List.sum
        |> printfn "Day 1 Part 1 : %A" 

    let day1_2() =
        let rec looping xd =
            let (index:int,  frequencies:int[], input:int[], frequency:int) = xd
            let newfreq = frequency+input.[index]
            if(Array.contains newfreq frequencies)
                then newfreq
            else 
                let index = if index>=input.Length-1 then 0 else index+1
                looping (index, Array.append frequencies [|newfreq|], input, newfreq)

        looping(0,[|0|],File.ReadAllLines("Day1.txt")|> Array.map(fun x-> x |> int),0) 
        |>printfn "Day 1 Part 2  %i"

module day2=
    let day2_1() =
        File.ReadAllLines("Day1.txt")
        |> Array.forall(fun x->x 
        //|> Seq.groupBy(fun c->c)
        //|> Seq.where (fun y->(Array.length y)==2))
        //|> printfn "Day 1 Part 2  %i"
        0




open day1
open day2

[<EntryPoint>]
let main argv =
    day1_1()
    day1_2()

    System.Console.ReadKey() |> ignore
    0