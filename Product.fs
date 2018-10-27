module Product


[<CLIMutable>]
type FormulaItem = { Name: string; Percent: float; }

[<CLIMutable>] 
type Product = { Name: string; Formulation: FormulaItem[]; FormulationEncrypted: string; }
