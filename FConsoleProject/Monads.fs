namespace FConsole
module Monads = 
    open System
    open System.Diagnostics
    open System.Threading

    type Component = string * float


    //type Formulation =
    //    | Component of string * float
    //    | Components of string * float * Component[]
  
    type FormulaType<'a> = FormulaItem of 'a * 'a[]

    let (+) c1 c2 = 
        let (name1, percent1) = c1
        let (name2, percent2) = c2
        (name1 + " " + name2, 90)
       
    type FormulaBuilder() =
    
        member this.Bind(m, f) = 
            printfn "expression is %A" m
            let result = f m
            result

        member this.Return(item) = 
            FormulaItem (item, [|item|])
        
        member this.ReturnFrom(m) = 
            m
    

    let test () = 
        let builder = new FormulaBuilder()
        let formulation = builder {
            let! water = ("Water", 10)
            let! coffeGrains = ("Coffe Grains", 10)
            let! coffe = water + coffeGrains
            return coffe
        }
        printfn "%A" formulation 