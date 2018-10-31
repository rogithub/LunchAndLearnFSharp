namespace myFsharpProject
module Database =

    open Product
    open Monad

    let getById id =
        let products =
            [ ({ Id = 0; Name = "Cup of Coffee" }, [| ("Water", 80.0); ("Sugar", 10.0); ("Coffee", 10.0) |]);
            ({ Id = 1; Name = "Orange Juice" }, [| ("Water", 80.0); ("Vitamins", 10.0); ("Orange", 10.0) |]);
            ({ Id = 2; Name = "Laptop" }, [| ("Plastic", 80.0); ("Hard Disk", 10.0 ); ("RAM", 10.0) |]);
            ({ Id = 3; Name = "Pesticide" }, [| ("Poison", 80.0); ("Water", 10.0 ); ("Red color", 10.0) |]);
            ({ Id = 4; Name = "Battery" }, [| ("Lithium", 80.0); ("Water", 10.0 ); ("Mercury", 10.0) |]);
            ({ Id = 5; Name = "Vitamins" }, [| ("Vitamin A", 33.3); ("Vitamin B", 33.3 ); ("Vitamin C", 33.33) |]);
            ({ Id = 6; Name = "Vanilla" }, [| ("Vanilla", 100.0); |]);
            ({ Id = 7; Name = "Water" }, [| ("Water", 100.0); |]);
            ({ Id = 8; Name = "ColorRed" }, [| ("ColorRed", 100.0); |]);
            ({ Id = 9; Name = "Gasoline" }, [| ("Refined Petroleum", 100.0); |]);
            ({ Id = 10; Name = "Water" }, [| ("Water", 100.0); |]) ]

        let product =  List.find (fun (p,f) -> p.Id = id) products
        bind product
