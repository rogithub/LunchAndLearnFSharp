# LunchAndLearnFSharp
F# capabilities demonstration 

``` f#
#r "System.Runtime.Serialization.dll";;
#load "Serialization.fs";;
#load "Product.fs";;
open Product;;
let fi = { Name="Agua"; Percent=10.10 };;
let str = encryptFormulaItem fi;;
let fi1 = decryptFormulaItem str;;
fi = fi1;;
```