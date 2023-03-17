import sys

def f(x, iters):
    if x % 2 != 0:
        return x
    iters[0] += 1
    return int(f(x/2, iters))

def main():

    inp = 0
    result = 0
    iters = [0]

    input_str = input("Enter a number from 1 to 99999:\n").strip()
    try:
        inp = int(input_str)
    except ValueError:
        print("Invalid input.")
        sys.exit(1)

    if inp > 0:
        result = f(inp, iters)
        print(f'{result} ({iters})')

    if iters[0] == 7 and (result + iters[0]) == 18: # result = 11 after 7 iterations
        with open("flag.txt") as fp:
            buff = fp.readline().strip()
            print(buff)
    else:
        print("Try again!")

if __name__ == "__main__":
    main()
