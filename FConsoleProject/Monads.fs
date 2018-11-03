namespace FConsole
module Monads = 
    open System
    open System.Diagnostics
    open System.Threading

    type FormulaType<'a> = FormulaItem of 'a * 'a[]

    let mix c1 c = 
        let tupletted = (c1, c)
        tupletted
       
    type FormulaBuilder() =
    
        member this.Bind(m, f) = 
            printfn "expression is %A" m
            let result = f m
            result

        member this.Return(item) = 
            FormulaItem item
        
        member this.ReturnFrom(m) = 
            m  

    let test () = 
        let builder = new FormulaBuilder()
        let formulation = builder {
            let water = ("Water", 80)
            let coffeGrains = ("Coffe Grains", 10)
            let sugar = ("Sugar", 10)
            let cupOfCoffe = mix ("CupOfCoffe", 80) [|water; coffeGrains; sugar|]
            return cupOfCoffe
        }
        printfn "%A" formulation 