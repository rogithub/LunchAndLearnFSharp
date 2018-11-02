namespace myFsharpProject
module internal Database =

    open Product

    let getById id = async {

        // Encrypted formulas for list bellow

        //let f0 = [| { Name = "Water"; Percent = 80.0}; { Name = "Sugar"; Percent = 10.0}; { Name = "Coffee"; Percent = 10.0 } |]
        //let f1 = [| { Name = "Water"; Percent = 80.0}; { Name = "Vitamins"; Percent = 10.0}; { Name = "Orange"; Percent = 10.0 } |]
        //let f2 = [| { Name = "Plastic"; Percent = 80.0}; { Name = "Hard Disk"; Percent = 10.0 }; { Name = "RAM"; Percent = 10.0} |]
        //let f3 = [| { Name = "Poison"; Percent = 80.0}; { Name = "Water"; Percent = 10.0 }; { Name = "Red color"; Percent = 10.0} |]
        //let f4 = [| { Name = "Lithium"; Percent = 80.0}; { Name = "Water"; Percent = 10.0 }; { Name = "Mercury"; Percent = 10.0} |]
        //let f5 = [| { Name = "Vitamin A"; Percent = 33.3}; { Name = "Vitamin B"; Percent = 33.3 }; { Name = "Vitamin C"; Percent = 33.33} |]
        //let f6 = [| { Name = "Vanilla"; Percent = 100.0}; |]
        //let f7 = [| { Name = "Water"; Percent = 100.0}; |]
        //let f8 = [| { Name = "ColorRed"; Percent = 100.0}; |]
        //let f9 = [| { Name = "Refined Petroleum"; Percent = 100.0}; |]
        //let f10 = [| { Name = "Water"; Percent = 100.0}; |]

        let products = [
            {SharedProduct.Id = 0; Name = "Cup of Coffee"; Formula = "W3siTmFtZUAiOiJXYXRlciIsIlBlcmNlbnRAIjo4MH0seyJOYW1lQCI6IlN1Z2FyIiwiUGVyY2VudEAiOjEwfSx7Ik5hbWVAIjoiQ29mZmVlIiwiUGVyY2VudEAiOjEwfV0=";};
            {SharedProduct.Id = 1; Name = "Orange Juice"; Formula =  "W3siTmFtZUAiOiJXYXRlciIsIlBlcmNlbnRAIjo4MH0seyJOYW1lQCI6IlZpdGFtaW5zIiwiUGVyY2VudEAiOjEwfSx7Ik5hbWVAIjoiT3JhbmdlIiwiUGVyY2VudEAiOjEwfV0=";};
            {SharedProduct.Id = 2; Name = "Laptop"; Formula = "W3siTmFtZUAiOiJQbGFzdGljIiwiUGVyY2VudEAiOjgwfSx7Ik5hbWVAIjoiSGFyZCBEaXNrIiwiUGVyY2VudEAiOjEwfSx7Ik5hbWVAIjoiUkFNIiwiUGVyY2VudEAiOjEwfV0=";};
            {SharedProduct.Id = 3; Name = "Pesticide"; Formula = "W3siTmFtZUAiOiJQb2lzb24iLCJQZXJjZW50QCI6ODB9LHsiTmFtZUAiOiJXYXRlciIsIlBlcmNlbnRAIjoxMH0seyJOYW1lQCI6IlJlZCBjb2xvciIsIlBlcmNlbnRAIjoxMH1d";};
            {SharedProduct.Id = 4; Name = "Battery"; Formula = "W3siTmFtZUAiOiJMaXRoaXVtIiwiUGVyY2VudEAiOjgwfSx7Ik5hbWVAIjoiV2F0ZXIiLCJQZXJjZW50QCI6MTB9LHsiTmFtZUAiOiJNZXJjdXJ5IiwiUGVyY2VudEAiOjEwfV0=";};
            {SharedProduct.Id = 5; Name = "Vitamins"; Formula = "W3siTmFtZUAiOiJWaXRhbWluIEEiLCJQZXJjZW50QCI6MzMuM30seyJOYW1lQCI6IlZpdGFtaW4gQiIsIlBlcmNlbnRAIjozMy4zfSx7Ik5hbWVAIjoiVml0YW1pbiBDIiwiUGVyY2VudEAiOjMzLjMzfV0=";};
            {SharedProduct.Id = 6; Name = "Vanilla"; Formula = "W3siTmFtZUAiOiJWYW5pbGxhIiwiUGVyY2VudEAiOjEwMH1d";};
            {SharedProduct.Id = 7; Name = "Water"; Formula = "W3siTmFtZUAiOiJXYXRlciIsIlBlcmNlbnRAIjoxMDB9XQ==";};
            {SharedProduct.Id = 8; Name = "ColorRed"; Formula = "W3siTmFtZUAiOiJDb2xvclJlZCIsIlBlcmNlbnRAIjoxMDB9XQ==";};
            {SharedProduct.Id = 9; Name = "Gasoline"; Formula = "W3siTmFtZUAiOiJSZWZpbmVkIFBldHJvbGV1bSIsIlBlcmNlbnRAIjoxMDB9XQ==";};
        ]

        let product = List.find (fun (p:SharedProduct) -> p.Id = id) products
        return product
    }