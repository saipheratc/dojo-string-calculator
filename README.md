# Kata:StringCalculator
Kata utilizado no Dojo do dia 20/10/2017



1. Create a simple String calculator with a method int Add(string numbers) 
   - The method can take 0,1 or 2 numbers, and will return their sum (for an empty string it will return 0) for example "" or "1" or "1,2"
   - Start with the simplest test case of an empty string and move to one and two numbers
   - Remember to solve things as simply as possible
   - Remember to refactor after each passing test
2. Allow the Add method to handle as unknown amount of numbers
3. Allow the Add method to handle newlines between numbers instead of commas.
   - The following input is valid: "1\n2,3" (will equal 6)
   - The following input is not valid: "1\n" (no need to handle this in your code)

4. Support differente delimiters
   - To change a delimiter, the beginning of the string will contain a separate line that looks like this:   “//[delimiter]\n[numbers…]” for example “//;\n1;2” should return three since the delimiter is ‘;’.
   -  The first line is optional, so all existing scenarios should still be supported, (existing tests should still pass). 
5. Calling Add with a negative number should throw an exception “negatives not allowed”. The exception message should include the negative that was passed. If there are multiple negatives, list all of them in the message.
