
namespace Restaurants.Infrastructure.Seeders
{

//Differences Between the Two Approaches
//1. Abstraction vs.Concrete Implementation
//Class Only: TravelBookingSeeder is a concrete class. You directly instantiate or resolve it, tying your code to that specific implementation.
//Interface: ITravelBookingSeeder is an abstraction.
//You depend on the interface, not the specific class.
//This allows you to swap out implementations(e.g., replace TravelBookingSeeder with AnotherSeeder) without changing the consuming code(Program.cs).


//2. Coupling
//Class Only: Tightly coupled.If you need a different seeder (e.g., for testing or a different dataset), you must modify Program.cs to use a new class.
//Interface: Loosely coupled.You can create a new class (e.g., TestSeeder) that implements ITravelBookingSeeder and change the registration in AddScoped without touching the rest of the code.

//3. Flexibility
//Class Only: Less flexible. It assumes one way of seeding forever.
//Interface: More flexible. You can have multiple implementations:
//TravelBookingSeeder: Full production data.
//TestSeeder: Minimal data for unit tests.
//EmptySeeder: No-op for specific environments.

//4. Testability
//Class Only: Harder to mock or replace for testing because you’re tied to the concrete class.
//Interface: Easier to mock in unit tests.You can create a fake ITravelBookingSeeder implementation that doesn’t touch the database.


//5. Code Changes
//Class Only: No additional files or complexity—just one class.
//Interface: Adds an interface file and requires the class to implement it, slightly increasing complexity but improving maintainability.
}
