namespace FConsole
module Monads = 
    open System
    open System.Diagnostics
    open System.Threading

    type M<'T> =
        M of ('T -> 'T * 'T[])

    let makeFormulation fomulaItems =
        let makeKitProduct nameAndPercent =
            let tupletted = (nameAndPercent, fomulaItems)
            tupletted
        M makeKitProduct
    
    let runM (M f) nameAndPercent = f nameAndPercent

    let mapM f formulationM =
        let transform nameAndPercent = 
            let (name,percent), formulaItems = runM formulationM nameAndPercent
            let newformulaItems  = f formulaItems
            let tupletted = ((name,percent), newformulaItems)
            tupletted
        M transform

    let map2M f m1 m2 =
        let transform nameAndPercent = 
            let (name1,percent1), items1 = runM m1 nameAndPercent
            let (name2,percent2), items2 = runM m2 nameAndPercent
            let newformulaItems  = f items1 items2
            let tupletted = (nameAndPercent, newformulaItems)
            tupletted
        M transform
    
    let returnM formulaItems = 
        let convertIntoM nameAndPercent = 
            let tupletted = nameAndPercent, formulaItems
            tupletted
        M convertIntoM

    let bindM f formulationM = 
        let binder nameAndPercent = 
            let nameAndPercent1, items1 = runM formulationM nameAndPercent
            let newformulationM = f items1 
            let (name2,percent2), items2 = runM newformulationM nameAndPercent1
            let tupletted = (name2,percent2), items2
            tupletted
        M binder

    let increase10Percent formulaItems = 
        let f = formulaItems |> Array.map (fun (n, p) -> (n, p * 1.10))
        f
    
    let combineFormulas formula1 formula2 = 
        let f = Array.concat [formula1; formula2]
        f
    
    let makeAll100Percent items1 =
        let makeOneHundredPercent nameAndPercent =
            let (name, percent) = nameAndPercent
            let items2 = items1 |> Array.map (fun (n, p) -> (n, 100.0))
            let tupletted = (name, 100.0), items2
            tupletted
        M makeOneHundredPercent

    let printResult result =
         printfn "%A %s" result Environment.NewLine

    let test () =
        let water = ("Water", 80.0)
        let coffeGrains = ("Coffee grains", 10.0)
        let sugar = ("Sugar", 10.0)
        let coffeeMakerM = makeFormulation [|water; coffeGrains; sugar|]

        let cupOfCoffe = runM coffeeMakerM ("Cup of Coffe", 80.0)
        printResult cupOfCoffe
        
        let coffeeMaker10DecialM = mapM increase10Percent coffeeMakerM
        let cupOfCoffeIncreased = runM coffeeMaker10DecialM ("Cup of Coffe +10%", 81.0)
        printResult cupOfCoffeIncreased

        let gasolineMakerM = makeFormulation [|("Oil", 9.9); ("petroleum", 5.5);|]
        let combinatorMakerM = map2M combineFormulas gasolineMakerM coffeeMakerM
        let gasoCofee = runM combinatorMakerM ("gasoline coffee", 100.0)
        printResult gasoCofee

        let orangeJuiceMakerM = returnM [| ("Oranges", 100.0); water |]
        let orangeJuice = runM orangeJuiceMakerM ("Orange Juice", 20.3)
        printResult orangeJuice

        let coffee100percentMakerM = bindM makeAll100Percent coffeeMakerM
        let oneHundredCoffee = runM coffee100percentMakerM ("Coffee 100%", 33.33)
        printResult oneHundredCoffee