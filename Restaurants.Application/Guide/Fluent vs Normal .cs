



namespace Restaurants.Application.Guide
{

    //Fluent vs Data Annotations
    //Data Annotations
    //What It Is: A built-in feature of.NET where you decorate model properties with attributes to define validation rules.
    //It’s part of System.ComponentModel.DataAnnotations.
    //How It Works: Validation rules are applied directly to the model class, and ASP.NET automatically enforces them (e.g., in MVC model binding).

    //Pros:
    //Simple and quick to implement.
    //Integrated with ASP.NET MVC and Entity Framework out of the box.
    //Good for basic validation(e.g., required fields, ranges).

    //Cons:
    //Limited flexibility—validation is tied to the model class.
    //Hard to reuse across different contexts(e.g., different rules for create vs. update).
    //Mixes validation logic with domain models, violating separation of concerns in Clean Architecture.


    //////////////////////////////////////////////////////////////////////
    //Fluent 
    //What It Is: A third-party library (FluentValidation) that provides a fluent,
    //programmatic way to define validation rules separate from the model.
    //How It Works: You create a validator class for each model,
    //defining rules using a chainable API.It’s typically injected into your pipeline (e.g., ASP.NET Core middleware or services).

    //      Pros:
    //    Highly flexible—supports complex, conditional, and reusable validation logic.
    //    Separates validation from the model, aligning with Clean Architecture principles.
    //    Easy to test independently.
    //    Cons:
    //Requires an extra library and more setup.
    //    Slightly more verbose than Data Annotations for simple cases.
}
