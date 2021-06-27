__What is Decorator Design Pattern?__

The definition from [Wikipedia](https://en.wikipedia.org/wiki/Decorator_pattern) - *"The decorator[3] design pattern is one of the twenty-three well-known GoF design patterns; these describe how to solve recurring design problems and design flexible and reusable object-oriented software—that is, objects which are easier to implement, change, test, and reuse."*

This pattern was defined in the book **Design Patterns - Elements Of Reusable Object-Oriented Software** written by **Erich Gamma, Richard Helm, Ralph Johnson and John Vlissides**. This book is also known as **GOF(Gang Of Four) design patterns**. The authors are often referred to as **Gang of Four**.  This pattern is defined in the structural design pattern category in the book.

The primary use-case for this pattern is that it would allow attaching new behaviour to the classes by wrapping them inside a special wrapper. This additional wrapper would allow us to attach new functionality to the existing functionality without actually changing the original class.

__What problem does this solve?__

1. This pattern allows us to add additional functionality to a class dynamically at runtime.
2. This would also helps us achieve separation of concerns.
3. This would also provide a flexible alternative to the inheritance for extending the class in multiple ways.

__How does the implementation of this design pattern look like?__

The way we would go about implementing this pattern is, by adding a new class by implementing the original interface. While doing so, we would extend the functionality by intercepting the request to the class. At this point, we would either add or remove the functionality and forward the request to the original class.

**EXAMPLE**

**Problem**: Imagine that we have a web application that retrieves user data from a Third Party API. When a user visits the index page of our application, we would make an HTTP request to the Third Party API to retrieve a list of users.

As it is an external API, we are constrained to make only 1000 API requests per hour to retrieve user information.

**Solution**:

In the initial version, we have added an interface which would provide us with a contract to retrieve the users. Then we have concrete implementation of this interface where we would have the actual implementation details of fetching the data from the external API.

As the site grows in popularity, we now started to hit the API limit of 1000 API calls per hour. We need to implement some sort of caching mechanism which would cache the data retrieved thereby reducing the number of rounds trips to the API.

After giving it a thought, we came up the with the idea of caching data in the memory. We don't want to change the existing implementation of how you retrieve data but rather would like to attach the in-memory caching functionality dynamically.

This is where we would leverage the **DECORATOR PATTERN**.

For implementing the decorator pattern,

1. we will need to add a wrapper class over the existing class.
2. Add the additional functionality into the wrapper class, then forward the requests to the original class.

With this approach, we can easily substitute the original implementation with another implementation at run-time. So, this wrapper becomes a decorator as the wrapper class implements the same interface as the original class. That’s why from the calling code's perspective these classes are identical. Make the wrapper’s reference field accept any object that follows that interface.

[Example implementation can be found here:](https://github.com/yvrkarthik/DesignPatterns/tree/main/DesignPatterns.Decorator)

__External References for further reading__

[Wikipedia](https://en.wikipedia.org/wiki/Decorator_pattern)
