namespace myFsharpProject
module internal Database =

    open Product

    let getById id =

        let f0 = encryptFormula [| { Name = "Water"; Percent = 80.0}; { Name = "Sugar"; Percent = 10.0}; { Name = "Coffee"; Percent = 10.0 } |]
        let f1 = encryptFormula [| { Name = "Water"; Percent = 80.0}; { Name = "Vitamins"; Percent = 10.0}; { Name = "Orange"; Percent = 10.0 } |]
        let f2 = encryptFormula [| { Name = "Plastic"; Percent = 80.0}; { Name = "Hard Disk"; Percent = 10.0 }; { Name = "RAM"; Percent = 10.0} |]
        let f3 = encryptFormula [| { Name = "Poison"; Percent = 80.0}; { Name = "Water"; Percent = 10.0 }; { Name = "Red color"; Percent = 10.0} |]
        let f4 = encryptFormula [| { Name = "Lithium"; Percent = 80.0}; { Name = "Water"; Percent = 10.0 }; { Name = "Mercury"; Percent = 10.0} |]
        let f5 = encryptFormula [| { Name = "Vitamin A"; Percent = 33.3}; { Name = "Vitamin B"; Percent = 33.3 }; { Name = "Vitamin C"; Percent = 33.33} |]
        let f6 = encryptFormula [| { Name = "Vanilla"; Percent = 100.0}; |]
        let f7 = encryptFormula [| { Name = "Water"; Percent = 100.0}; |]
        let f8 = encryptFormula [| { Name = "ColorRed"; Percent = 100.0}; |]
        let f9 = encryptFormula [| { Name = "Refined Petroleum"; Percent = 100.0}; |]
        let f10 = encryptFormula [| { Name = "Water"; Percent = 100.0}; |]

        let products = [
            { SharedProduct.Id = 0; Name = "Cup of Coffee"; Formula = f0 };
            { SharedProduct.Id = 1; Name = "Orange Juice"; Formula = f1 };
            { SharedProduct.Id = 2; Name = "Laptop" ; Formula = f2 };
            { SharedProduct.Id = 3; Name = "Pesticide"; Formula = f3 };
            { SharedProduct.Id = 4; Name = "Battery"; Formula = f4 };
            { SharedProduct.Id = 5; Name = "Vitamins"; Formula = f5 };
            { SharedProduct.Id = 6; Name = "Vanilla"; Formula = f6 };
            { SharedProduct.Id = 7; Name = "Water"; Formula = f7 };
            { SharedProduct.Id = 8; Name = "ColorRed"; Formula = f8 };
            { SharedProduct.Id = 9; Name = "Gasoline"; Formula = f9 };
            { SharedProduct.Id = 10; Name = "Water"; Formula = f10 };
        ]

        let product = List.find (fun (p:SharedProduct) -> p.Id = id) products
        product