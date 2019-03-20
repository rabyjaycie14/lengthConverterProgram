# lengthConverterProgram
Software Architecture and Design Patterns | University of Michigan-Dearborn | Dearborn, MI | 2019

# Chain of Responsibility Design Pattern 
(Source: "Chain of Responsibility Design Pattern")

"Chain of responsibility pattern is used to achieve loose coupling in software design where a request from client is passed to a          chain of objects to process them. 

Later, the object in the chain will decide themselves who will be processing the request and whether the request is required to be        sent to the next object in the chain or not.

Where and When Chain of Responsibility pattern is applicable:
   1) When you want to decouple a request’s sender and receiver
   2) Multiple objects, determined at runtime, are candidates to handle a request
   3) When you don’t want to specify handlers explicitly in your code
   4) When you want to issue a request to one of several objects without specifying the receiver explicitly.

This pattern is recommended when multiple objects can handle a request and the handler doesn’t have to be a specific object. Also,         handler is determined at runtime. Please note that that a request not handled at all by any handler is a valid use case."

# Goal
"This problem demonstrates the use of the chain of responsibility (COR) design patterns on a Length converter program (LCP) with a GUI. The LCP performs conversion from kilometer to one of the following three units: Mile, Yard, and Foot and should have a User Interface."

# Implementation Information
"The input string specifies the amount to be converted and dropdown menu indicates which unit it will convert to. The CoR pattern will be applied to the processing of the input string to generate a number representing the converted amount. The LCP user interface is seen as a client making a request to convert the input to a given unit. Three handlers are available, one for each unit (MILE, YARD, FOOT)."

# Source
  "Chain of Responsibility Design Pattern." GeeksForGeeks.com, www.geeksforgeeks.org/chain-responsibility-design-pattern/. Accessed 20 Mar. 2019. 
