module Product
open Serialization
open Encryption

[<CLIMutable>]
type FormulaItem = { Name: string; Percent: float; }

[<CLIMutable>] 
type Product = { Name: string; Formulation: FormulaItem[]; FormulationEncrypted: string; }


let toString (p: Product) =         
    let serializeProd (prod:Product) = serializeXml prod
    //let serlializeFormula (f:List<FormulaItem>) = serializeJson f |> encrypt
    let serializeFormula (f:FormulaItem[]) = serializeJson f |> encrypt

    let newProd = { p with Formulation=[||]; FormulationEncrypted = serializeFormula p.Formulation }
    let xml = serializeProd newProd
    xml