namespace FConsole
module Monads = 
    open System
    open System.Diagnostics
    open System.Threading

    type FormulaType<'a> = FormulaItem of 'a * 'a[]
    type M<'T> =
        M of ((string * float) -> 'T)

    let makeFormulation fomulaItems =
        let makeKitProduct nameAndPercent =
            let tupletted = (nameAndPercent, fomulaItems)
            FormulaItem tupletted
        M makeKitProduct
    
    let runM (M f) nameAndPercent = f nameAndPercent

    let test () =
        let water = ("Water", 80.0)
        let coffeGrains = ("Coffee grains", 10.0)
        let sugar = ("Sugar", 10.0)
        let makeCupOfCofee = makeFormulation [|water; coffeGrains; sugar|]
        
        let cupOfCoffe = runM makeCupOfCofee ("Cup of Coffe", 80.0)
        printfn "%A" cupOfCoffe
        