# Day 4 - Seven Pain Display: A Parsing Nightmare - Part B

MIYAGI+ is more advanced than we initially thought. Scientists aren’t quite sure what MIYAGI+’s potential really is, though.

Your team has been tasked with assisting MIYAGI+ researchers with a simple task.

MIYAGI+ is known to be a fast calculator of simple math equations, but just how accurate is MIYAGI+? The researchers have decided to test MIYAGI+’s accuracy by giving it math equations to solve. Of course, MIYAGI+‘s input is a 2D matrix of `.` `!` and `#` which isn’t very human readable. Therefore, the kind researchers have prepared a special handwritten version of the input just for you. Since MIYAGI+‘s Load Memory Alignment Overload (LMAO) is still a work in progress, the researchers request that you modulo each equation’s result by `10^7` so they can compare your results to MIYAGI+’s.

## Input

The first line of input `n` contains the number of math equations to follow.

Each of the next `n` lines contains a simple math equation consiting of integers, floating point numbers, and operators. The operators consist of `+`, `-`, and `*`.

## Output

The final sum of the results of each equation rounded to two decimal places.

Modulo each equation’s result by `10^7`

Note: using the modulo operator on a negative number produces a positive number. Account for this.