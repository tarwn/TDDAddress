Using NCrunch for TDD
=============================

As I've moved from project to project, environment to enviromment, I've had the opportunity to do test first development, post development unit testing, and once even used unit tests as a living specific for an external developer. One of the biggest friction points, once you settle on a framework, is the constant cycle back and forth between building, running tests, and flipping back. Whether you are using MS Test and the built-in test result viewer, the external NUnit GUI, or a 3rd party test runner, that constant switching is actually stealing precious moments of concentration and time. 

Imagine for a moment that you have finished writing a piece of code. Maybe it's the test, maybe it's the code you intend to test. Instead of kicking off a buid and switching mental mode to run the tests, the results simply start showing up as you are typing up the code. Your test turns red and then green as you fill in the liogic, never once breaking stride to wait for the test suite to run. your uncovered code is marked as uncovered before you even build the file. It's magic.

And so very, very addictive.

Hey Kids, Try This
-----------------------------

Instead of screenshotting our way through another post, let's do this together. First download and install [NCrunch](http://www.ncrunch.net/). Then either download or clone the git repository sample I have set up here: 

Let's get started.

What are we doing?
-----------------------------

The goal of this exercise is going tobe to build out a basic Address class for entry of a mailing address that assumes the US as a starting point. The Address class will expose properties to tell an interface what address fields are available, what they should be labelled, whether the address has all the required values, and a displayable formatted address. In return, it will expect that interface to populate input properties for all the address input values. 

This is both as easy and quite a bit harder than what it sounds like, as it will not be a great deal of logic but will also be a whoel lot more than you are probably expecting. Mailing address rules are not as well defined or as simple as you may think, but uckily there are some resuorces out there that have compiled a good amount of this information and a subset of that information will supply us with more than enough fodder for tests.

The rules were sourced from http://www.columbia.edu/~fdc/postal/#general, but I am only using a subset for this project.

Project Setup
-----------------------------

There are two projects in the solution, one to hold the Address class (Main) and one for the tests (Main.Tests). The Address class already has the basic properties it needs, but everythign else is up to you.

Let's Go
------------------------------

Open the solution and enabled NCrunch (you have installed it, right?) by selecting it from the top menu and selecting "Enable". For the most part you can select the defaults, though you will want to select the option to enable all of your tests by default or open the Tests window, select ignored tests (grey icon on far right) and enable tests for the two projects manually.

Ready? Ok, moving on.

Open up the AddressTests file in Main.Tests and the Specs.md file from the root of the solution. Add the first test to the AddressTests like so:



This test lines up with the first rule in the rules file and after you add it you should see some red dots sowing up next to lines in the test. NCrunch is building and running the tests behind the scenes as you add more code, automagically. if we swich over to the Address class, we'll notice that it also has dots to indicate portions of the class that are referenced by failing tests. By right-clicking on any of these dots we have options to run tests in debuig mode, .... and so on.

Now add some code to satsify that test. As you make addition, NCrunch continues to build and test in the background, displaying the updated status as you work. When you get to all green dots, you're done. No need to stop, just move right on to the next test.

Enjoy the flow.