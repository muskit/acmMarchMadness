alphabet = ('.', '!', '#')

f = open('input.txt')

# instruction dimensions
l = f.readline().strip()
iw, ih = int(l.split()[0]), int(l.split()[1])

# get instruction
ins = []
for i in range(0, ih):
    ins.append(f.readline().strip())

# skip memory dimensions
f.readline()

# create memory representation
mem = []
for l in f:
    mem.append(l.strip())
f.close()

# search function
def match(root_x, root_y):
    for x in range(0, iw):
        for y in range(0, ih):
            if mem[root_y+y][root_x+x] != ins[y][x]:
                return False
    return True
    
# search memory for instruction
instances = 0
y = 0
while y <= len(mem) - ih:
    x = 0
    while x <= len(mem[0]) - iw:
        if match(x, y):
            print(f'match found at ({x}, {y})')
            instances += 1
        x += 1
    y += 1


print(f'{instances} instructions found')