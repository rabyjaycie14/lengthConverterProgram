# lengthConverterProgram
Software Architecture and Design Patterns | University of Michigan-Dearborn | Dearborn, MI | 2019 </br>
   { All verbiage in this document (unless otherwise stated) was provided as project specifications in CIS 476 by Professor Xu at University of Michigan- Dearborn }

# Chain of Responsibility Design Pattern 
Chain of responsibility pattern is used to achieve loose coupling in software design where a request from client is passed to a          chain of objects to process them. 

Later, the object in the chain will decide themselves who will be processing the request and whether the request is required to be        sent to the next object in the chain or not.

Where and When Chain of Responsibility pattern is applicable:
   1) When you want to decouple a request’s sender and receiver
   2) Multiple objects, determined at runtime, are candidates to handle a request
   3) When you don’t want to specify handlers explicitly in your code
   4) When you want to issue a request to one of several objects without specifying the receiver explicitly.

This pattern is recommended when multiple objects can handle a request and the handler doesn’t have to be a specific object. 
Also, handler is determined at runtime. Please note that that a request not handled at all by any handler is a valid use case.

(Source: "Chain of Responsibility Design Pattern")

# Goal
This problem demonstrates the use of the chain of responsibility (COR) design patterns on a Length converter program (LCP) with a GUI. The LCP performs conversion from kilometer to one of the following three units: Mile, Yard, and Foot and should have a User Interface.

# Implementation Information - Part 1
The input string specifies the amount to be converted and dropdown menu indicates which unit it will convert to. The CoR pattern will be applied to the processing of the input string to generate a number representing the converted amount. The LCP user interface is seen as a client making a request to convert the input to a given unit. Three handlers are available, one for each unit (MILE, YARD, FOOT).

# Implementation Information - Part 2
The text appearing in the output field of the LCP UI is a string that has to undergo three decorations:
   1) Round output to 2nd decimal (e.g., 218.723 to 218.72)
   2) Write output in exp. notation (e.g., 218.72 to 2.1872e2 )
   3) Add the unit name to the converted amount (e.g., 2.1872e2 to 2.1872e2 Yards).

# Source
  "Chain of Responsibility Design Pattern." GeeksForGeeks.com, www.geeksforgeeks.org/chain-responsibility-design-pattern/. Accessed 20 Mar. 2019. 
