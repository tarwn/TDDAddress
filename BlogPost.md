As I've moved from project to project, environment to environment, I've had opportunities to write unit tests after coding, do test first development, and once even used unit tests as a living spec for an external developer (code none unit testing?). One of the biggest friction points, once you settle on a framework, is the constant cycle back and forth between building, running tests, and flipping back. Whether you are using MS Test and the built-in test result viewer, the external NUnit GUI, or a 3rd party test runner, that constant switching is actually stealing precious moments of concentration and time. 

Imagine for a moment that you have finished writing a piece of code. Maybe it's the test, maybe it's the code you intend to test. Instead of kicking off a build and switching mental mode to run the tests, the results simply start showing up as you are typing up the code. Your test turns red and then green as you fill in the logic, never once breaking stride to wait for the test suite to run. your uncovered code is marked as uncovered before you even build the file. It's magic.

And so very, very addictive.

Hey Kids, Try Some of This
-----------------------------

Instead of screenshotting our way through another post, let's do this together. First download and install [NCrunch](http://www.ncrunch.net/). Then either download or clone the git repository sample I have set up here: 

Let's get started.

What are we doing?
-----------------------------

The goal of this exercise is to build an Address class that is the business and formatting logic behind entry of a mailing address. The Address class will expose properties to tell an interface what address fields are available, what they should be labelled, whether the address has all the required values, and a displayable formatted address. In return, it will expect that interface to populate input properties for all the address input values. 

This is both as easy and quite a bit harder than what it sounds like. Easier in that we won't be writing a game or similarly large construct, but harder because the rules for mailing addresss are not as well defined or as simple as you may think. In fact, most websites on the internet do it wrong, not just for addresses outside of the US, but sometimes for addresses inside the US also. 

Luckily there are some people that have tried to pull together all of the rules from the USPS and other sources and we can use the results of their hard work to serve as a spec for our Address logic. The rules we are using were sourced from http://www.columbia.edu/~fdc/postal/#general, but I've only included a subset of them in this project.

Project Setup
-----------------------------

There are two projects in the solution, one to hold the Address class (Main) and one for the tests (Main.Tests). The Address class already has the basic properties it needs, but everything else is up to you.

Let's Go
------------------------------

Open the solution and enabled NCrunch (you have installed it, right?) by selecting it from the top menu and selecting "Enable". For the most part you can select the defaults, though you will want to select the option to enable all of your tests by default or open the Tests window, select ignored tests (grey icon on far right) and enable tests for the two projects manually.

Ready? Ok, moving on.

Open up the AddressTests file in Main.Tests and the Specs.md file from the root of the solution. Add the first test to the AddressTests like so:

	[Test]
	public void ToFormattedAddress_AddressLine1IsProvided_ItAppearsInOutput() {
		var sampleValue = "Address Line 1";
		var a = new Address();

		a.AddressLine1 = sampleValue;
		var result = a.ToFormattedAddress();

		Assert.IsTrue(result.Contains(sampleValue));
	}

This test lines up with the first rule in the rules file and after you add it you should see some red dots sowing up next to lines in the test. NCrunch is building and running the tests behind the scenes as you add more code, automagically. if we switch over to the Address class, we'll notice that it also has dots to indicate portions of the class that are referenced by failing tests. By right-clicking on any of these dots we have options to run tests in debug mode, .... and so on.

Now add some code to satisfy that test. As you make addition, NCrunch continues to build and test in the background, displaying the updated status as you work. When you get to all green dots, you're done. No need to stop, just move right on to the next test.

Enjoy the flow.