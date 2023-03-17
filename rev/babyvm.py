import sys

mem = ["0"] * 64
memCounter = 0
x = ["0"] * 64
y = ["0"] * 64
swap_temp = []
ic = 0

inp = sys.stdin.read(1)
while (inp != '0'):
    if inp == "1": # increment memCounter (sets mem val to 33)
        memCounter += 1
        mem[memCounter] = 33
    if inp == "2": # swap x and y
        swap_temp = x
        x = y
        y = swap_temp
    if inp == "3": # store mem_val to y
        y[memCounter] = mem[memCounter]       
    if inp == "4": # store input to mem
        temp = sys.stdin.read(1)
        print(temp)
        mem[memCounter] = temp
    if inp == "5": # decrement memCounter
        memCounter -= 1
    inp = sys.stdin.read(1)
    ic += 1

print(f'x: {x}\ny: {y}')
print(f'ic: {ic}')
if "GOOD" in "".join(x) and "JOB" in "".join(y):
    if ic % 2 != 0:
        print("almost")
        exit()
    print(open("flag.txt").read())
else:
    print("no lol")
