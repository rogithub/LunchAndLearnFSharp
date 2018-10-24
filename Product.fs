module Product
open Serialization

[<CLIMutable>]
type FormulaItem = { Name: string; Percent: float; }

[<CLIMutable>] 
type Product = { Name: string; Formulation: List<FormulaItem>; FormulationEncrypted: string; }


let decryptFormulaItem = deserialiseJson<FormulaItem>
let encryptFormulaItem (fi:FormulaItem) = serializeJson fi

